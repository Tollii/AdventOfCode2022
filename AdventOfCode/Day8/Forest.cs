using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day8;

public record Forest
{
    public List<List<Tree>> Trees { get; } = new();
    
    public int NumberOfVisibleTrees(List<int> scenicScoreList) 
        => Trees.SelectMany(treeLine => treeLine).Count(tree => tree.IsVisible(this, scenicScoreList));
}