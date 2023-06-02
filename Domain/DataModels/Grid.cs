using Domain.Interfaces.DataModels;

namespace Domain.DataModels;

public class Grid : IGrid
{
    public int Height { get; }
    public int Width { get; }

    // public List<List<int>> Rows { get; }
    public int[][] Rows { get; }

    public Grid(IEnumerable<string> inputLines)
    {
        Rows = ConvertFileLinesToGrid(inputLines);
        Height = Rows.Length;
        Width = Rows.First().Length;
    }

    public int GetValueAtCoordinate(int x, int y)
    {
        return Rows[y][x];
    }

    private static int[][] ConvertFileLinesToGrid(IEnumerable<string> lines)
    {
        return lines
            .Select(line => line.Split(' ').Select(int.Parse).ToArray())
            .ToArray();
    }
}