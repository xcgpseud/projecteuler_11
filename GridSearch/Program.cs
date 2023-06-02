using Domain.DataModels;
using Services;

var lines = File.ReadLines("INPUT.TXT");

var grid = new Grid(lines);
var searchService = new GridSearchService();

var largestProduct = searchService.FindLargestProductInGrid(grid, 4);

Console.WriteLine(largestProduct);

/*
 * With more time I would:
 *
 * - Add dependency injection and a controller for this section of the code, to avoid `new GridSearchService()` etc.
 * - - Alternatively a factory would be a little faster
 * - Unit test the service methods
 * - Fetch *where* the largest product exists in the grid and which direction it was in
 */
