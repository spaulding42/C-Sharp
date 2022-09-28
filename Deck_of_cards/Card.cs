public class Card
{
    string Name;
    string Suit;
    int Val;

    public Card(string suit, int val)
    {
        Name = getName(val);
        Suit = suit;
        Val = val;
    }
    public void Print()
    {
        Console.WriteLine($"{Name} of {Suit} has a value of {Val}");
    }
    public string getCardString()
    {
        return $"{Name} of {Suit} has a value of {Val}";
    }
    private string getName(int val)
    {
        if(val == 1) return "Ace";
        if(val == 2) return "Two";
        if(val == 3) return "Three";
        if(val == 4) return "Four";
        if(val == 5) return "Five";
        if(val == 6) return "Six";
        if(val == 7) return "Seven";
        if(val == 8) return "Eight";
        if(val == 9) return "Nine";
        if(val == 10) return "Ten";
        if(val == 11) return "Jack";
        if(val == 12) return "Queen";
        return "King";
    }
}