class Buffet
{
    public List<Food> Menu;
     
    //constructor
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Chicken", 500, true, false),
            new Food("Cake", 300, false, true),
            new Food("Ice Cream", 300, false, true),
            new Food("Pasta", 600, false, false),
            new Food("Steak", 600, false, false),
            new Food("Jell-o", 30, false, true),
            new Food("Potatoes and Gravy", 300, false, false)
        };
    }
     
    public Food Serve()
    {
        Random rand = new Random();
        int randFood = rand.Next(0,Menu.Count);
        return Menu[randFood];
    }
}