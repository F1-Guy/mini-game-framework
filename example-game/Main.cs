using minigame_library.Items;
using minigame_library.Logging;
using minigame_library.Objects;
using minigame_library.World;
using System;
using System.Diagnostics;

// Relative path supremacy, I will fix it later
Logger logger = Logger.CreateInstance("../../../../log/log.txt", SourceLevels.All);

Map map = Map.CreateInstance(50, 50);

var player = new Creature("Player", new Position(0, 0), 100, new List<Item> { new AttackItem(0, "Sword", 20, 3)});
var enemy = new Creature("Enemy", new Position(3, 0), 2, null);
var thing = new WorldObject("chest", new Position(1, 0), true, true, 500);


player.Move(Direction.East);
player.Hit(thing);
Console.WriteLine(thing.Health);
player.Move(Direction.East);

player.Hit(thing);
player.Hit(enemy);

Console.WriteLine(enemy.Health);
Console.WriteLine(thing.Health);


