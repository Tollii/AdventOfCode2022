namespace AdventOfCode.Day7;

public record Directory
{
    public string Name { get; init; }
    public Directory Parent { get; init; }
    public IList<Directory> SubDirectories { get; } = new List<Directory>();
    public IList<File> Files { get; } = new List<File>();
    public int Size => SubDirectories.Sum(sd => sd.Size) + Files.Sum(f => f.Size);

    public void AddDirectory(Directory dir) => SubDirectories.Add(dir);
    public void AddFile(File file) => Files.Add(file);
}