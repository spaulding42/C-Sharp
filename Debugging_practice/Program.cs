// Challenge 1
// bool amProgrammer = true; // not "true" needs to be true    never used
// int Age = 27; // not 27.9 needs to be an int so just 27     never used
List<string> Names = new List<string>();
Names.Add("Monica");   // needs to be names.Add not just names     never used
Dictionary<string, string> MyDictionary = new Dictionary<string, string>();
MyDictionary.Add("Hello", "0");
MyDictionary.Add("Hi there", "0"); // not an int 0 needs to be string '0'
// This is a tricky one! Hint: look up what a char is in C#
// string MyName = "MyName";
// Challenge 2
List<int> Numbers = new List<int>() {2,3,6,7,1,5};
for(int i = Numbers.Count -1; i >= 0; i--) //          number.count -1
{
    Console.WriteLine(Numbers[i]);
}
// Challenge 3 
List<int> MoreNumbers = new List<int>() {12,7,10,-3,9};
foreach(int i in MoreNumbers)
{
    Console.WriteLine(i);  // changed from (MoreNumbers[i]) because in this case i holds the value it is iterating through
}
// Challenge 4
List<int> EvenMoreNumbers = new List<int> {3,6,9,12,14};
for (int num = 0; num < EvenMoreNumbers.Count;num++)  //hat to change to a regular for loop so we can change the values stored in EvenMoreNumbers
{
    if(EvenMoreNumbers[num] % 3 == 0)
    {
        EvenMoreNumbers[num] = 0;
    }
        Console.WriteLine($"number: {EvenMoreNumbers[num]}");
}
// Challenge 5
// What can we learn from this error message?
string MyString = "superduberawesome";
MyString.Insert(7,"p");
// Challenge 6
// Hint: some bugs don't come with error messages
Random rand = new Random();
int randomNum = rand.Next(12);  //would have never said hello since rand.Next(12) will exclude 12 so had to make the if be 11
if(randomNum == 11)
{
    Console.WriteLine("Hello");
}
Console.WriteLine(randomNum);