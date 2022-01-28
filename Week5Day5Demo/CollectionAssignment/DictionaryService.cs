using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;

namespace Week5Day5Demo.CollectionAssignment
{
    internal class DictionaryService
    {
        private readonly UserLogs _userLogs;
        private readonly UserPasswordAuthorization _userPasswordAuthorization;
        private const string DictionaryPath = @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\28-Jan-2022\Week5Day5Demo\Week5Day5Demo\CollectionAssignment\files\Dictionary.txt";

        private readonly StringDictionary _dictionaryData = new();

        public DictionaryService(UserLogs userLogs, UserPasswordAuthorization userPasswordAuthorization)
        {
            _userLogs = userLogs;
            _userPasswordAuthorization = userPasswordAuthorization;
        }

        public void LoadAllWordsFromFile()
        {
            var entries = File.ReadAllLines(DictionaryPath);

            foreach (var entry in entries)
            {
                if (entry == "") 
                    break;
                var wordMeaning = entry.Split('|');

                var word = wordMeaning[0];
                var meaning = wordMeaning[1];

                _dictionaryData.Add(word, meaning);
            }
        }

        public void AddNewWords()
        {
            Console.WriteLine("Adding a new word to dictionary");
            Console.Write("Enter word: ");
            var word = Console.ReadLine();
            Console.Write("Enter meaning: ");
            var meaning = Console.ReadLine();

            Console.Write("Reenter password to verify: ");
            var password = Console.ReadLine();

            if (_userPasswordAuthorization.ReVerifyPassword(password))
            {
                if (_dictionaryData.ContainsKey(word))
                {
                    Console.WriteLine("This word already exists in the dictionary!");
                }
                else
                {
                    _dictionaryData.Add(word, meaning);
                    _userLogs.AddWordLog(word, meaning, _userPasswordAuthorization.UserName);
                }
            }
            else
            {
                Console.WriteLine("You entered a wrong password. Word is not saved. Please try again.");
            }
        }

        public void ShowMeaningOfWord()
        {
            Console.Write("Enter word: ");
            var word = Console.ReadLine();

            var meaning = _dictionaryData[word];

            Console.WriteLine(
                meaning != "" ? 
                    $"Meaning: {meaning}" : 
                    $"Word [{word}] not found in the dictionary!");
        }

        public void ListDictionary()
        {
            // Assignment: add code to display full dictionary with words and meanings on the screen
        }

        public void Save()
        {
            using (var sw = new StreamWriter(DictionaryPath))
            {
                foreach (DictionaryEntry entry in _dictionaryData)
                {
                    sw.WriteLine($"{entry.Key}|{entry.Value}");
                }
            }
        }
    }
}