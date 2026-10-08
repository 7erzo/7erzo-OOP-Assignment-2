namespace PatternsLab.Problems.Prototype;

public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
}

public abstract class Enemy
{
    private string _modelData;

    public string Name { get; set; }
    public int Health { get; set; }
    public Weapon Weapon { get; set; }
    public List<string> Abilities { get; set; } = new();

    public string ModelId => _modelData;

    public abstract Enemy Clone();

    protected Enemy(bool loadModel = true)
    {
        if (loadModel)
        {
            Console.WriteLine("   ...loading 3D model (slow)...");

            Thread.Sleep(500);

            _modelData =
                "MODEL_" + Guid.NewGuid().ToString("N")[..6];
        }
    }

    protected void CopyStateTo(Enemy target)
    {
        target.Name = Name;
        target.Health = Health;

        target._modelData = _modelData;

        target.Weapon = new Weapon
        {
            Name = Weapon.Name,
            Damage = Weapon.Damage
        };

        target.Abilities = new List<string>(Abilities);
    }
}

public class Orc : Enemy
{
    private Orc(Orc source) : base(false)
    {
        source.CopyStateTo(this);
    }

    public override Enemy Clone()
    {
        return new Orc(this);
    }

    public Orc()
    {
        Name = "Orc";
        Health = 100;

        Weapon = new Weapon
        {
            Name = "Axe",
            Damage = 25
        };

        Abilities.Add("Rage");
    }
}

public class Elf : Enemy
{
    private Elf(Elf source) : base(false)
    {
        source.CopyStateTo(this);
    }

    public override Enemy Clone()
    {
        return new Elf(this);
    }

    public Elf()
    {
        Name = "Elf";
        Health = 70;

        Weapon = new Weapon
        {
            Name = "Bow",
            Damage = 18
        };

        Abilities.Add("Stealth");
    }
}