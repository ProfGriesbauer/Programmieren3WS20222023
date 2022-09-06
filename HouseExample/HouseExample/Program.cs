HouseExample.House MyHouse = new HouseExample.House(5, 7, 10);
Console.WriteLine("MyHouse verbraucht {0:F} A an Strom, {1:F} m^3/h an Wasser und {2:F} kWh an Heizleistung", 
    MyHouse.Stromverbrauch, MyHouse.Wasserverbrauch, MyHouse.Heizungsleistung);
Console.WriteLine("Wassermenge in 2 Stunden: {0:F}", MyHouse.WassermengeUberZeit(2));

MyHouse.StromAn = false;
Console.WriteLine(MyHouse.HeizungAn);
MyHouse.HeizungAn = true;
Console.WriteLine(MyHouse.HeizungAn);
MyHouse.StromAn = true;
MyHouse.HeizungAn = true;
Console.WriteLine(MyHouse.HeizungAn);

int i = 0;
foreach (HouseExample.IRoom room in MyHouse.Rooms)
{
    i++;
    if (room is HouseExample.IRoomJalousie)
    {
        Console.WriteLine("Raum {0:D} hat eine Jalousie ({2:G}) und Temperatur {1:F}", 
            i, room.RoomTemp, ((HouseExample.IRoomJalousie)room).JalousieOpen);
    }
    else if (room is HouseExample.IRoomWet)
    {
        Console.WriteLine("Raum {0:D} hat eine Wasserverbrauch ({2:F}) und Temperatur {1:F}", 
            i, room.RoomTemp, ((HouseExample.IRoomWet)room).Wasserverbrauch);
    }
    else
    {
        Console.WriteLine("Raum {0:D} hat Temperatur {1:F}", i, room.RoomTemp);
    }
}


