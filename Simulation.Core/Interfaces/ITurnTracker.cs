namespace Simulation.Core.Interfaces;
public interface ITurnTracker
{
    int GetTotalTurnsCount();
    void NextTurn();
}