using System;
using System.Collections.Specialized;
using System.IO;

namespace Week5Day5Demo.CollectionAssignment
{
    internal class UserLogs
    {
        private const string LogFilePath = @"C:\Users\avina\OneDrive - arctechinfo.com\Documents\Training\Sessions\C#\28-Jan-2022\Week5Day5Demo\Week5Day5Demo\CollectionAssignment\files\UserLog.txt";

        private readonly StringCollection _stringCollection = new();
        
        public void AddLoginLog(string userName)
        {
            var logString = $"{DateTime.Now} {userName} has logged in";
            _stringCollection.Add(logString);
        }

        public void AddWordLog(string word, string meaning, string userName)
        {
            var logString = $"{DateTime.Now} {userName} has added a new entry [{word}|{meaning}]";
            _stringCollection.Add(logString);
        }

        public void AddLogoutLog(string userName)
        {
            var logString = $"{DateTime.Now} {userName} has logged out";
            _stringCollection.Add(logString);
        }

        public void SaveLog()
        {
            using (var sw = new StreamWriter(LogFilePath, true))
            {
                foreach (var logEntry in _stringCollection)
                {
                    sw.WriteLine(logEntry);
                }
            }
        }

        public void AddFileSavedLog(string userName)
        {
            var logString = $"{DateTime.Now} {userName} has saved his entries to the dictionary file";
            _stringCollection.Add(logString);
        }

        public void DisplayLogs()
        {
            // Assignment: Iterate collection and display log entries on screen.
        }
    }
}
