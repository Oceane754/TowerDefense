namespace TowerDefense.Core.models;

public readonly record struct Position(double X, double Y)
{
    public double DistanceTo(Position other)
    {
        var dx = X - other.X;
        var dy = Y - other.Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}


