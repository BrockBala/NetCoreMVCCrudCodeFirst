namespace NetCoreCrudCodefirst.Models
{
    public class UpdateFighterViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public DateTime DOB { get; set; }
        public string Description { get; set; }
    }
}
