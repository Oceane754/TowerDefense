namespace TowerDefense.Core.Interfaces;

public interface ITargetingStrategy
{
    string Name { get; }
    IEnemy? SelectTarget(IEnumerable<IEnemy> enemies);
}

