using Domain.Interfaces.DataModels;

namespace Services;

public interface IGridSearchService
{
    public int FindLargestProductInGrid(IGrid grid, int lineLength);
}