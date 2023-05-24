using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceICalc
{
    internal interface ICalc
    {
        int Less(int valueToCompare);// — повертає кількість менших значень, ніж valueToCompare;

        int Greater(int valueToCompare); // — повертає кількість більших значень, ніж valueToCompare.
  
    }
}
