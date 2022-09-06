using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseExample
{
    public static class RoomFabric
    {
        public static IRoom CreateRoom (bool jalousieorwet, float temperature, float wasserV)
        {
            if (jalousieorwet)
            {
                return new RoomJalousie(false, temperature, true);
            }
            else
            {
                return new RoomWet(false, temperature, wasserV);
            }
        }
    }

    public interface IRoom
    {
        public bool RoomLight { get; set; }

        public float RoomTemp { get; set; }
    }

    public interface IRoomJalousie : IRoom
    {
        public bool JalousieOpen { get; set; }
    }

    public interface IRoomWet : IRoom
    {
        public float Wasserverbrauch { get; }
    }
    
    public abstract class Room : IRoom
    {
        //Erweiterung z.B. durch Klassen für jedes einzelne Licht!
        bool _RoomLight;
        float _RoomTemp;

        public Room (bool roomLight, float roomTemp)
        {
            _RoomLight = roomLight;
            _RoomTemp = roomTemp;
        }

        public bool RoomLight 
        { 
            get { return _RoomLight; } 
            set { _RoomLight = value; } 
        }

        public float RoomTemp
        {
            get { return _RoomTemp; }
            set { _RoomTemp = value; }
        }

        public abstract void EverythingOffOrDown();
    }

    public class RoomJalousie : Room, IRoomJalousie
    {
        bool _Jalousie;
        public RoomJalousie(bool roomLight, float roomTemp, bool jalousie) : base(roomLight, roomTemp)
        {
            _Jalousie = jalousie;
        }
        public bool JalousieOpen { get { return _Jalousie; } set { _Jalousie = value; } }

        public override void EverythingOffOrDown()
        {
            JalousieOpen = false;
            RoomLight = false;
        }
    }

    public class RoomWet : Room, IRoomWet
    {
        float _WasserV;
        public RoomWet(bool roomLight, float roomTemp, float wasserV) : base(roomLight, roomTemp)
        {
            _WasserV = wasserV;
        }

        public float Wasserverbrauch { get { return _WasserV; } }

        public override void EverythingOffOrDown()
        {
            RoomLight = false;
        }
    }
}
