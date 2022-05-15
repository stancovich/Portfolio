using System;


namespace ConsoleApp2
{
    internal class Radio : ElectricalDevice
    {

        public Radio (bool isOn, string brand):base (isOn, brand)
        {

        }

        public void ListenRadio()
        {
            if (IsOn)
            {
                Console.WriteLine("Listening to the radio");
            }
            else
            {
                Console.WriteLine("Radio is switched off, switch it on to listen");
            }
        }
    }
}
