class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory;
     
    // add a constructor
    public Ninja ()
    {
        calorieIntake = 0;
        FoodHistory = new List<Food>();
    }
    // add a public "getter" property called "IsFull"
    public bool isFull ()
    {
        if(this.calorieIntake >= 1500)
        {
            Console.WriteLine("I'm Stuffed!!");
            return true;
        }
        if(this.calorieIntake >= 1200)
        {
            Console.WriteLine("I'm Full!");
            return true;
        }
        return false;
    }
    // build out the Eat method
    public void Eat(Food item)
    {
        if (this.calorieIntake < 1200)
        {
            this.calorieIntake += item.Calories;
            this.FoodHistory.Add(item);
            Console.WriteLine($"Ninja eats: {item.Name} total calories: {this.calorieIntake}");
            if(item.IsSpicy)
            {
                Console.WriteLine($"That was spicy!");
            }
            if(item.IsSweet)
            {
                Console.WriteLine($"That was sweet!");
            }
            if(item.Name == "Jell-o")
            {
                Console.WriteLine("There's always room for Jell-o!");
            }
        }
        else
        {
            Console.WriteLine($"Too full for {item.Name}");
        }

    }
}