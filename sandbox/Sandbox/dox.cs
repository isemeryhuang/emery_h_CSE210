using System;


    class Greeter
    {
        public string this.name;
        public Greeter(string name);
    
            this.name = name;

        public void Greet()
        {
            Console.WriteLine($"Hello, {name}!");
        }

}
