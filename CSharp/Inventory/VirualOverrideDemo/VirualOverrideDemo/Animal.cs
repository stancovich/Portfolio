using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirualOverrideDemo
{
    internal class Animal
    {
        public Animal()
        {
            Age = 0;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsHungry { get; set; }

        public Animal (string name, int age = 0)
        {
            Name = name;
            Age = age;
            IsHungry = true;
        }

        public virtual void MakeSound()
        {

        }

        public virtual void Eat()
        {
            if (IsHungry)
            {
                Console.WriteLine($"{Name} is eating");
            }
            else
            {
                Console.WriteLine($"{Name} is not hungry");
            }
        }
        public virtual void Play()
        {
            Console.WriteLine($"{Name} is playing");
        }
    }
}
