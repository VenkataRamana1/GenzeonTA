using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genzeon.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public int employeeId { get; set; }

        public string employeeName { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email Id")]
        public string emailId { get; set; }

        public bool isInterviewer{ get; set; }

        public bool isActive { get; set; }

        public virtual ICollection<InterviewViewModel> interviewViewModels { get; set; }


    }
}