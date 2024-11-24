using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TestUsers
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(50)]
        public string GroupUser { get; set; }
        public ICollection<TestResult> TestResults { get; set; } = new List<TestResult>();

        public Users() { }

        public Users(string login, string password, string name, string surname, string group)
        {
            Login = login;
            Password = password;
            Name = name;
            Surname = surname;
            GroupUser = group;
        }
    }
}



