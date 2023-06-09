﻿using EmployeeDetails.Model.Custom_Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetails.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [CustomEmailValidator(AttributeText ="gmail.com")]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public int DepartmentId { get; set; }

        public string PhotoPath { get; set; }   

        public Department Department { get; set; }


    }
}
