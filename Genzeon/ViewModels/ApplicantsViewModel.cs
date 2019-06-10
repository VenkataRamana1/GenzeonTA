using Genzeon.ViewModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Genzeon.ViewModels
{
    public class ApplicantsResume
    {
        [Key]
        public int resourceId { get; set; }

        [Required]
        public string firstName { get; set; }

        public string middleName { get; set; }

        public string lastName { get; set; }

        [Required]
        public string emailId { get; set; }

        [Required]
        public string phoneNumber { get; set; }

        public string technology { get; set; }

        public double experience { get; set; }

        public string noticePeriod { get; set; }

        public string currentSalary { get; set; }

        public string expectedSalary { get; set; }

        [Required]
        public string applicantResume { get; set; }

        public int jobCode { get; set; }
        public virtual RequirementData requirementData { get; set; }

        public int ApplicantStatusId { get; set; }
        public virtual ApplicantStatus applicantStatus { get; set; }

        public virtual ICollection<InterviewViewModel> interviewViewModel { get; set; }


    }

    public class ApplicantStatus
    {
        [Key]
        public int ApplicantStatusId { get; set; }

        [Required]
        public string StatusName { get; set; }

        public virtual ICollection<ApplicantsResume> applicans { get; set; }
    }



}