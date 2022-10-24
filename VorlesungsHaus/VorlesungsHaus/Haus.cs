using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorlesungsHaus
{
    public class Haus
    {
        float _StromV;
        float _WasserV;
        float _HeizungsV;

        bool _HeizungAn;
        bool _StromAn;

        public Haus (float strom)
        {
            _StromV = strom;
        }

        public float StromV
        {
            get { return _StromV; }
            /*set 
            {
                if (value < 2000.0)
                {
                    _StromV = value;
                }
            }*/
        }

        public float WasserV
        { get { return _WasserV; } }

        public float HeizungsV
        { get { return _HeizungsV; } }

        public bool StromAn
        {
            get { return _StromAn; }
            set
            {
                _StromAn = value;
                if (!value)
                {
                    _HeizungAn = false;
                }
            }
        }

        public bool HeizungAn
        { get { return _HeizungAn; }
            set
            {
                if (_StromAn)
                {
                    _HeizungAn=true;
                }
            }
        }

        public float WasserverbrauchÜberZeit (float Stunden)
        {
            return Stunden * _WasserV;
        }

        /*Das gleiche wie oben nur anders
        public float getStromV ()
        {
            return _StromV;
        }
        
        public void setStromV(float stromV)
        {
            _StromV = stromV;
        }*/
    }
}
