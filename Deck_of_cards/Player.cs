public class Player
{
    string Name;
    List<Card> Hand = new List<Card>();

    // constructor
    public Player(string name)
    {
        Name = name;
    }

    public Card Draw(Deck deck)
    {
        Card newDraw = deck.Deal();
        Hand.Add(newDraw);
        return newDraw;
    }
    public bool emptyHand()
    {
        if (Hand.Count <1) return true;
        return false;
    }
    public List<Card> printHand()
    {
        Console.WriteLine($"{Name}'s hand:");
        
        for (int i = 0; i<Hand.Count;i++)
        {
            string msg = Hand[i].getCardString();
            Console.WriteLine($"Position: {i} {msg}");
        }
        return Hand;
    }
    public Card Discard(int idx)
    {
        if (Hand.Count > idx)
        {
            Card playingCard = Hand[idx];
            Hand.RemoveAt(idx);
            return playingCard;
        }
        Card playingCardDefault = Hand[0];
        Hand.RemoveAt(0);
        return playingCardDefault;
    }
}