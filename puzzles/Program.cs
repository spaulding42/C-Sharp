
// Random Array
static int[] RandomArray()
{
    int[] arr = new int[10];
    for(int i = 0; i < 10; i++)
    {
        Random rand = new Random();
        arr[i] = rand.Next(5,26);
    }
    int min = 25;
    int max = 5;
    foreach(int num in arr)
    {
        if(num < min)
        {
            min = num;
        }
        if(num > max)
        {
            max = num;
        }
    }
    Console.WriteLine($"Min is: {min} Max is: {max}");
    return arr;
}

int[] ranSum = RandomArray();
int sumOfRanSum = 0;
foreach(int num in ranSum)
{
    sumOfRanSum += num;
}
Console.WriteLine($"Sum of all the Values: {sumOfRanSum}");



// Coin Flip
static string TossCoin()
{
    Random rand = new Random();
    int result = rand.Next(2);
    if(result == 0)
    {
        return "Heads";
    }
    return "Tails";
}

Console.WriteLine(TossCoin());


static double TossMultipleCoins(int num)
{
    int heads = 0;
    int tails = 0;
    
    for(int i = 0; i<num;i++)
    {
        string toss = TossCoin();
        if (toss == "Heads")
        {
            heads ++;
            Console.WriteLine($"Heads count: {heads}");
        }
        else
        {
            tails ++;
            Console.WriteLine($"Tails count: {tails}");
        }
    }
    double ratio = (double)heads/num;
    return ratio;
    
}

double ratio = TossMultipleCoins(5);
Console.WriteLine($"Ratio of heads tossed to total tossed: {ratio}");


// Names -------------------------------
static List<string> Names()
{
    List<string> names = new List<string>() {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
    List<string> filteredNames = new List<string>();
    foreach(string name in names)
    {
        if (name.Length > 5)
        {
            filteredNames.Add(name);
        }
    }
    return filteredNames;
}

List<string> longNames = Names();
// foreach(string name in longNames)
// {
//     Console.WriteLine(name);
// }

// shuffle list
Console.WriteLine("Randomizing list...");

List<string> newOrder = new List<string>();
List<bool> pickedSoFar = new List<bool>() {false,false,false,false};
while (newOrder.Count < longNames.Count)
{
    Random rand = new Random();
    int next = rand.Next(4);
    if (pickedSoFar[next] == false)
    {
        pickedSoFar[next] = true;
        newOrder.Add(longNames[next]);
    }
}

foreach(string name in newOrder)
{
    Console.WriteLine(name);
}