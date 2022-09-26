int[] numbers;
numbers = new int[] {0,1,2,3,4,5,6,7,8,9};
string[] names;
names = new string[] {"Tim", "Martain" , "Nikki", "Sara"};

bool[] trueOrFalse;
trueOrFalse = new bool[] {true, false, true,false,true,false,true,false,true,false};

List<string> flavors = new List<string>();
flavors.Add("Cookies n' Cream");
flavors.Add("Pralines n' Cream");
flavors.Add("Chocolate");
flavors.Add("Vanilla");
flavors.Add("Rocky Road");
Console.WriteLine(flavors.Count);

Console.WriteLine(flavors[2]);

flavors.RemoveAt(2);

Console.WriteLine(flavors.Count);

Dictionary<string,string> userInfo = new Dictionary<string,string>();
foreach(string name in names)
{
    Random rand = new Random();
    int favFlav = rand.Next(flavors.Count);
    userInfo.Add(name, flavors[favFlav]);
}

foreach (KeyValuePair<string,string> user in userInfo)
{
    Console.WriteLine(user.Key + " likes " + user.Value + " flavored ice cream");
}