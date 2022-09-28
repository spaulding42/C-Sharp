public class Deck
{
    List<Card> cards = new List<Card>();

    public Deck()
    {
        for(int i = 1; i<=13;i++)
        {
            cards.Add(new Card("Spades", i));
            cards.Add(new Card("Diamonds", i));
            cards.Add(new Card("Clubs", i));
            cards.Add(new Card("Hearts", i));
        }
        
    }
    public void PrintDeck()
    {
        foreach(Card c in cards)
        {
            c.Print();
        }
    }
    public Card Deal()
    {
        Card topCard = cards[cards.Count-1];
        cards.RemoveAt(cards.Count-1);
        return topCard;
    }
    public void DeckReset()
    {
        cards = new List<Card>();
        for(int i = 1; i<=13;i++)
        {
            cards.Add(new Card("Spades", i));
            cards.Add(new Card("Diamonds", i));
            cards.Add(new Card("Clubs", i));
            cards.Add(new Card("Hearts", i));
        }
    }
    public void Shuffle()
    {
        List<Card> shuffledDeck = new List<Card>();
        while(this.cards.Count > 0)
        {
            Random rand = new Random();
            int nextCard = rand.Next(0,this.cards.Count);
            shuffledDeck.Add(this.cards[nextCard]);
            this.cards.RemoveAt(nextCard);
        }
        this.cards = shuffledDeck;
        Console.WriteLine("Deck has been shuffled");
    }
    public int DeckLength()
    {
        return this.cards.Count;
    }

}