using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        private string _output;
        public string Output => _output;
        private char[] punctuation = { '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };

        public Purple_1(string input) : base(input)
        {

        }
        public override void Review()
        {
            if (Input == null)
            {
                return;
            }
            string[] words = Input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                bool flag = false;
                foreach (char c in word)
                {
                    if (Char.IsDigit(c)) { flag = true; break; }
                }
                if (flag) { continue; }

                char[] chars = word.ToCharArray();

                var indexOfnormalChars = word
                    .Select((c, index1) => new { Char = c, Index = index1 })
                    .Where(x => !punctuation.Contains(x.Char))
                    .Select(x => x.Index)
                    .ToArray();
                char[] reversedLetters = indexOfnormalChars
                    .Select(x => chars[x])
                    .Reverse()
                    .ToArray();
                for (int j = 0; j < indexOfnormalChars.Length; j++)
                {
                    chars[indexOfnormalChars[j]] = reversedLetters[j];
                }
                words[i] = new string(chars);

            }
            _output = String.Join(" ", words);
        }
        public override string ToString()
        {
            return Output;
        }

    }
}
