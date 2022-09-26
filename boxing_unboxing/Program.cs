List<object> newList = new List<object>();
newList.Add(7);
newList.Add(28);
newList.Add(-1);
newList.Add(true);
newList.Add("chair");

int sum = 0;

foreach (var item in newList)
{
    Console.WriteLine(item);
    if(item is int){
        int newInt = (int)item;
        sum = sum + newInt;
    }
}

Console.WriteLine(sum);
