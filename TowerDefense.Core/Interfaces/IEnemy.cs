using TowerDefense.Core.models;
namespace TowerDefense.Core.Interfaces;

public interface IEnemy : IGameObject
{
    string Type { get; }

    Position Position { get; }

    double Health { get; }
    double MaxHealth { get; }
    bool IsAlive { get; }

    double Speed { get; }
    bool IsFlying { get; }

    double DistanceTraveled { get; }
    bool HasReachedBase { get; }

    int Reward { get; }
    int BaseDamage { get; }

    void TakeDamage(double amount);

}