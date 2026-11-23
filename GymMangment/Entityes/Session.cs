namespace GymMangment.Entityes
{
    public class Session : BaseEntitey
    {
        public string Descripcion { get; set; } = default!;
        public int Capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Trainer Trainer { get; set; }
        public int TrainerId { get; set; }

    }
}
