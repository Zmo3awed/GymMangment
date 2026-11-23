namespace GymMangment.Entityes
{
    public class Member : GymUser // Inhert From GymUser And GymUser Inhert From Base So He Inhert Indirect From Base 
    {
        public DateTime JoinDate { get; set; }
        public string Photo { get; set; } = default!;
        public ICollection<MemberShip> MemberSupscription { get; set; }



    }
}
