Wizard gandalf = new Wizard("Gandalf");
Ninja hanzo = new Ninja("Hanzo");
Samurai gengi = new Samurai("Gengi");

hanzo.Attack(gengi);
hanzo.Steal(gengi);
gandalf.Attack(hanzo);
gandalf.Heal(gengi);
gengi.Attack(gandalf);
gengi.Meditate();