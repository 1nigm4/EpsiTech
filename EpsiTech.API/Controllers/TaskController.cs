using EpsiTech.API.DAL.Repositories;
using EpsiTech.API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EpsiTech.API.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null) return NotFound(id);
            return Ok(task);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _taskRepository.GetAllAsync();
            return Ok(tasks);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateTaskViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var task = new Domain.Models.Task
            {
                Title = model.Title,
                Description = model.Description,
                CreatedDate = DateTime.Now
            };

            bool isCreated = await _taskRepository.CreateAsync(task);
            if (!isCreated) return Problem("Task not created");
            return Ok(task);
        }

        [HttpPut("edit")]
        public async Task<IActionResult> Edit(UpdateTaskViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var task = await _taskRepository.GetByIdAsync(model.TaskId);
            if (task == null) return NotFound(model.TaskId);

            if (task.Title == model.NewTitle && task.Description == model.NewDescription) return Conflict("Task has no changes");

            task.Title = model.NewTitle;
            task.Description = model.NewDescription;
            task.UpdatedDate = DateTime.Now;

            bool isUpdated = await _taskRepository.EditAsync(task);
            if (!isUpdated) return Problem("Task not updated");

            return Ok(task);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            if (task == null) return NotFound(id);

            bool isDeleted = await _taskRepository.DeleteAsync(task);
            if (!isDeleted) return Problem("Task not deleted");

            return Ok();
        }
    }
}
