using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp9.Models
{
    public class User
    {
        private static int Count = 0;
        public int Id { get;}
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string name,string surname,string password)
        {
            Count++;
            Id = Count;
            Name = name;
            Surname = surname;
            Password = password;

        }
    }
}
