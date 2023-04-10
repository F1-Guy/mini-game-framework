using minigame_library.World;
using minigame_library.Objects;

var map = Map.CreateInstance(50, 50);

map.Entities.Add(new Creature("Tester", new Position(0, 0), 10));
map.Entities.Add(new WorldObject("Test Object", new Position(1, 1), true, true));

var tester = map.Entities[0] as Creature;
var testObject = map.Entities[1] as WorldObject;

Console.WriteLine(tester.Position.DistanceFromCurrentPosition(testObject.Position));
Console.WriteLine(Position.DistanceBetweenPositions(testObject.Position, tester.Position));