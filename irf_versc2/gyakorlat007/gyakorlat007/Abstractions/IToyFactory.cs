using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyakorlat007.Abstractions
{
    public interface IToyFactory
    {   
        //mindig public
        Toy CreateNew();
    }
}
