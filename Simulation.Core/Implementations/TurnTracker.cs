using Simulation.Core.Interfaces;

namespace Simulation.Core.Implementations;
/// <summary>
/// Класс отвечает за подсчет кол-ва ходов.
/// </summary>
public class TurnTracker : ITurnTracker
{
    private int _totalTurns;
    public void NextTurn() => _totalTurns++;
    public int GetTotalTurns() => _totalTurns;
}