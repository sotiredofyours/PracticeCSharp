using System;

namespace tamagotchi
{
    public class Cat : Animal
    {
        public Cat(string name) : base(name)
        {
        }
        public override void Voice()
        {
            System.Console.WriteLine("MEOW");
        }
    }
}