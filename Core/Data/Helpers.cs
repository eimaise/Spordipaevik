namespace Core.Data
{
    public static class Helpers
    {
        public static  int GetClassNumberFromClassName(string className)
        {
            return int.Parse(className.Substring(0, className.Length - 1));
        } 
    }
}