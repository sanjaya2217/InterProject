using System.ComponentModel.DataAnnotations;


namespace InterviewApp.Areas.Person.Models
{
    public class PersonEntity
    {

        [Required( ErrorMessage ="First name is required")]
        [Display(Name = "First Name")]
        public string firstName { get; set; }


        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }


    }
}