using Simulation.Core.Interfaces;

namespace Simulation.Core.Implementations;

public class TurnTracker : ITurnTracker
{
    public int TotalTurns { get; private set; }
    public void NextTurn() => TotalTurns++;
}