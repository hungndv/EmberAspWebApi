using System.ComponentModel.DataAnnotations;

namespace Demo.Bll.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required.", AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required.", AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        public string LastName { get; set; }
    }
}
