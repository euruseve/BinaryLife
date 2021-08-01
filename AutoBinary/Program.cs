using System;
using System.Threading;

namespace AutoBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Start();
        }

        public void Start()
        {
            Logic logic = new Logic(79);
            logic.SetRandom();
            logic.SetRule(161);
            int nr = 0;
            while (true)
            {
                //Console.SetCursorPosition(0, 0);
                if(nr++ % 25 == 0)
                    logic.ChangeRule();
                Console.WriteLine(logic.Life());
                logic.Next();
                Thread.Sleep(100);
            }
        }
    }
}