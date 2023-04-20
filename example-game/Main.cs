using example_game;
using minigame_library.Items;
using minigame_library.Logging;
using minigame_library.Objects;
using minigame_library.World;
using System.Diagnostics;

// Relative path supremacy, I will fix it later (maybe)
Logger logger = Logger.CreateInstance("../../../../log/log.txt");
logger.Log(TraceEventType.Critical, "Example critical message");

Map map = Map.CreateInstance();

var sword = new AttackItem(0, "Sword", 50, 5, "Is literally a sword");
var shield = new DefenceItem(1, "Shield", 5, "Is literally a shield");
var anotherSword = new AttackItem(0, "Sword of the gods", 3000, 50);


Player player = new("Player", new(0, 0), 3);
WorldObject chest = new("Chest", new(3, 0), true, false, startInventory: new List<Item>(){anotherSword});
Creature creature = new("Zombie", new(9, 0));

player.Inventory.Add(sword);
player.Inventory.Add(shield);

creature.Inventory.Add(new AttackItem(2, "Big axe", 30, 3));

player.Move(Direction.East);
Console.WriteLine(player.Position);
player.Loot(chest);
player.Equip(shield);

player.Move(Direction.East);
player.Move(Direction.East);
Console.WriteLine(player.Position);

