namespace GymMangment.Entityes
{
    public class Trainer : GymUser
    {
        public DateTime HireDate { get; set; }
        public Speciality Speciality { get; set; }
        public ICollection<Session> Sessions { get; set; }


    }
}
