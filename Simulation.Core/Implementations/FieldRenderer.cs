using Simulation.Core.Interfaces;

namespace Simulation.Core.Implementations;
public class FieldRenderer() : IFieldRender
{
    //private string[][] CreateEmptyField(int fieldWidth, int fieldHeight)
    //{
    //    var field = new string[fieldHeight][];
    //    for (int i = 0; i < fieldHeight; i++)
    //    {
    //        field[i] = new string[fieldWidth]; 
    //    }
    //    return field;
    //}
    //private void PlaceEntities(string[][] field, Dictionary<Guid, Coordinates> entitiesCoordinates)
    //{
    //    foreach (var entity in entitiesCoordinates)
    //    {
    //        field[entity.Value.X][entity.Value.Y] = "x";
    //    }
    //}

    public void RenderField()
    {
        foreach (var VARIABLE in COLLECTION)
        {
            throw new NotImplementedException();
        }
    }
}
