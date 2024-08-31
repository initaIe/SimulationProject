namespace Simulation.Core.Entities.Interfaces;

public interface IAttacker : IAttackAction, IAttackDamage;

public interface IAttackDamage
{
    int Damage { get; }
}

public interface IAttackAction
{
    void Attack(IHerbivore preyHerbivore);
}
