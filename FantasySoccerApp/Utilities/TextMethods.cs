namespace FantasySoccerApp.Utilities
{
    public static class TextMethods
    {
        public static string NoNull(this string value)
        {
            return (value == null) ? "" : value.Trim();
        }
    }
}
