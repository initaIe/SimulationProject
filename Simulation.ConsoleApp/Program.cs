using Simulation.Core.Entities;
using Simulation.Core.Implementations;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Implementations;
using Simulation.Core.Settings.Field;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var map = new Map();

var consoleFieldRender = new FieldConsoleRenderer();

var turnTracker = new TurnTracker();

HashSet<string> staticObjectSprites = ["⛰️", "🌳"];

var staticObjectSettings = new StaticObjectSettings(
    new LimitSettings(1, 3),
    new DisplaySettings(staticObjectSprites));

HashSet<string> foodSprites = ["🍖", "🍕"];

var foodSettings = new FoodSettings(
    new LimitSettings(1, 2),
    new DisplaySettings(foodSprites),
    new LimitSettings(2, 4));

HashSet<string> herbivoreSprites = ["🐑", "🐖"];

HashSet<Type> herbivorePreys = [typeof(Food)];

var herbivoreSettings = new HerbivoreSettings(
    new LimitSettings(1, 2),
    new DisplaySettings(herbivoreSprites),
    new LimitSettings(5, 10),
    new LimitSettings(1, 2),
    new PreySettings(herbivorePreys));

HashSet<string> predatorSprites = ["🐺", "🦅"];

HashSet<Type> predatorPreys = [typeof(Herbivore)];

var predatorSettings = new PredatorSettings(
    new LimitSettings(1, 2),
    new DisplaySettings(predatorSprites),
    new LimitSettings(10, 15),
    new LimitSettings(2, 3),
    new PreySettings(predatorPreys),
    new LimitSettings(4, 6));


var entitiesSettings = new EntitiesSettings(staticObjectSettings, foodSettings, herbivoreSettings, predatorSettings);

var sizeSettings = new SizeSettings(40,40);
var displaySettings = new CellDisplaySettings("\ud83d\udfe9");

var fieldSettings = new FieldSettings(sizeSettings, displaySettings);

var simulationSettings = new SimulationSettings(entitiesSettings, fieldSettings);

var simulation = new Simulation.Core.Simulation(map, consoleFieldRender, turnTracker, simulationSettings);

simulation.Start();