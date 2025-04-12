using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_4 : Purple
    {
        private string _output;
        private (string, char)[] _codes;
        public string Output => _output;
        public Purple_4(string input, (string, char)[] codes) : base(input)
        {
            if (codes == null) return;
            _codes = ((string, char)[])codes.Clone();
        }
        public override void Review()
        {
            if (Input == null || _codes == null || _codes.Any(x => x.Item1 == null)) return;
            _output = Input;
            for (int i = 0; i < _codes.Length; i++)
            {
                _output = _output.Replace(((char)_codes[i].Item2).ToString(), _codes[i].Item1);
            }
        }
        public override string ToString()
        {
            return _output;
        }

    }
}
