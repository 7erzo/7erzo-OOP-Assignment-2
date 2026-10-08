using System.Diagnostics;
using PatternsLab.Problems.Builder;
using PatternsLab.Problems.Prototype;
using PatternsLab.Problems.Singleton;

Console.WriteLine("=== SINGLETON ===\n");

var db = new DatabaseService();
var ui = new UiService();

Console.WriteLine($"Initial theme: {db.Config.Theme}");

db.Config.Theme = "Dark";

Console.WriteLine("\nAdmin changed theme to Dark.");

ui.Render();

Console.WriteLine(
    $"\nSame config object? {ReferenceEquals(db.Config, ui.Config)}");

Console.WriteLine(
    $"Times config was loaded from disk: {AppConfig.LoadCount}");

db.Connect();


Console.WriteLine("\n=== PROTOTYPE: BEFORE ===\n");

var sw = Stopwatch.StartNew();

var army = new List<Enemy>();

for (int i = 1; i <= 5; i++)
{
    var orc = new Orc();
    orc.Name = $"Orc-{i}";
    army.Add(orc);
}

sw.Stop();

Console.WriteLine(
    $"Created 5 orcs with constructors in {sw.ElapsedMilliseconds} ms");


Console.WriteLine("\n=== PROTOTYPE: AFTER ===\n");

var prototype = new Orc
{
    Name = "Prototype Orc"
};

sw.Restart();

var clonedArmy = new List<Enemy>();

for (int i = 1; i <= 5; i++)
{
    var clone = prototype.Clone();
    clone.Name = $"Clone-Orc-{i}";
    clonedArmy.Add(clone);
}

sw.Stop();

Console.WriteLine(
    $"Created 5 orcs with Prototype in {sw.ElapsedMilliseconds} ms");

Console.WriteLine(
    $"\nPrototype model id: {prototype.ModelId}");

Console.WriteLine(
    $"First clone model id: {clonedArmy[0].ModelId}");

Console.WriteLine(
    $"Same model id? {prototype.ModelId == clonedArmy[0].ModelId}");


Enemy original = new Orc
{
    Name = "Boss Orc"
};

Enemy copy = original.Clone();

Console.WriteLine("\n=== PROTOTYPE: DEEP COPY TEST ===\n");

Console.WriteLine(
    $"Original weapon damage: {original.Weapon.Damage}");

Console.WriteLine(
    $"Copy weapon damage:     {copy.Weapon.Damage}");

copy.Weapon.Damage = 999;

Console.WriteLine("\nChanged COPY weapon damage to 999.");

Console.WriteLine(
    $"Original weapon damage: {original.Weapon.Damage}");

Console.WriteLine(
    $"Copy weapon damage:     {copy.Weapon.Damage}");

Console.WriteLine(
    $"\nOriginal abilities: {string.Join(", ", original.Abilities)}");

Console.WriteLine(
    $"Copy abilities:     {string.Join(", ", copy.Abilities)}");

copy.Abilities.Add("Fire Breath");

Console.WriteLine("\nAdded Fire Breath to COPY abilities.");

Console.WriteLine(
    $"Original abilities: {string.Join(", ", original.Abilities)}");

Console.WriteLine(
    $"Copy abilities:     {string.Join(", ", copy.Abilities)}");

Console.WriteLine("\n=== BUILDER ===\n");

Console.WriteLine(
    RegistrationCallSites.CreateLiveStudent());

Console.WriteLine(
    RegistrationCallSites.CreateVideosOnlyStudent());