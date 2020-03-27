using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace KeyboardSimulator
{
    class Program
    {
        static Options options;
        static void Main(string[] args)
        {
            LoadOptions(args);
            SimulateKeyPres(options.Keys.Split(',').Select(z => int.TryParse(z, out int k) ? k : -1).Where(z => z != -1));
          
        }
        static void SimulateKeyPres(IEnumerable<int> keys)
        {
            InputSimulator sim = new InputSimulator();

            foreach (var key in keys)
            {
                sim.Keyboard.KeyDown((VirtualKeyCode)key);
            }
            sim.Keyboard.Sleep(100);

            foreach (var key in keys)
            {
                sim.Keyboard.KeyUp((VirtualKeyCode)key);
            }
          
        }
        static void LoadOptions(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsed(o=>options=o);
        }
    }
}
