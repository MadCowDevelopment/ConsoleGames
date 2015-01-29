using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Hangman
{
    internal static class Assets
    {
        private static List<string> _words;

        private static List<List<string>> _art;
 
        public static List<string> Words
        {
            get { return _words ?? InitializeWords(); }
        }

        public static List<List<string>> Art
        {
            get { return _art ?? InitializeArt(); }
        }

        private static List<string> InitializeWords()
        {
            var assembly = Assembly.GetExecutingAssembly();
            _words = new List<string>();
            using (var stream = assembly.GetManifestResourceStream("Hangman.wordlist.txt"))
            using (var reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    _words.Add(line);
                }
            }

            return _words;
        }

        private static List<List<string>> InitializeArt()
        {
            _art = new List<List<string>>();
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("Hangman.art.txt"))
            using (var reader = new StreamReader(stream))
            {
                for (int i = 0; i < 8; i++)
                {
                    var currentList = new List<string>();
                    for (int j = 0; j < 23; j++)
                    {
                        currentList.Add(reader.ReadLine());
                    }

                    _art.Add(currentList);
                }
            }

            return _art;
        }
    }
}