using System;

namespace Week5Day5Demo.CollectionAssignment
{
    // Telephone Directory Admin Application
    // -------------------------------------
    // Preface
    // -------
    // Company ILoveWords Private Limited is printing a new dictionary of english words.
    // This company has recruited 5 english language experts to enter the words and meanings in a dictionary file.
    // All of these experts will have a computer with this application loaded.
    // ------------------------
    // Application Requirements
    // ------------------------
    // Load the valid username passwords from a file authorization.txt into a collection.. done
    // Ask user for username and password.. done
    // Confirm if the username password are valid and either allow user to continue or show error message and exit.. done
    // -----------------------------------------------------
    // **Add a entry to the Log collection, containing the user login time. ..done
    // Note: This collection is to track all actions done by the user. done
    // So if user has done some mistake, we can catch them later... done
    // -----------------------------------------------------
    // Once entering the application. Load all the existing words from the dictionary into a collection
    // Display a menu
    // 1. Add new words
    // 2. Show meaning
    // 3. List dictionary
    // 4. Display user action logs
    // 5. Exit
    // >> Add new words.. should ask user to enter word and enter meaning. Reconfirm the password just to ensure some one else is not adding junk
    // data to the dictionary. Once confirmed, add the words to the dictionary
    // **Add a entry to the Log collection containing word, meaning, user name & current date time 
    // >> Show meaning.. ask user to enter word. Search for that word in dictionary and display the meaning else Display word not found
    // >> List dictionary.. display all words and meanings on the screen
    // >> Exit.. Ask Save the words to dictionary [Y/N]?. If user enters Y save the words back to the file, else exit without saving.
    //           **Add a entry to the Log collection, containing the logout time
    internal static class Assignment1
    {
        public static void NewDictionaryAssignment()
        {
            var app = new WordsDictionaryApp();
            app.Start();

            //TestLogs();
            //TestUserAuthorization();
            //TestDictionaryService();
        }

        private static void TestDictionaryService()
        {
            var userLogs = new UserLogs();
            var userPasswordAuthorization = new UserPasswordAuthorization();
            userPasswordAuthorization.LoadPasswordsFile();
            var status = userPasswordAuthorization.Authorize();

            if (!status) return;

            var dictionaryService = new DictionaryService(userLogs, userPasswordAuthorization);

            dictionaryService.LoadAllWordsFromFile();

            dictionaryService.AddNewWords();
            dictionaryService.ShowMeaningOfWord();
            dictionaryService.ListDictionary();
            dictionaryService.Save();

            userLogs.SaveLog();
        }

        private static void TestUserAuthorization()
        {
            var userPasswordAuthorization = new UserPasswordAuthorization();

            userPasswordAuthorization.LoadPasswordsFile();

            Console.WriteLine(
                userPasswordAuthorization.Authorize() ? "Authorized" : "Not Authorized");

            Console.WriteLine(
                userPasswordAuthorization.ReVerifyPassword("Gujral@1974") ? "Verified" : "NOT Verified");
        }

        private static void TestLogs()
        {
            var userLogs = new UserLogs();

            userLogs.AddLoginLog("abhijit@gmail.com");
            userLogs.AddWordLog("xyz", "test meaning", "abhijit@gmail.com");
            userLogs.AddWordLog("xyz1", "test meaning 1", "abhijit@gmail.com");
            userLogs.AddWordLog("xyz2", "test meaning 2", "abhijit@gmail.com");
            userLogs.AddFileSavedLog("abhijit@gmail.com");
            userLogs.AddLogoutLog("abhijit@gmail.com");

            userLogs.DisplayLogs();
            userLogs.SaveLog();
        }
    }
}
