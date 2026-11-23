using System.ComponentModel.DataAnnotations.Schema;

namespace GymMangment.Entityes
{
    public class MemberShip :BaseEntitey
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public int planId { get; set; }
        public Plan Plan { get; set; }
        [NotMapped]
        public string Status => StartDate > DateTime.Now ? "UpComing" : 
            EndDate > DateTime.Now ? "Active" : "Expired";

    }
}
