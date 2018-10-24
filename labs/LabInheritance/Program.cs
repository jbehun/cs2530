using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabInheritance
{
    public class Program
    {
        public static void Main()
        {
            Pet myPet = new Pet("Furry");
            Console.WriteLine("{0}", myPet);

            Dog myDog = new Dog("Snoopy");
            Console.WriteLine("{0}", myDog);

            Cat myCat = new Cat("Sylveter");
            Console.WriteLine("{0}", myCat);

            Pet[] petArray = { myPet, myDog, myCat };

            foreach(Pet el in petArray)
            {
                Console.WriteLine("{0} ,{1}", el, el.Communicate() );
            }

        }
    }
}