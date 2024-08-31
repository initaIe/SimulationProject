namespace Simulation.Core.Interfaces;
public interface ITurnTracker
{
    int GetTotalTurns();
    void NextTurn();
}