List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
 

Console.WriteLine("1:");
// 1) Use LINQ to find the first eruption that is in Chile and print the result.
Eruption? firstEruptC = eruptions.FirstOrDefault(erupt => erupt.Location == "Chile");
if(firstEruptC != null) Console.WriteLine(firstEruptC.ToString());

Console.WriteLine("2:");
// 2) Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
Eruption? firstEruptH = eruptions.FirstOrDefault(erupt => erupt.Location == "Hawaiian Is");
if(firstEruptH != null) Console.WriteLine(firstEruptH.ToString());
else Console.WriteLine("No Hawaiian Is Eruption found");

Console.WriteLine("3:");
// 3)  Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Eruption? firstEruptAfterNZ = eruptions.FirstOrDefault(erupt => erupt.Year > 1900 && erupt.Location == "New Zealand");
if (firstEruptAfterNZ != null) Console.WriteLine(firstEruptAfterNZ.ToString());

Console.WriteLine("4:");
// 4) Find all eruptions where the volcano's elevation is over 2000m and print them.
List<Eruption> filteredList = eruptions.Where(erupt => erupt.ElevationInMeters > 2000).ToList();
PrintEach(filteredList);

Console.WriteLine("5:");
// 5) Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
filteredList = eruptions.Where(erupt => erupt.Volcano.StartsWith("L")).ToList();
PrintEach(filteredList);

Console.WriteLine("6:");
// 6) Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
int max = eruptions.Max(erupt => erupt.ElevationInMeters);
Console.WriteLine($"Highest elevation of any volcano on list: {max}");

Console.WriteLine("7:");
// 7) Use the highest elevation variable to find a print the name of the Volcano with that elevation.
string? maxEruption = eruptions.FirstOrDefault(erupt => erupt.ElevationInMeters == max).Volcano;
if(maxEruption!= null) Console.WriteLine($"{maxEruption} is the name of the highest volcano");


Console.WriteLine("8:");
// 8) Print all Volcano names alphabetically.
List<Eruption> sortedList = eruptions.OrderBy(erupt => erupt.Volcano).ToList();
PrintEach(sortedList);

Console.WriteLine("9:");
// 9) Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
filteredList = eruptions.Where(erupt =>erupt.Year < 1000).OrderBy(erupt =>erupt.Volcano).ToList();
PrintEach(filteredList);

Console.WriteLine("10:");
// 10) BONUS: Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
List<string> names = filteredList.Select(name=>name.Volcano).ToList();
PrintEach(names);





// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}