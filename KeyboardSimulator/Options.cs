using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardSimulator
{
    public class Options
    {
        [Option('k', "keys", Required = true, HelpText = "Combination of keys to be pressed.")]
        public string Keys { get; set; }
    }

}
