using System;
using System.Collections.Generic;

namespace App.Domain.DBGeneratedModel
{
    public partial class EmployeeInformation
    {
        public decimal Id { get; set; }
        public string Name { get; set; }
        public decimal? EmployeeNumber { get; set; }
        public decimal? MobileNumber { get; set; }
        public string Email { get; set; }
        public decimal? FamilyMemberNo { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string DisplayName { get; set; }
        public string NationalId { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? NidExpirationDate { get; set; }
        public string MaritalStatus { get; set; }
        public string ActualAddress { get; set; }
        public string CertificateLevel { get; set; }
        public string GraduationYear { get; set; }
        public string Universty { get; set; }
        public string QualifyEducation { get; set; }
        public string Relatives { get; set; }
        public string EmergencyContactName { get; set; }
        public decimal? EmergencyContactNumber { get; set; }
    }
}
