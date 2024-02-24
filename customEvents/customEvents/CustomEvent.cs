using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customEvents

{
    public partial class CustomEvent
    {
        public CustomEvent()
        {
            //Console.WriteLine("heoo");
            Form1.CustomEvent1 += MyCustomEvent;

        }
        public string MyCustomEvent(object sender, string str1)
        {
            //Console.WriteLine("success");
            //Console.WriteLine(str1);
            return str1;
        }

    }
}
