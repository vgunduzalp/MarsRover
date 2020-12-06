namespace MarsRover.Extensions
{
    public static class CommonExtensions
    {
        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool IsNotEmpty(this string value)
        {
            return !value.IsEmpty();
        }

        public static int ToInt32(this string data)
        {
            return int.Parse(data);
        }

    }
}
