using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VorlesungsHaus
{
    public interface ISerializeable
    {
        //Gibt Daten des Objekts als String zurück
        string Serialize();

        //Baut ein Objekt aus den im String übergebenen Daten
        ISerializeable Deserialize(string stObj);
    }
    
    public static class StaticHausFactory
    {
        public static Haus CreateHaus (float wasserV)
        { 
            Haus ret = new Haus (0);
            ret.WasserV = wasserV;
            return ret;
        }
    }

    public class Haus : ISerializeable, IEnumerable<IRaum>, IEnumerator<IRaum>, IComparable<Haus>
    {
        float _StromV;
        float _WasserV;
        float _HeizungsV;

        bool _HeizungAn;
        bool _StromAn;

        Garage _Garage = new Garage();

        IList<IRaum> _Raume = new List<IRaum>();

        public EventHandler hausbrennt;

        public Haus (float strom)
        {
            Debug.Assert(strom >= 0);

            _StromV = strom;
            _Raume.Add(new VorlesungsHaus.Raum());
            _Raume.Add(new VorlesungsHaus.RaumNass());
            _Raume.Add(new VorlesungsHaus.Raum());
            _Raume.Add(new VorlesungsHaus.RaumNass());
            _Raume.Add(new VorlesungsHaus.Raum());
            _Raume.Add(new VorlesungsHaus.Raum());

            hausbrennt += ichbrenne;

            foreach (IRaum r in _Raume)
            {
 
            }
        }

        public void ichbrenne (object sender, EventArgs args)
        {
            //Um himmels willen das haus brennt
        }

        public IList<IRaum> Raume
        {
            get { return _Raume; }
        }

        public Garage HausGarage
        {
            get { return _Garage; }
        }

        public float StromV
        {
            get 
            { 
                if (_StromV > 1000)
                {
                    hausbrennt(this, new EventArgs());
                }
                return _StromV;
            }
            /*set 
            {
                if (value < 2000.0)
                {
                    _StromV = value;
                }
            }*/
        }

        public float WasserV
        { get { return _WasserV; }
            set { _WasserV = value; } }

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

                if (value)
                {
                    throw new Exception("Meine Ausnahme!");
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

        public IRaum Current
        {
            get { return _Raume.GetEnumerator().Current; }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public int CompareTo(Haus? other)
        {
            return 0;
        }

        public ISerializeable Deserialize(string stObj)
        {
            Haus ret = new Haus(5);
            string[] stObjAry = stObj.Split('|');
            ret._StromV = float.Parse(stObjAry[0]);
            //..
            return ret;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IRaum> GetEnumerator()
        {
            return _Raume.GetEnumerator();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public string Serialize()
        {
            string ret = "";
            ret = ret + "|"+_StromV;
            ret = ret + "|"+_HeizungsV;
            //...
            foreach (IRaum r in _Raume)
            {
                ret = ret + r.Serialize();
            }

            return ret;
        }

        public float WasserverbrauchÜberZeit (float Stunden)
        {
            return Stunden * _WasserV;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
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
