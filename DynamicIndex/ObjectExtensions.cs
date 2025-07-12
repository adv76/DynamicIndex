namespace DynamicIndex
{
    public static class ObjectExtensions
    {
        public static DynamicIndex Index(this object o) => new(o);
    }
}
