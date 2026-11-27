namespace TowerDefense.Core.models;

public class GameState
{
    private readonly List<IEnemy> _enemies = new();
    private readonly List<Itower> _towers = new();

    public GameState(int StartingGold, int BaseMaxHealth)
    {
        Gold = StartingGold;
        BaseMaxHealth = BaseMaxHealth;
        BaseHealth = BaseMaxHealth;
    }

    public event Action<IEnemy>? EnemyKilled;
    public event Action<int>? BaseDamaged;
    public event Action<int>? GoldChanged;
    public event Action<int>? WaveStarted;
    public event Action<GameStatus>? GamesOver;

    
}