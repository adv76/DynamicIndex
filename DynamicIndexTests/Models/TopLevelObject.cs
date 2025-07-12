namespace DynamicIndexTests.Models
{
    internal class TopLevelObject
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; } = string.Empty;
        public int[] Array1 { get; set; } = [];
        public List<BottomObject> Array2 { get; set; } = [];
        public MiddleObject Object1 { get; set; } = new();
    }
}
