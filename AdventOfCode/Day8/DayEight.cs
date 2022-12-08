namespace AdventOfCode.Day8;

public class DayEight
{
    public static void Run()
    {
        const string PATH = @"C:\test-dev\Playground\AdventOfCode\AdventOfCode\Day8\input.txt";
        IList<string> lines = File.ReadAllLines(PATH).ToList();

        var forest = BuildForest(lines);

        var scenicScores = new List<int>();

        Console.WriteLine(forest.NumberOfVisibleTrees(scenicScores));
        
        Console.WriteLine(scenicScores.Order().LastOrDefault());
    }

    public static Forest BuildForest(IList<string> input)
    {
        var forest = new Forest();
        
        for (var treeRowIndex = 0; treeRowIndex < input.Count; treeRowIndex++)
        {
            var treeLine = new List<Tree>();
            
            for (var treeColumnIndex = 0; treeColumnIndex < input[treeRowIndex].Length; treeColumnIndex++)
            {
                var treeHeight = int.Parse(input[treeRowIndex][treeColumnIndex].ToString());
        
                var currentTree = new Tree { Height = treeHeight, Row = treeRowIndex, Column = treeColumnIndex};
                
                treeLine.Add(currentTree);
            }
            
            forest.Trees.Add(treeLine);
        }

        return forest;
    }
}