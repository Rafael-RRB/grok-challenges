namespace JokenpoTerminal.Utilities
{
    public static class StringArrayExtensions
    {
        public static int MaxLength(this string[] stringArray)
        {
            int longestString = 0;

            if (stringArray == null || stringArray.Length == 0)
            {
                return 0;
            }

            foreach (string str in stringArray)
            {
                if (str.Length > longestString)
                {
                    longestString = str.Length;
                };
            };

            return longestString;
        }
    }
}
