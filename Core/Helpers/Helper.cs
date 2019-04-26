namespace Core.Helpers
{
    public static class Helper
    {
        public static int GetClassNumberFromClassName(string className)
        {
            return int.Parse(className.Substring(0, className.Length - 1));
        } 
    }
}