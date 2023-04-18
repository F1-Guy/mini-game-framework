using minigame_library.Logging;
using minigame_library.Objects;
using minigame_library.World;
using System.Diagnostics;

// Relative path supremacy, I will fix it later
Logger _logger = Logger.CreateInstance("../../../../log/log.txt", SourceLevels.All);

Map map = Map.CreateInstance(50, 50);

map.Entities.Add(new Creature("Tester", new Position(0, 0), 10));
map.Entities.Add(new WorldObject("Test Object", new Position(1, 1), true, true));

Creature? tester = map.Entities[0] as Creature;
WorldObject? testObject = map.Entities[1] as WorldObject;

Console.WriteLine(tester.Position.DistanceFromCurrentPosition(testObject.Position));
Console.WriteLine(Position.DistanceBetweenPositions(testObject.Position, tester.Position));