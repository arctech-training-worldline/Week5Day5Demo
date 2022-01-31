using System;

namespace Week5Day5Demo.CollectionAssignment
{
    internal class WordsDictionaryApp
    {
        private readonly UserPasswordAuthorization _userPasswordAuthorization;
        private readonly DictionaryService _dictionaryService;
        private readonly UserLogs _userLogs;

        public WordsDictionaryApp()
        {
            _userLogs = new UserLogs();
            _userPasswordAuthorization = new UserPasswordAuthorization();
            _dictionaryService = new DictionaryService(_userLogs, _userPasswordAuthorization);
        }

        public void Start()
        {
            _userPasswordAuthorization.LoadPasswordsFile();
            var loggedIn = _userPasswordAuthorization.Authorize();

            if (!loggedIn)
            {
                Console.WriteLine("You have entered an invalid username/password. Exiting now...");
                return;
            }

            Console.WriteLine("Welcome to the dictionary app!!");
            _userLogs.AddLoginLog(_userPasswordAuthorization.UserName);

            _dictionaryService.LoadAllWordsFromFile();

            ShowMenu();

            _userLogs.SaveLog();
        }

        private void ShowMenu()
        {
            // Assignment: Show the menu and call the methods in switch case.
            char menuId;
            do
            {
                Console.WriteLine("Enter a menu item 1 to 5");
                var key = Console.ReadKey();
                menuId = key.KeyChar;

                switch (menuId)
                {
                    case '1':
                        _dictionaryService.AddNewWords();
                        break;
                    case '2':
                        _dictionaryService.ShowMeaningOfWord();
                        break;
                    case '3':
                        _dictionaryService.ListDictionary();
                        break;
                    case '4':
                        _userLogs.DisplayLogs();
                        break;
                    case '5':
                        Exit();
                        break;
                }
            } while (menuId != '5');
        }

        public void Exit()
        {
            Console.Write("Do you want to save the words into the dictionary before exiting [y/n]?");
            var key = Console.ReadKey();

            if (key.KeyChar == 'y' || key.KeyChar == 'Y')
            {
                _dictionaryService.Save();
                _userLogs.AddFileSavedLog(_userPasswordAuthorization.UserName);
            }

            _userLogs.AddLogoutLog(_userPasswordAuthorization.UserName);
        }
    }
}