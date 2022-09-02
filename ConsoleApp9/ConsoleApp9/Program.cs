using ConsoleApp9.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CompanyName:
            Console.WriteLine("Create Company:(Name)");
            string companyName=Console.ReadLine().Trim();
            if (companyName.Length<2)
            {
                goto CompanyName;
            }
            Company company = new Company(companyName);
            Console.Clear();
            Console.WriteLine($"{companyName} Company succesfully cretaed");
            Console:
            Console.WriteLine( $"\n1:Register\n2:Login\n3:Show all users\n4:Get one User from Company\n5:Update User's datas\n6:Delete User\n\n\n0:Exit");
            string answer=Console.ReadLine().Trim();

            if (answer == "1")
            {
                Console.Clear();
            Yes:
                company.Register();
                Console.WriteLine("Add more user?(Yes/any key if NO)");
                string str = Console.ReadLine();
                if (str.Trim().ToLower() == "yes")
                {
                    Console.Clear();
                    goto Yes;
                }
                else
                {
                    goto Console;
                }
            }
            else if (answer == "2")
            {

                Console.Clear();
                if (company.Users.Count<1)
                {
                    Console.Clear();
                    Console.WriteLine("There is no user in company");
                    goto Console;
                }
                company.Login();
                goto Console;
            }
            else if (answer == "3")
            {
                if (company.Users.Count < 1)
                {
                    Console.Clear();
                    Console.WriteLine("There is no user in the company");
                    goto Console;
                }
                else
                {
                    Console.Clear();
                    foreach (var item in company.Users)
                    {
                        Console.WriteLine($"Id:{item.Id} Username:{item.Username} Email:{item.Email} Name:{item.Name} Surname:{item.Surname}");
                    }
                    goto Console;
                }
            }
            else if (answer == "4")
            {
                Console.Clear();
            ID:
                if (company.Users.Count < 1)
                {
                    Console.Clear();
                    Console.WriteLine("There is no user in company");
                    goto Console;
                }
                int id = 0;
                Console.WriteLine("\n0 :Main Menu\n\n");
                Console.WriteLine("Enter user Id:");
                string str = Console.ReadLine().Trim();
                if (str=="0")
                {
                    Console.Clear();
                    goto Console;
                }
                bool result = int.TryParse(str, out id);
                if (!result)
                {
                    Console.WriteLine("Id is not valid");
                    goto ID;
                }
                User user = company.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    Console.WriteLine("There is no user with given Id");
                    goto ID;
                }
                Console.Clear();
                Console.WriteLine($"Id:{user.Id}\nName:{user.Name}\nSurname:{user.Surname}\nEmail:{user.Email}");
                Console.WriteLine("\n\nPress Any Key to return to Main menu:");
                Console.ReadKey();
                Console.Clear();
                goto Console;
            }
            else if (answer == "5")
            {
                Console.Clear();
            Update:
                if (company.Users.Count < 1)
                {
                    Console.Clear();
                    Console.WriteLine("There is no user in company");
                    goto Console;
                }
                int id = 0;
                Console.WriteLine("\n0 :Main Menu\n\n");
                Console.WriteLine("Enter user's Id whose data you need to change:");
                string str = Console.ReadLine().Trim();
                if (str == "0")
                {
                    Console.Clear();
                    goto Console;
                }
                bool result = int.TryParse(str, out id);
                if (!result)
                {
                    Console.WriteLine("Id is not valid");
                    goto Update;
                }
                User user = company.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    Console.WriteLine("There is no user with given Id");
                    goto Update;
                }
                Console.Clear();
                Console.WriteLine($"Id:{user.Id}\nChose which data you need to change:\n1 :Name:{user.Name}\n2 :Surname:{user.Surname}\n3 :Email:{user.Email}\n\n0 :Main Menu");
                str = Console.ReadLine().Trim();
                if (str=="0")
                {
                    Console.Clear();
                    goto Console;
                }
                else if(str == "1")
                {
                Name:
                    Console.WriteLine("0: Main menu\n");
                    Console.WriteLine("Enter new name:");
                    string name=Console.ReadLine().Trim();
                    if (name=="0")
                    {
                        Console.Clear();
                        goto Console;
                    }
                    if (!LogRegister.CheckName(name))
                    {
                        Console.WriteLine("Name is not valid");
                        goto Name;
                    }
                    Console.Clear();
                    user.Name = Company.Capitalize(name);
                    Console.WriteLine($"Name of user succesfully was changed to {user.Name}");
                }
                else if (str == "2")
                {
                Surname:
                    Console.WriteLine("0: Main menu\n");
                    Console.WriteLine("Enter new surname:");
                    string surname = Console.ReadLine().Trim();
                    if (surname == "0")
                    {
                        Console.Clear();
                        goto Console;
                    }
                    if (!LogRegister.CheckName(surname))
                    {
                        Console.WriteLine("Surname is not valid");
                        goto Surname;
                    }
                    Console.Clear();
                    user.Surname = Company.Capitalize(surname);
                    Console.WriteLine($"Surname of user succesfully was changed to {user.Surname}");
                }
                else if (str == "3")
                {
                Email:
                    Console.WriteLine("0: Main menu\n");
                    Console.WriteLine("Enter new Email:(Domain will be default @gmail.com just add first part)");
                    string email = Console.ReadLine().Trim();
                    if (email == "0")
                    {
                        Console.Clear();
                        goto Console;
                    }
                    email += "@gmail.com";
                    if (!LogRegister.CheckEmail(email))
                    {
                        Console.WriteLine("Email is not valid");
                        goto Email;
                    }
                    Console.Clear();
                    user.Email = email;
                    Console.WriteLine($"Email of user succesfully was changed to {user.Email}");
                }
                goto Console;
            }
            else if (answer == "6")
            {
                Console.Clear();
            Delete:
                if (company.Users.Count < 1)
                {
                    Console.Clear();
                    Console.WriteLine("There is no user in company");
                    goto Console;
                }
                Console.WriteLine("\n0 :Main Menu\n\n");
                int id = 0;
                Console.WriteLine("Enter user's Id whom you want to remove :");
                string str = Console.ReadLine();
                if (str == "0")
                {
                    Console.Clear();
                    goto Console;
                }
                bool result = int.TryParse(str, out id);
                if (!result)
                {
                    Console.WriteLine("Id is not valid");
                    goto Delete;
                }
                User user = company.Users.FirstOrDefault(x => x.Id == id);
                if (user == null)
                {
                    Console.WriteLine("There is no user with given Id");
                    goto Delete;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Are you sure, you need to delete next user?(Yes/Any key to cancel)\nId:{user.Id} Username:{user.Username} Email:{user.Email} Name:{user.Name} Surname:{user.Surname}");
                    str=Console.ReadLine();
                    if (str=="yes")
                    {
                        company.Users.Remove(user);
                        Console.Clear();
                        Console.WriteLine("Succesfully Removed");
                        goto Console;
                    }
                    Console.Clear();
                    goto Console;
                }
            }
            else if (answer == "0")
            {
                return;
            }
            else
            {
                Console.Clear();
                goto Console;
            }
        }
    }
}
