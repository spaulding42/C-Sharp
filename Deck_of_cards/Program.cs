
Card card1 = new Card("Spades", 12);

card1.Print();

Deck deck = new Deck();

deck.Shuffle();
deck.PrintDeck();

Player steve = new Player("Steve");

steve.Draw(deck);
steve.Draw(deck);
steve.Draw(deck);

steve.printHand();

if(!steve.emptyHand()) steve.Discard(2);
if(!steve.emptyHand()) steve.Discard(2);
if(!steve.emptyHand()) steve.Discard(2);
if(!steve.emptyHand()) steve.Discard(2);

steve.printHand();
