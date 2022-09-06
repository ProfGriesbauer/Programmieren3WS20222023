using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseExample
{
    public class House
    {
        float _StromV;
        float _WasserV;
        float _HeizungsV;

        bool _HeizungAn;
        bool _StromAn;

        List<IRoom> _Rooms = new List<IRoom>();

        public House (float stromV, float wasserV, float heizungsV)
        {
            _StromV = stromV;
            _WasserV = wasserV;
            _HeizungsV = heizungsV;
            _HeizungAn = true;
            _StromAn = true;

            _Rooms.Add(HouseExample.RoomFabric.CreateRoom(true, 20, 0));
            _Rooms.Add(HouseExample.RoomFabric.CreateRoom(true, 21, 0));
            _Rooms.Add(HouseExample.RoomFabric.CreateRoom(false, 24, 1));
            _Rooms.Add(HouseExample.RoomFabric.CreateRoom(false, 25, 2));
        }

        public List<IRoom> Rooms
        {
            get { return _Rooms; }
        }

        public float Stromverbrauch
        {
            get { return _StromV; }
        }

        public float Wasserverbrauch
        {
            get { return _WasserV; }
        }

        public float Heizungsleistung
        {
            get { return _HeizungsV; }
        }

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
        {
            get { return _HeizungAn; }
            set 
            {
                if (_StromAn)
                {
                    _HeizungAn = value;
                }
            }
        }

        public float WassermengeUberZeit (float Stunden)
        {
            return Stunden * _WasserV;
        }
    }
}
