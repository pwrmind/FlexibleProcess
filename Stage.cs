namespace FlexibleProcess;

/// <summary>
/// Represents a stage in a process. A stage is a state that the process can be in.
/// </summary>
public class Stage
{
    /// <summary>
    /// The name of the stage
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// The current status of the stage (e.g., "In Progress", "Completed")
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Initializes a new instance of the Stage class
    /// </summary>
    /// <param name="name">The name of the stage</param>
    public Stage(string name)
    {
        Name = name;
        Status = "Не начат"; // Initial state
    }

    /// <summary>
    /// Returns a string representation of the stage
    /// </summary>
    /// <returns>A string containing the stage name and status</returns>
    public override string ToString()
    {
        return $"{Name} ({Status})";
    }
}
