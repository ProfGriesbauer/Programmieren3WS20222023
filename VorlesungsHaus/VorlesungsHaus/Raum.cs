using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorlesungsHaus
{
    public interface IRaum : ISerializeable
    {
        public bool Licht { get; set; }

        public float Temperatur { get; set; }
    }

    public interface IRaumJalousie : IRaum
    {
        public bool Jalousie { get; set; }
    }

    public interface IRaumNass: IRaum
    {
        public float WasserVerbrauch { get; set; }
    }

    public abstract class Schaltraum : IRaum
    {
        bool _Licht;
        float _Temperatur;

        public Schaltraum (bool licht, float temperatur)
        {
            Licht = licht;
            Temperatur = temperatur;
        }

        public bool Licht
        {
            get
            {
                return _Licht;
            }
            set
            {
                _Licht = value;
            }
        }
        public float Temperatur
        {
            get
            {
                return _Temperatur;
            }
            set
            {
                _Temperatur = value;
            }
        }

        public abstract void AllesAus();

        public ISerializeable Deserialize(string stObj)
        {
            throw new NotImplementedException();
        }

        public string Serialize()
        {
            return "Ich bin ein Raum";
        }
    }


    public class Raum : Schaltraum, IRaum
    {
        public Raum () : base(false, 20)
        {

        }
        public override void AllesAus()
        {
            Licht = false;
            Temperatur = 19;
        }
    }

    public class RaumNass : Schaltraum, IRaumNass
    {
        float _WasserV = 23.0f;

        public RaumNass() : base(false, 20)
        {

        }
        public float WasserVerbrauch
        {
            get { return _WasserV; }
            set { _WasserV = value; }
        }

        public override void AllesAus()
        {
            Licht = false;
            Temperatur = 19;
            WasserVerbrauch = 0;
        }
    }

    public class RaumJalousie : Raum, IRaumJalousie
    {
        bool _Jalousie;
        public bool Jalousie 
        { get { return _Jalousie; }
          set { _Jalousie = value; }
        }
    }

}
