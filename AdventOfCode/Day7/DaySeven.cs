using Directory = AdventOfCode.Day7.Directory;

class DaySeven
{
    public static void Run()
    {
        const string PATH = @"C:\test-dev\Playground\AdventOfCode\AdventOfCode\Day7\input.txt";
        
        IList<string> lines = File.ReadAllLines(PATH).Skip(1).ToList();
    
        var root = new Directory { Name = "/" };
        
        BuildTree(root, lines);
        
        var directorySizes = new List<int>();
        
        Traverse(root, directorySizes);
        
        var size = directorySizes.Where(x => x <= 100_000).Sum();
        
        Console.WriteLine($"Size of directories below limit is {size}");
            
        var neededSpace = 30_000_000 - (70_000_000 - root.Size);
        var deletedSpace = directorySizes.Order().First(x => x >= neededSpace);
        
        Console.WriteLine($"Fewest bytes that can be deleted is {deletedSpace}");
    }
    
    private static void BuildTree(Directory root, IEnumerable<string> input)
    {
        var currentDirectory = root;
        
        foreach (var line in input )
        {
            var tokens = line.Split();

            if (tokens[0] == "dir")
            {
                currentDirectory.AddDirectory(new() { Name = tokens[1], Parent = currentDirectory});
                continue;
            }

            if (int.TryParse(tokens[0], out var size))
            {
                currentDirectory.AddFile(new() { Name = tokens[1], Size = size });
                continue;
            }

            if (tokens is not ["$", "cd", ..]) continue;
            
            if (tokens[2] == "..")
            {
                currentDirectory = currentDirectory.Parent;
                continue;
            }

            currentDirectory = currentDirectory.SubDirectories.Single(x => x.Name == tokens[2]);
        }
    }

    private static void Traverse(Directory? node, ICollection<int> directorySizes)
    {
        if (node is null) return;
        
        directorySizes.Add(node.Size);

        foreach (var subDirectory in node.SubDirectories)
            Traverse(subDirectory, directorySizes);
    }
}





