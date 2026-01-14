namespace FirstProgram_Library
{
    public class Even
    {
        public List<int> EvenList(int start, int end)
        {
            List<int> ints = new List<int>();
            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                { 
                    ints.Add(i); 
                }
            }
            return ints;
        }
    }
}
