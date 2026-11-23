namespace GymMangment.Entityes
{
    public class Plan : BaseEntitey
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public ICollection<MemberShip> Supscripers { get; set; } = default!;

    }
}
