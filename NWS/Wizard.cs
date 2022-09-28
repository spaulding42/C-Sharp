public class Wizard : Human
{
    public Wizard(string name) : base(name,3,25,3,100){}

    public override int Attack(Human target)
    {
        target.Health -= Intelligence * 3;
        Health += Intelligence * 3;
        Console.WriteLine($"{Name} attacked {target.Name}. {target.Name}'s health is now {target.Health} and {Name}'s health is now {Health}");
        return target.Health;
    }

    public int Heal(Human target)
    {
        int heal = Intelligence * 3;
        target.Health += heal;
        Console.WriteLine($"Healing {target.Name} for {heal} points of damage");
        return target.Health;
    }
}