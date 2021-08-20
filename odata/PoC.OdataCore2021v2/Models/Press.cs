namespace PoC.OdataCore2021v2.Models
{
    public class Press : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Category Category { get; set; }
    }
}