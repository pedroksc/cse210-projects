using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _random = new Random();

            _words = new List<Word>();
            foreach (string wordText in text.Split(' '))
            {
                _words.Add(new Word(wordText));
            }
        }

        public void Display()
        {
            Console.WriteLine(_reference.GetDisplayText());
            Console.WriteLine(GetDisplayText());
            Console.WriteLine();
        }

        private string GetDisplayText()
        {
            List<string> displayWords = new List<string>();
            foreach (Word word in _words)
            {
                displayWords.Add(word.GetDisplayText());
            }
            return string.Join(" ", displayWords);
        }

        public void HideRandomWords(int count)
        {
            List<Word> visibleWords = _words.Where(w => !w.IsHidden()).ToList();

            List<Word> shuffled = visibleWords.OrderBy(_ => _random.Next()).ToList();

            int hideCount = Math.Min(count, shuffled.Count);
            for (int i = 0; i < hideCount; i++)
            {
                shuffled[i].Hide();
            }
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }
}
