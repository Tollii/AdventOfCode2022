using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day8;

public record Tree
{
    public int Height { get; init; }
    public int Row { get; init; }
    public int Column { get; init; }

    public bool IsVisible(Forest forest, List<int> scenicScores)
    {
        var visibleFromWest = IsVisibleFromDirection(forest, Directions.West, Height);

        var visibleFromEast = IsVisibleFromDirection(forest, Directions.East, Height);
        
        var visibleFromNorth = IsVisibleFromDirection(forest, Directions.North, Height);
        
        var isVisibleFromSouth = IsVisibleFromDirection(forest, Directions.South, Height);

        var scenicScore = visibleFromEast.NumberOfTreesVisible * visibleFromNorth.NumberOfTreesVisible
                                                               * visibleFromWest.NumberOfTreesVisible
                                                               * isVisibleFromSouth.NumberOfTreesVisible;
        
        scenicScores.Add(scenicScore);

        return visibleFromEast.IsVisible || visibleFromNorth.IsVisible || visibleFromWest.IsVisible || isVisibleFromSouth.IsVisible;
    }
    private (bool IsVisible, int NumberOfTreesVisible) IsVisibleFromDirection(Forest forest, (int Column, int Row) direction, int rootHeight, int numberOfTreesVisible = 0)
    {
        var tree = forest.Trees.ElementAtOrDefault(Row + direction.Column)?.ElementAtOrDefault(Column + direction.Row);
        if (tree is null) return (true, numberOfTreesVisible);

        if (tree.Height < rootHeight)
            return tree.IsVisibleFromDirection(forest, direction, rootHeight, numberOfTreesVisible + 1);
        
        return (false, numberOfTreesVisible + 1);
    }

    private static class Directions
    {
        public static readonly (int Column, int Row) North = (-1, 0);
        public static readonly (int Column, int Row) South = (1, 0);
        public static readonly (int Column, int Row) West = (0, -1);
        public static readonly (int Column, int Row) East = (0, 1);
    }
}
