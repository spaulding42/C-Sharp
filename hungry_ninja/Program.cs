Ninja hanzo = new Ninja();
Buffet upChuckArama = new Buffet();

while(!hanzo.isFull())
{
    hanzo.Eat(upChuckArama.Serve());

}
if (hanzo.isFull())
{
    Console.WriteLine("I ate:");
    foreach(Food dish in hanzo.FoodHistory)
    {
        Console.WriteLine(dish.Name);
    }
}