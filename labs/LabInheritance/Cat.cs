using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabInheritance
{
    class Cat : Pet
    {
        public Cat(string name)
            : base(name)
        {
        }

        public override string Communicate()
        {
            return "meow";
        }
    }
}
