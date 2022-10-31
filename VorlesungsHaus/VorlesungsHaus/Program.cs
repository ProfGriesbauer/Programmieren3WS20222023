// See https://aka.ms/new-console-template for more information
using VorlesungsHaus;

VorlesungsHaus.Haus myHouse1 = VorlesungsHaus.StaticHausFactory.CreateHaus(44);
VorlesungsHaus.Haus myHouse2 = new VorlesungsHaus.Haus(-66);
VorlesungsHaus.Garage myGarage1 = new VorlesungsHaus.Garage();
VorlesungsHaus.IRaum itfRaum = new VorlesungsHaus.Raum();

Console.WriteLine("Hello, World! {0:F}", myHouse1.StromV);
myHouse1.StromAn = false;
myHouse1.HausGarage.GarageTorAuf = true;
Console.WriteLine(myHouse1.HeizungAn);
myHouse1.HeizungAn = true;
Console.WriteLine(myHouse1.HeizungAn);
try
{
    myHouse1.StromAn = true;
    myHouse1.HeizungAn = true;
    Console.WriteLine(myHouse1.HeizungAn);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
myGarage1.GarageTorAuf = true;
Console.WriteLine(myGarage1.Licht);

if (myHouse1 == myHouse2)
//gleich if (myHouse1.CompareTo(myHouse2) > 0)
{
    //...
}

foreach (VorlesungsHaus.IRaum r in myHouse1)
{
    if (r is IRaumJalousie)
    {
        Console.WriteLine(((IRaumJalousie)r).Jalousie);
    }
    else if (r is RaumNass)
    {
        Console.WriteLine(((IRaumNass)r).WasserVerbrauch);
    }
    Console.WriteLine(r.Temperatur);
}
