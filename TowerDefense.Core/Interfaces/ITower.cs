namespace TowerDefense.Core.Interfaces;
using TowerDefense.Core.models;

public interface ITower : IGameObject
{
    string type { get; }

    Position Position { get; }

    double Range { get; }
    double Damage { get; }
    double FireRate { get; }

    int Level { get; }
    bool CanUpgrade { get; }

    int Cost { get; }
    int UpgradeCost { get; }
    int SellValue { get; }

    ITargetingStrategy TargetingStrategy { get; }
    IEnemy? CurrentTarget { get; }

    void Upgrade();

}