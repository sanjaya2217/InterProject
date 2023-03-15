using System.ComponentModel.DataAnnotations;

namespace InterviewAPI.Models
{

    //Person Entity
    public class PersonEntity
    {
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }
    }
}
