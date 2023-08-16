using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyWeb { get; set; }
        public string? CompanyMail { get; set; }
        public long? CompanyTel { get; set; }
        public string? CompanySector { get; set; }
    }

    public class CustomerCreationDto : CustomerAddUpdateDto
    {

    }

    public class CustomerUpdateDto : CustomerAddUpdateDto
    {

    }

    public abstract class CustomerAddUpdateDto
    {
        [Required(ErrorMessage = "Student name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string? CompanyName { get; set; }

        public string? CompanyWeb { get; set; }
        [Required(ErrorMessage = "Class is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string? CompanyMail { get; set; }
        public long? CompanyTel { get; set; }
        public string? CompanySector { get; set; }
    }




}
