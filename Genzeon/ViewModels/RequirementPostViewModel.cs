using Genzeon.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genzeon.ViewModels
{
    public class RequirementData
    {
        [Key]
        public int jobCode { get; set; }

        [Required]
        [Display(Name ="Position Name")]
        public string positionName { get; set; }

        [Required]
        [Display(Name = "Required Skills")]
        public string skills { get; set; }

        [Display(Name = "Required no of people")]
        public int requiredSize { get; set; }

        [Display(Name = "Experience")]
        public string experience { get; set; }

        [Display(Name = "Job Description")]
        [StringLength(30, ErrorMessage = "Job description shoulb have atleast 30 characters")]
        public string jobDescription { get; set; }
     
        [DataType(DataType.Text)]
        public string uploadedBy { get; set; }

        public int TechId { get; set; }
        public virtual Tech Tech { get; set; }

        public int TeamId { get; set; }
        public virtual TeamNames TeamNames { get; set; }

        public virtual ICollection<ApplicantsResume> Applicants { get; set; }

        public virtual ICollection<InterviewViewModel> interviewViewModel { get; set; }

    }

    public class Tech
    {
        [Key]
        public int TechId { get; set; }

        [Required]
        public string TechName { get; set; }

        public virtual ICollection<RequirementData> RequirementDataViewModel { get; set; }

    }

    public class TeamNames
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string TeamName { get; set; }

        public virtual ICollection<RequirementData> RequirementDataViewModel { get; set; }
    }

}