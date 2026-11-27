using TowerDefense.Core.Interfaces;
namespace TowerDefense.Core.models;

public class GameState
{
    private readonly List<IEnemy> _enemies = new();
    private readonly List<ITower> _towers = new();

    public GameState(int startingGold, int baseMaxHealth)
    {
        Gold = startingGold;
        BaseMaxHealth = baseMaxHealth;
        BaseHealth = BaseMaxHealth;
    }

// Les événements pour notifier les changements d'état du jeu
    public event Action<IEnemy>? EnemyKilled;
    public event Action<int>? BaseDamaged;
    public event Action<int>? GoldChanged;
    public event Action<int>? WaveStarted;
    public event Action<GameStatus>? GamesOver;

// Les états du jeu
public IReadOnlyList<IEnemy> Enemies => _enemies;
public IReadOnlyList<ITower> Towers => _towers;

public int Gold {get; private set; }
public int BaseHealth {get; private set; }
public int BaseMaxHealth {get;}
public int CurrentWave {get; private set; }
public int Score {get; private set; }
public GameStatus Status {get; private set; } = GameStatus.Playing;

// Ennemies, bases et vagues
public void AddEnemy(IEnemy enemy) => _enemies.Add(enemy);

public void RegisterEnemyKilled(IEnemy enemy)
    {
        if (!_enemies.Remove(enemy)) return;

        Score += enemy.Reward;
        AddGold(enemy.Reward);
        EnemyKilled?.Invoke(enemy);
    }

public void DamageBase(IEnemy enemy)
    {
        if (!_enemies.Remove(enemy)) return;

        BaseHealth = Math.Max(0, BaseHealth - enemy.BaseDamage);
        BaseDamaged?.Invoke(BaseHealth);

        if (BaseHealth == 0)
        EndGame (GameStatus.Lost);
    }

    public void Win() => EndGame(GameStatus.Won);

    // Tour et or
    public void AddTower(ITower tower) => _towers.Add(tower);
    public void RemoveTower(ITower tower) => _towers.Remove(tower);

    public void AddGold(int amount)
    {
        Gold += amount;
        GoldChanged?.Invoke(Gold);
    }

    public bool TrySpendGold(int amount)
    {
        if (amount > Gold) return false;

        Gold -= amount;
        GoldChanged?.Invoke(Gold);
        return true;
    }


    private void EndGame(GameStatus result)
    {
        if (Status != GameStatus.Playing) return;
        Status = result;
        GamesOver?.Invoke(result);
    }
}