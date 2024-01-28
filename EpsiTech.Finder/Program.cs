namespace EpsiTech.Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 11, 22, 33, 34, 44, 55, 56 };
            int num = 34;

            int position = GetIndex(nums, num);
            Console.WriteLine($"Массив: {string.Join(", ", nums)}");
            Console.WriteLine($"Индекс элемента: {position}");
        }

        static int GetIndex(int[] nums, int num)
        {
            //Array.Sort(nums);
            //return Array.IndexOf(nums, num);
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == num) return i;
            }

            return -1;
        }
    }
}