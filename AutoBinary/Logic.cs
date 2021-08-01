using System;
using System.Text;

namespace AutoBinary
{
    public class Logic
    {
        private int _size;
        private bool[] _arr;
        private bool[] _rule = new bool[8];
        static Random random = new Random();

        public Logic(int size)
        {
            _size = size;
            _arr = new bool[size];
        }

        
        public void SetRandom()
        {
            for (int i = 0; i < _size; i++)
                _arr[i] = random.Next(0,2) == 1;
        }
        
        public void SetMiddleOne()
        {
            for (int i = 0; i < _size; i++)
                _arr[i] = false;
            _arr[_size / 2] = true;
        }

        public void SetRule(int nr)
        {
            for (int i = 0; i < 8; i++)
            {
                _rule[i] = (nr % 2 == 1);
                nr /= 2;
            }
        }

        public void Next()
        {
            bool[] nextArr = new bool[_size];
            for (int i = 0; i < _size; i++)
            {
                int cat = 4 * (_arr[(i - 1 + _size) % _size] ? 1 : 0) +
                          2 * (_arr[i                      ] ? 1 : 0) +
                          1 * (_arr[(i + 1) % _size        ] ? 1 : 0);
                nextArr[i] = _rule[cat];
            }

            for (int i = 0; i < _size; i++)
                _arr[i] = nextArr[i];
        }

        public void Change()
        {
            int nr = random.Next(0, _size);
            _arr[nr] = !_arr[nr];
        }
        
        public void ChangeRule()
        {
            int nr = random.Next(0, 8);
            _rule[nr] = !_rule[nr];
        }
        public string Life()
        {
            StringBuilder sb = new StringBuilder(_size);
            for (int i = 0; i < _size; i++)
                sb.Append(_arr[i] ? "#" : ".");
            return sb.ToString();
        }
        
    }
}