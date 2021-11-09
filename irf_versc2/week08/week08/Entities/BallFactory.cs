using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week08.Entities
{
    class BallFactory
    {
        public Ball CreateNew()
        {
            return new Ball();
        }
    }
}
