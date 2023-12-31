﻿using School.Domain.Enums.GenderEnum;
using School.Domain.Enums.RoleEnum;

namespace School.Domain.Entities.Persons
{
    public class Person : BaseEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string ImagePath { get; set; }
    }
}