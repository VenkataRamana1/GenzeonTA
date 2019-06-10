using Genzeon.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genzeon.ViewModels
{
    public class InterviewViewModel
    {
        [Key]
        public int InterViewId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime interviewDateTime { get; set; }

        public string assginedBy { get; set; }

        public int employeeId { get; set; }
        public virtual EmployeeViewModel employeeViewModel { get; set; }

        //public int resourceId { get; set; }
        //public virtual ApplicantsResume applicantsResume { get; set; }

        //public int jobCode { get; set; }
        //public virtual RequirementData requirementData { get; set; } 
    }
}