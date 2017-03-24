using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamManagement.Web.Models
{
    public class PlayerDetailsModel
    {
        public string errorMessage { get; set; }

        public bool successMessage { get; set; }

        public bool displayErrorBlock { get; set; }

        public PersonalDetails personalDetails { get; set; }
        public ContactDetails contactDetails { get; set; }

    }
    public class PersonalDetails
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [DisplayName("Surname")]
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }

        [DisplayName("Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Date Of Birth is required")]
        public  DateTime DateOfBirth { get; set; }

        [DisplayName("ID Number")]
        [Required(ErrorMessage = "ID Number is required")]
        public string IDNo { get; set; }

    }
    public class ContactDetails
    {
        public int Id { get; set; }

        [DisplayName("Cell Number")]
        public string Cell { get; set; }


        [DisplayName("Home Number")]
        public string HomeNumber { get; set; }

        [DisplayName("Work Number")]
        public string WorkNumber { get; set; }

        [DisplayName("Fax Number")]
        public string FaxNumber { get; set; }

          [DisplayName("Email Address")]
        public string EmailAdress { get; set; }

          [DisplayName("Other Email Address")]
          public string AlternativeEmailAdress { get; set; }

        [DisplayName("Address Line 1")]
        [Required]
        public string PhysicalAddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        [Required]
        public string PhysicalAddressLine2 { get; set; }

        [DisplayName("Address Line 3")]
        public string PhysicalAddressLine3 { get; set; }

        [DisplayName("Address Line 4")]
        public string PhysicalAddressLine4 { get; set; }

        [DisplayName("Postal Code")]
        public string PhysicalPostalCode { get; set; }

        [DisplayName("Same as Physical Address")]
        public bool ISAddressTheSame { get; set; }

        [DisplayName("Address Line 1")]
        [Required]
        public string PostalAddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        [Required]
        public string PostalAddressLine2 { get; set; }

        [DisplayName("Address Line 3")]
        public string PostalAddressLine3 { get; set; }

        [DisplayName("Address Line 4")]
        public string PostalAddressLine4 { get; set; }

        [DisplayName("Postal Code")]
        public string PostalPostalCode { get; set; }



    }

    public class AcademicDetails
    {
        [DisplayName("Degree")]
        [Required(ErrorMessage = "Degree is required")]
        public string Degree { get; set; }


        [DisplayName("Enrollemnt Year")]
        [Required(ErrorMessage = "Year is required")]
        public string Year { get; set; }

        [DisplayName("Subject Code")]
        public string SubjectCode { get; set; }

        [DisplayName("Subject Name")]
        public string SubjectName { get; set; }

        [DisplayName("Subjects")]
        public List<Subject> Subjects { get; set; }
       
    }
}