public class Ninja : Human
{
    public Ninja(string name) : base(name, 3, 3, 75, 100)
    {
        
    }

    public override int Attack(Human target)
    {
        Random rand = new Random();
        int dmg = Dexterity;
        if(rand.Next(11) < 3)
        {
            dmg += 10;
        }
        target.Health -= dmg;

        if(target.Health <= 0)
        {
            target.Health = 0;
        }
        Console.WriteLine($"{Name} attacked {target.Name}. {target.Name}'s health is now {target.Health}");
        return target.Health;
    }

    public void Steal(Human target)
    {   
        if(target.Health >= 5)
        {
            target.Health -= 5;
            Health += 5;
        }
        else
        {
            Health += target.Health;
            target.Health = 0;
        }
        Console.WriteLine($"{Name} stole health from {target.Name}. {target.Name}'s health is now {target.Health}");
    }
}
