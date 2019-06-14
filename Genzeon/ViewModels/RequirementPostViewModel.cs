using Genzeon.Models;
using Genzeon.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Genzeon.ViewModels
{
    public class RequirementData
    {
        [Key]
        public int JobCode { get; set; }

        [Required]
        [Display(Name = "Position Name")]
        public string DesignationName { get; set; }

        [Required]
        [Display(Name = "Experience")]
        public string Experience { get; set; }

        [Required]
        [Display(Name = " Location")]
        public string Location { get; set; }

        [Required]
        [Display(Name = "Qualification")]
        public string Qualification { get; set; }
        
        [Display(Name = "Salary")]
        [DataType(DataType.Currency)]
        public string Salary { get; set; }
             
        [Display(Name = "No of Vacancy")]
        public int Vacancies { get; set; }

        [Display(Name = "Shift Type")]
        public string ShiftType { get; set; }

        [Required]
        [AllowHtml]
        [Display(Name = "Job Description")]
        public string Description { get; set; }

        [Display(Name ="Added On")]
        public String Date { get; set; }
        
        public int TechId { get; set; }
        public virtual Tech Tech { get; set; }

        public int TeamId { get; set; }
        public virtual TeamNames TeamNames { get; set; }

        public virtual ICollection<ApplicantsResume> Applicants { get; set; }

        public virtual ICollection<InterviewViewModel> interviewViewModel { get; set; }

        
        public string Email { get; set; }
        
        public ApplicationUser ApplicationUser { get; set; }

       
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