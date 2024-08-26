namespace Simulation.Core.Interfaces;
public interface ITurnTracker
{
    int TotalTurns { get; }
    void NextTurn();
}