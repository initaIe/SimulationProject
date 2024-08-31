using Simulation.Core.Implementations.EntityImplementations;
using Simulation.Core.Interfaces;
using Simulation.Core.Interfaces.EntityInterfaces;
using Simulation.Core.POCO;
using Simulation.Core.Settings;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Simulation.Core;
public class Simulation
{
    private readonly IField<Guid, Node, IEntity> _field;
    private readonly IFieldRender _fieldRender;
    private readonly ITurnTracker _turnTracker;
    private readonly SimulationSettings _simulationSettings;


    public Simulation(
        IFieldRender fieldRender,
        ITurnTracker turnTracker,
        SimulationSettings simulationSettings,
        IField<Guid, Node, IEntity> field)
    {
        _fieldRender = fieldRender;
        _turnTracker = turnTracker;
        _simulationSettings = simulationSettings;
        _field = field;
    }

    public HashSet<EntityRenderData> GetRenderEntityData()
    {
        HashSet<EntityRenderData> data = [];
        var allEntities = _field.GetAllEntities();
        foreach (var entity in allEntities)
        {
            var coordinate = _field.GetEntityLocation(entity.Id);
            data.Add(new EntityRenderData(entity.DisplayMark, coordinate));
        }
        return data;
    }

    public bool TryGetRandomEmptyLocation([MaybeNullWhen(false)] out Node node)
    {
        // Проверяем, есть ли вообще свободные места
        if (!HasFieldEmptyLocation())
        {
            node = null;
            return false;
        }

        Node rndLocation;

        // Генерируем случайное местоположение и проверяем, свободно ли оно
        do
        {
            rndLocation = GetRandomLocation();
        } while (!_field.IsEntityLocationEmpty(rndLocation));

        node = rndLocation;
        return true;
    }

    public Node GetRandomLocation()
    {
        Random rnd = new();

        var fieldSizeSettings = _simulationSettings.FieldSettings.FieldSizeSettings;
        int x = rnd.Next(0, fieldSizeSettings.FieldWidth - 1);
        int y = rnd.Next(0, fieldSizeSettings.FieldHeight - 1);

        return new Node(x, y);
    }

    public bool HasFieldEmptyLocation()
    {
        var totalCells = GetTotalCellsCount();
        var totalEntites = _field.GetTotalCountOfEntites();
        return totalEntites < totalCells;
    }

    public int GetTotalCellsCount()
    {
        var fieldSizeSettings = _simulationSettings.FieldSettings.FieldSizeSettings;
        return fieldSizeSettings.FieldHeight * fieldSizeSettings.FieldWidth;
    }

    public void MoveCreature(ICreature creature, Node final)
    {
        if (creature is IEntity entity)
        {
            _field.Update(entity, final);
        }
    }

    private double CalculateDistance(Node start, Node final)
    {
        return Math.Sqrt(Math.Pow(final.X - start.X, 2) + Math.Pow(final.Y - start.Y, 2));
    }

    public IEntity GetPredatorClosestTarget(IPredator predator)
    {
        var predatorAsEntity = (IEntity)predator;
        var predatorLocation = _field.GetEntityLocation(predatorAsEntity.Id);

        var entities = _field.GetAllEntities();

        double minDistance = double.MaxValue;

        IEntity targetEntity = null!;

        foreach (var entity in entities)
        {
            if (entity is not Food or Herbivore) continue;

            var entityLocation = _field.GetEntityLocation(entity.Id);
            double distance = CalculateDistance(predatorLocation, entityLocation);

            if (!(distance < minDistance)) continue;

            minDistance = distance;
            targetEntity = entity;
        }
        return targetEntity;
    }

    public IEntity GetHerbivoreClosestTarget(IHerbivore herbivore)
    {
        var herbivoreAsEntity = (IEntity)herbivore; 
        var herbivoreLocation = _field.GetEntityLocation(herbivoreAsEntity.Id);

        var entities = _field.GetAllEntities();

        double minDistance = double.MaxValue;

        IEntity targetEntity = null!;

        foreach (var entity in entities)
        {
            if (entity is not Food) continue;

            var entityLocation = _field.GetEntityLocation(entity.Id);
            double distance = CalculateDistance(herbivoreLocation, entityLocation);

            if (!(distance < minDistance)) continue;

            minDistance = distance;
            targetEntity = entity;
        }
        return targetEntity;
    }
}