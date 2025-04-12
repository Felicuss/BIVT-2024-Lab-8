using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public abstract class Purple
    {
        private string _input;
        public string Input => _input;
        public Purple(string name)
        {
            if (name == null) return;
            _input = name;
        }
        public abstract void Review();
    }
}
