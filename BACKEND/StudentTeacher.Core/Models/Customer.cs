using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Models
{
    public class Customer
    {
        [Column("CompanyId")]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyWeb { get; set; }


        public string CompanyMail { get; set; }

       
        public long CompanyTel { get; set; }
        public string CompanySector { get; set; }
    }
}
