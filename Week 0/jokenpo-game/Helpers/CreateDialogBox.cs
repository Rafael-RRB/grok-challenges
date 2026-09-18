using StringArrayExtensions;

namespace JokenpoTerminal.Helpers
{
    public static class DialogBox
    {
        public static string[] Create(string[] messages)
        {
            if (messages == null || messages.Length == 0)
            {
                return new string[] { "####", "#  #", "####" };
            }

            int contentWidth = messages.MaxLength();
            int totalWidth = contentWidth + 4;

            string outerBorder = new string('#', totalWidth);
            string innerBorder = $"# { new string(' ', contentWidth)} #";

            string[] dialogBox = new string[messages.Length + 4];
            dialogBox[0] = outerBorder;
            dialogBox[1] = innerBorder;
            dialogBox[dialogBox.Length - 2] = innerBorder;
            dialogBox[dialogBox.Length - 1] = outerBorder;

            for (int i = 0; i < messages.Length; i++)
            {
                dialogBox[2 + i] = $"# { messages[i]} #";
            }

            return dialogBox;
        }
    }
}
