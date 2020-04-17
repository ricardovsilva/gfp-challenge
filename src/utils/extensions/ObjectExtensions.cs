namespace utils.extensions
{
    public static class ObjectExtensions
    {
        public static T[] asArray<T>(this T target)
        {
            return new[] { target };
        }
    }
}