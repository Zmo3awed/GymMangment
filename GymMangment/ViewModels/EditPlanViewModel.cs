using System.ComponentModel.DataAnnotations;

namespace GymMangment.ViewModels
{
    public class EditPlanViewModel
    {
        public int Id { get; set; }
        [Display(Name="Plan")]
        public string PlanName { get; set; } = default!;
        [Required(ErrorMessage = "Description is Required")]
        [StringLength(1000,MinimumLength = 10, ErrorMessage ="Must be Grater Than 10 Char")]
        public string Description { get; set; } =default!;
        [Required(ErrorMessage = "DurationDays is Required")]
        [Range(1,365,ErrorMessage ="Must be between 1 and 365")]
        [Display(Name = "Duration (Day)")]
        public int DurationDays { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        [Range(1,10000,ErrorMessage ="Price Must Be Grater Than 0")]
        [Display(Name ="Price (EGP)")]
        public decimal Price { get; set; }

    }
}
