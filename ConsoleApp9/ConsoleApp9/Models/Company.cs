using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp9.Models
    
{
    public delegate bool CheckProperty(string name);
    public delegate void ErrorDelegate(string message);
    public delegate void CompanyDelegate(string name,string surname,ref User user, List<User> users);
    public class Company
    {
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Company(string name)
        {
            Name = name;
            Users = new List<User>();
        }

        public void Register()
        {
            ErrorDelegate error = new ErrorDelegate(LogError.Error);
            CheckProperty check= new CheckProperty(LogRegister.CheckName);
            CompanyDelegate company = new CompanyDelegate(LogRegister.CreateUsername);
            company += LogRegister.CreateEmail;

        Name:
            Console.WriteLine("0 :Main Menu\n\nName:");
            string name = Console.ReadLine().Trim();
            if (name == "0")
            {
                Console.Clear();
                return;
            }
            if (!check(name))
            {
                error("Name is not valid");
                goto Name;
            }
            name=Capitalize(name);

        Surname:
            Console.WriteLine("0 :Main Menu\n\nSurname:");
            string surname = Console.ReadLine().Trim();
            if (surname == "0")
            {
                Console.Clear();
                return;
            }
            if (!check(surname))
            {
                error("Surname is not valid");
                goto Surname;
            }
            surname = Capitalize(surname);

        Password:
            Console.WriteLine("0 :Main Menu\n\nPassword:");
            string password = Console.ReadLine();
            if (password == "0")
            {
                Console.Clear();
                return;
            }
            if (String.IsNullOrEmpty(password)) { error("Password is Empty or Null");
                goto Password; }

            if (password.Length < 8) { error("Password is less than 8 characters");
                goto Password;
            }
            if (!Char.IsUpper(password[0])) { error("Password does not start with upper letter ");
                goto Password;
            }
            bool valid = false;
            bool valid2 = false;
            for (int i = 0; i < password.Length; i++)
            {
                if (Char.IsDigit(password[i]))
                {
                    valid = true;
                }
                if (Char.IsLower(password[i]))
                {
                    valid2 = true;
                }
            }
            if (valid == false || valid2 == false) { error("Password does not contain digit or lower case ");
                goto Password;
            }
            User user =new User(name,surname,password);
            company.Invoke(name,surname,ref user,Users);
            Users.Add(user);
            Console.Clear();
            Console.WriteLine($"Succesfully registered Id:{user.Id} Username:{user.Username} Email:{user.Email}");
        }
        public void Login()
        {
            ErrorDelegate error = new ErrorDelegate(LogError.Error);
            Login:
            Console.WriteLine("0 :Main Menu\n\nUsername:");
            string username=Console.ReadLine().Trim();
            if (username=="0")
            {
                Console.Clear();
                return;
            }
            Console.WriteLine("0 :Main Menu\n\nPassword:");
            string password = Console.ReadLine().Trim();
            if (password == "0")
            {
                Console.Clear();
                return;
            }
             User user = Users.Find(x => x.Username == username);
            if (user==null)
            {
                Console.Clear();
                error("Incorrect username or password");
                goto Login;
            }
            else
            {
                if (user.Password == password)
                {
                    Console.Clear();
                    Console.WriteLine("Login Successful");
                }
                else
                {
                    Console.Clear();
                    error("Incorrect username or password");
                    goto Login;
                }
            }
        }
        public static string Capitalize(string item)
        {
            StringBuilder str = new StringBuilder();
            str.Append(Char.ToUpper(item[0]));
            for (int i = 1; i < item.Length; i++)
            {
                str.Append(Char.ToLower(item[i]));
            }
            return str.ToString();
        }
    }

}
