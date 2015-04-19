using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeMeBad
{
        interface INode<T>
    {
        int  id { get; }
        T key { get; set; }
        int path { get; set; }
    }
}
