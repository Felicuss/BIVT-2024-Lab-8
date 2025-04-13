using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2 : Purple
    {
        private string[] _output;
        public string[] Output => _output;
        public Purple_2(string input) : base(input)
        {

        }
        public override void Review()
        {
            if (Input == null) return;
            if (Input.Length == 0)
            {
                _output = new string[0];
                return;
            }
            string[] words = Input.Split(' ');

            int countLines = 1;
            string line = words[0];

            for (int i = 1; i < words.Length; i++)
            {
                string word = words[i];
                if (line.Length + word.Length + 1 <= 50)
                {
                    line = line + " " + word;
                }
                else
                {
                    countLines++;
                    line = word;
                }
            }

            _output = new string[countLines];
            int index = 0;
            line = words[0];

            for (int i = 1; i < words.Length; i++)
            {
                string word = words[i];
                if (line.Length + word.Length + 1 <= 50)
                {
                    line = line + " " + word;
                }
                else
                {
                    int countSpaces = 50 - line.Length;
                    string[] listOfLine = line.Split(' ');
                    var new_word = "";
                    for (int j = 0; j < countSpaces; j++)
                    {
                        listOfLine[j % (listOfLine.Length - 1)] += " ";
                    }
                    new_word = string.Join(" ", listOfLine);
                    _output[index++] = new_word;
                    line = word;
                }
            }

            string[] lastLineWords = line.Split(' ');
            if (lastLineWords.Length == 1)
            {
                _output[index] = lastLineWords[0];
            }
            else
            {
                int countSpaces = 50 - line.Length;
                for (int j = 0; j < countSpaces; j++)
                {
                    lastLineWords[j % (lastLineWords.Length - 1)] += " ";
                }
                _output[index] = string.Join(" ", lastLineWords);
            }
        }

        public override string ToString()
        {
            if (Output == null) return null;

            return string.Join("\r\n", Output);
        }


    }
}