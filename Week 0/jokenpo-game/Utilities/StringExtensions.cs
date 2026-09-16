namespace JokenpoTerminal.Utilities
{
    public static class StringExtensions
    {
        public static string PadCenter(this string text, int totalWidth, char paddingChar = ' ')
        {
            if (text == null)
            {
                text = string.Empty;
            }

            if (totalWidth <= text.Length)
            {
                return text;
            }

            int padLeft = ((totalWidth - text.Length) / 2) + text.Length;
            return text.PadLeft(padLeft, paddingChar).PadRight(totalWidth, paddingChar);
        }
    }
}