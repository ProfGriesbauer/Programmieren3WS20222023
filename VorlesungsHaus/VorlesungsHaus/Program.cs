// See https://aka.ms/new-console-template for more information
VorlesungsHaus.Haus myHouse1 = new VorlesungsHaus.Haus(45);
VorlesungsHaus.Haus myHouse2 = new VorlesungsHaus.Haus(66);

Console.WriteLine("Hello, World! {0:F}", myHouse1.StromV);
myHouse1.StromAn = false;
Console.WriteLine(myHouse1.HeizungAn);
myHouse1.HeizungAn = true;
Console.WriteLine(myHouse1.HeizungAn);
myHouse1.StromAn = true;
myHouse1.HeizungAn = true;
Console.WriteLine(myHouse1.HeizungAn);
