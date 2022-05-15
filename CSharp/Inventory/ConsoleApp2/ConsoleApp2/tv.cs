using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class tv : ElectricalDevice
    {
        public tv(bool isOn, string brand) : base(isOn, brand)
        {

        }

        public void ListenTV()
        {
            if (IsOn)
            {
                Console.WriteLine("Watching the TV");
            }
            else
            {
                Console.WriteLine("TV is switched off, switch it on to watch");
            }
        }
    }
}

