namespace DynamicIndexTests.Models
{
    internal class MiddleObject
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; } = string.Empty;
        public BottomObject Object1 { get; set; } = new();
    }
}
