using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_3 : Purple
    {
        private string _output;
        private (string, char)[] _codes;

        public string Output => _output;
        public (string, char)[] Codes => _codes;

        public Purple_3(string input) : base(input)
        {

        }

        public override void Review()
        {
            if (Input == null) return;
            if (Input == "")
            {
                _output = "";
                _codes = new (string, char)[0];
                return;
            }
            var charsOfString = Input.ToCharArray();
            var allcouples = new string[Input.Length - 1];
            for (int i = 0; i < Input.Length - 1; i++)
            {
                allcouples[i] = Input[i].ToString() + Input[i + 1].ToString();
            }
            var sortedAllcouples = allcouples
                .Where(x => Char.IsLetter(x[0]) && Char.IsLetter(x[1]))
                .GroupBy(x => x)
                .Select(y => new { Name = y.Key, Count = y.Count() })
                .OrderByDescending(x => x.Count)
                .Select(y => y.Name)
                .ToArray();
            int k = 0;
            _codes = new (string, char)[5];
            _output = Input;
            for (int i = 32; i < 127; i++)
            {
                if (k == 5) break;
                if (Input.Contains((char)i) == false)
                {
                    _codes[k] = (sortedAllcouples[k], (char)i);
                    _output = _output.Replace(sortedAllcouples[k], ((char)i).ToString());
                    k++;
                }
            }
        }

        public override string ToString()
        {
            return _output;
        }
    }
}
