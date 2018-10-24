using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabInheritance
{
    class Dog : Pet
    {
        public Dog(string name)
            : base(name)
        {
        }

        public override string Communicate()
        {
            return "bark";
        }

    }
}
