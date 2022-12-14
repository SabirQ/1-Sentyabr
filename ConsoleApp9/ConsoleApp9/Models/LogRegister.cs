using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp9.Models
{
    public static class LogRegister
    {
        public static void CreateUsername(string name, string surname, ref User user, List<User> users)
        {
            string username = $"{name.Trim().ToLower()}.{surname.Trim().ToLower()}";
            int count = 0;
            for (int i = 0; i < users.Count;)
            {
                if (username == users[i].Username)
                {
                    Console.WriteLine("Username is same");
                    count++;
                    Console.WriteLine($"Would you like to use autogenerated username?\n{name.Trim().ToLower()}.{surname.Trim().ToLower()}{count}:(Yes/Any to make custom username)");
                    string answer = Console.ReadLine().Trim().ToLower();
                    if (answer == "yes")
                    {
                        username = $"{name.Trim().ToLower()}.{surname.Trim().ToLower()}{count}";
                    }
                    else
                    {
                        Console.Clear();
                        Username:
                        Console.WriteLine("Username: (letters automatically converted to lower case/at least contains 5 characters)");
                        username = Console.ReadLine().Trim().ToLower();
                        if (username.Length<5)
                        {
                            Console.WriteLine("Username is not valid");
                            goto Username;
                        }
                    }
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            user.Username = username;
        }
        public static void CreateEmail(string name, string surname, ref User user, List<User> users)
        {
            string email = $"{name.Trim().ToLower()}.{surname.Trim().ToLower()}@gmail.com";
            int count = 0;
            for (int i = 0; i < users.Count;)
            {
                if (email == users[i].Email)
                {
                    Console.Clear();
                    Console.WriteLine("Email is already exist");
                    count++;
                    Console.WriteLine($"Would you like to use autogenerated email?\n{name.Trim().ToLower()}.{surname.Trim().ToLower()}{count}@gmail.com :(Yes/Any to make custom email)");
                    string answer=Console.ReadLine().Trim().ToLower();
                    if (answer=="yes")
                    {
                        email = $"{name.Trim().ToLower()}.{surname.Trim().ToLower()}{count}@gmail.com";
                    }
                    else
                    {
                        Console.Clear();
                        Email:
                        Console.WriteLine("Email:(Domain will be default @gmail.com just add first part)");
                        email = Console.ReadLine().Trim()+"@gmail.com";
                        if (!LogRegister.CheckEmail(email))
                        {
                            Console.WriteLine("Email is not valid");
                            goto Email;
                        }
                    }
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            user.Email = email;
        } 
        public static bool CheckEmail(string email)
        {
            if (String.IsNullOrEmpty(email)) return false;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return regex.IsMatch(email);
        }
        public static bool CheckName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
              return false;
            }
            if (name.Length < 3)
            {
                return false;
            }
            for (int i = 0; i < name.Length; i++)
            {
                if (!Char.IsLetter(name[i]))
                {
                    return false;
                }
            }
           return true;
        }
    }
}
