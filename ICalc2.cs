using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceICalc
{
    internal interface ICalc2
    {
        int CountDistinct();// — повертає кількість унікальних значень у контейнері даних;
        int EqualToValue(int valueToCompare);// — повертає кількість значень, рівних valueToCompare.

    }
}
