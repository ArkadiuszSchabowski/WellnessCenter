namespace WellnessCenterBackend.Entities
{
    public class MassageName
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public int ServiceTime { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
    }
}
