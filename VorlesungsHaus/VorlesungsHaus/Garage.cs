using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorlesungsHaus
{
    public class Garage
    {
        bool _GarageTorAuf;
        bool _Licht;

        public bool GarageTorAuf
        {
            get 
            { 
                return _GarageTorAuf; 
            }
            set
            { 
                _GarageTorAuf = value;
                _Licht = true;
            }
        }

        public bool Licht
        {
            get { return _Licht; }
            set { _Licht = value; }
        }

    }
}
