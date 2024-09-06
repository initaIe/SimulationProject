using Simulation.Core.Entities;
using Simulation.Core.Implementations;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Implementations;

Console.OutputEncoding = System.Text.Encoding.UTF8;


var map = new Map();

var consoleFieldRender = new FieldConsoleRenderer();

var turnTracker = new TurnTracker();

HashSet<string> staticObjectSprites = ["⛰️", "🌳"];

var staticObjectSettings = new StaticObjectSettings(
    new LimitSettings(10, 20),
    new DisplaySettings(staticObjectSprites));

HashSet<string> foodSprites = ["🍖", "🍕"];

var foodSettings = new FoodSettings(
    new LimitSettings(5, 10),
    new DisplaySettings(foodSprites),
    new LimitSettings(2, 4));

HashSet<string> herbivoreSprites = ["🐑", "🐖"];

HashSet<Type> herbivorePreys = [typeof(Food)];

var herbivoreSettings = new HerbivoreSettings(
    new LimitSettings(5, 10),
    new DisplaySettings(herbivoreSprites),
    new LimitSettings(5, 10),
    new LimitSettings(1, 2),
    new PreySettings(herbivorePreys));

HashSet<string> predatorSprites = ["🐺", "🦅"];

HashSet<Type> predatorPreys = [typeof(Food), typeof(Herbivore)];

var predatorSettings = new PredatorSettings(
    new LimitSettings(4, 6),
    new DisplaySettings(herbivoreSprites),
    new LimitSettings(10, 15),
    new LimitSettings(2, 3),
    new PreySettings(predatorPreys),
    new LimitSettings(4, 6));


var entitiesSettings = new EntitiesSettings(staticObjectSettings, foodSettings, herbivoreSettings, predatorSettings);

var simulationSettings = new SimulationSettings();
var simulation = new Simulation.Core.Simulation();