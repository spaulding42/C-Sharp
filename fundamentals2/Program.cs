

// 1)---------------
static void PrintNumbers(int start = 1, int end = 255)
{
    for(int i = start; i<= end; i++ )
    {
        Console.WriteLine(i);
    }
}

PrintNumbers();


// 2)----------------------
static void PrintOdds(int start = 1, int end = 255)
{
    if(start%2 == 0)
    {
        // if it is an even number to start increment by 1 so it becomes an odd number
        Console.WriteLine("start wasn't odd");
        start++;
    }
    // increment by 2 to improve efficiency
    for(int i = start; i <= end; i=i+2)
    {
        Console.WriteLine(i);
    }
}

PrintOdds(0,255);

// 3) ------------------------
static void PrintSum(int start = 1, int end = 255)
{
    int sum = 0;
    for(int i = start; i<=end; i++)
    {
        // Console.WriteLine(i);
        sum += i;
        Console.WriteLine($"New number: {i} Sum: {sum}");
    }
}

PrintSum();
int[] arr = new int[] {-3,-5,-7,3,0,8};
// 4)---------------------------
static void LoopArray(int[] numbers)
{
    foreach (var num in numbers)
    {
        Console.WriteLine(num);
    }
}

LoopArray(arr);

// 5)------------------------
static int FindMax(int[] numbers)
{
    int max = numbers[0];
    foreach(int num in numbers)
    {
        if (num > max)
        {
            max = num;
        }
    }
    return max;
}


Console.WriteLine(FindMax(arr));


// 6) get Average -----------------------
static void GetAverage(int[] numbers)
{
    int sum = 0;
    for(int i = 0; i < numbers.Length; i++)
    {
        sum += numbers[i];
    }
    double avg = sum/numbers.Length;
    Console.WriteLine(avg);
}

GetAverage(arr);


// 7) list with odd numbers --------------
static List<int> OddList(int start = 1, int end = 255)
{
    List<int> oddList = new List<int> ();

    if(start%2 == 0)
    {
        // if it is an even number to start increment by 1 so it becomes an odd number
        Console.WriteLine("start wasn't odd");
        start++;
    }
    // increment by 2 to improve efficiency
    for(int i = start; i <= end; i=i+2)
    {
        oddList.Add(i);
    }
    return oddList;
}

List<int> oddList = OddList();
foreach(int num in oddList)
{
    Console.WriteLine(num);
}


// 8) Greater than Y ----------------------------
List<int> greaterYList = new List<int>() {1,3,5,7,9,1};
static int GreaterThanY(List<int> numbers, int y)
{
    int greaterSum = 0;
    foreach(int num in numbers)
    {
        if (num > y)
        {
            greaterSum++;
        }
    }
    return greaterSum;
}

Console.WriteLine(GreaterThanY(greaterYList,3));

// 9) Square the Values ---------------------------
List<int> notSquareNums = new List<int> {1,5,10,-10};
static void SquareArrayValues(List<int> numbers)
{
    for(int i = 0; i < numbers.Count; i ++)
    {
        numbers[i] *= numbers[i];
    }
    foreach(int num in numbers)
    {
        Console.WriteLine(num);
    }
}

SquareArrayValues(notSquareNums);

// 10) Eliminate Negative Numbers ------------------
List<int> noNegs = new List<int> {1,5,10,-2};
static void EliminateNegatives(List<int> numbers)
{
    for(int i = 0; i < numbers.Count; i++)
    {
        if(numbers[i]<0)
        {
            numbers[i] = 0;
        }
    }
    // Console.WriteLine(numbers);
    foreach(int num in numbers)
    {
        Console.WriteLine(num);
    }
}

EliminateNegatives(noNegs);