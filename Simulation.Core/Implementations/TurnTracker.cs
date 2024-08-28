using Simulation.Core.Interfaces;

namespace Simulation.Core.Implementations;
/// <summary>
/// Класс отвечает за подсчет кол-ва ходов.
/// </summary>
public class TurnTracker : ITurnTracker
{
    public int TotalTurns { get; private set; }
    public void NextTurn() => TotalTurns++;
}