namespace Domain.Interfaces.DataModels;

public interface IGrid
{
    public int Height { get; }
    public int Width { get; }
    public int[][] Rows { get; }

    public int GetValueAtCoordinate(int x, int y);
}