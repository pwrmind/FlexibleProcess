namespace FlexibleProcess;

/// <summary>
/// Represents a package that can be processed through different stages.
/// This is an example of process data that can be associated with a Process.
/// </summary>
public class Package
{
    /// <summary>
    /// The unique identifier of the package
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// A description of the package contents
    /// </summary>
    public string Description { get; set; }

    public override string ToString()
    {
        return $"Посылка #{Id}: {Description}";
    }
}
