using System;
using System.Collections.Specialized;
using System.IO;

namespace Week5Day5Demo.CollectionAssignment
{
    internal class UserPasswordAuthorization
    {
        private const string PasswordFilePath = @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\28-Jan-2022\Week5Day5Demo\Week5Day5Demo\CollectionAssignment\files\authorization.txt";

        private readonly StringDictionary _userPasswordDictionary = new();
        private string _password; // Note: Do not make this public as else other programmers can view the password

        public string UserName { get; set; }

        public void LoadPasswordsFile()
        {
            var passwordEntries = File.ReadAllLines(PasswordFilePath);

            foreach (var passwordEntry in passwordEntries)
            {
                var userPassword = passwordEntry.Split(',');

                var userName = userPassword[0];
                var password = userPassword[1];

                _userPasswordDictionary.Add(userName, password);
            }
        }

        public bool Authorize()
        {
            Console.Write("Enter username: ");
            var userName = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            var passwordFromDictionary = _userPasswordDictionary[userName];

            if (password == passwordFromDictionary)
            {
                UserName = userName;
                _password = password;
                return true;
            }

            return false;
        }

        public bool ReVerifyPassword(string password)
        {
            return password == _password;
        }
    }
}