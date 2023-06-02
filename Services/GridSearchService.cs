using Domain.Interfaces.DataModels;

namespace Services;

public class GridSearchService : IGridSearchService
{
    public int FindLargestProductInGrid(IGrid grid, int lineLength)
    {
        var largestProduct = 0;

        for (var y = 0; y < grid.Height; y++)
        {
            for (var x = 0; x < grid.Width; x++)
            {
                var largestProductFromCoord = FindLargestProductFromCoord(grid, lineLength, x, y);

                if (largestProductFromCoord > largestProduct)
                {
                    largestProduct = largestProductFromCoord;
                }
            }
        }

        return largestProduct;
    }

    private int FindLargestProductFromCoord(IGrid grid, int lineLength, int startX, int startY)
    {
        var horizontal = 1;
        var vertical = 1;
        var majorDiagonal = 1;
        var minorDiagonal = 1;

        var canFitHorizontalLine = startX < grid.Width - lineLength;
        var canFitVerticalLine = startY < grid.Height - lineLength;
        var canFitMajorDiagonalLine = canFitHorizontalLine & canFitVerticalLine;
        var canFitMinorDiagonalLine = canFitHorizontalLine & startY > lineLength - 1;

        for (var i = 0; i < lineLength; i++)
        {
            if (canFitHorizontalLine)
            {
                horizontal *= grid.GetValueAtCoordinate(startX + i, startY);
            }

            if (canFitVerticalLine)
            {
                vertical *= grid.GetValueAtCoordinate(startX, startY + i);
            }

            if (canFitMajorDiagonalLine)
            {
                majorDiagonal *= grid.GetValueAtCoordinate(startX + i, startY + i);
            }

            if (canFitMinorDiagonalLine)
            {
                minorDiagonal *= grid.GetValueAtCoordinate(startX + i, startY - i);
            }
        }

        return new int[]
        {
            horizontal,
            vertical,
            majorDiagonal,
            minorDiagonal,
        }.Max();
    }
}