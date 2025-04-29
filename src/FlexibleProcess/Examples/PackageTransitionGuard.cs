namespace FlexibleProcess;

/// <summary>
/// Custom transition guard for Package objects.
/// Provides validation logic specific to package processing.
/// </summary>
public class PackageTransitionGuard : TransitionGuard<Package>
{
    /// <summary>
    /// Validates whether a transition can occur for a package
    /// </summary>
    /// <param name="package">The package to validate</param>
    /// <returns>True if the transition is valid, false otherwise</returns>
    public override bool Validate(Package package)
    {
        // Example validation logic:
        // - Check if package ID is valid
        // - Check if package description is not empty
        // - Add any other package-specific validation rules

        if (package == null)
        {
            Console.WriteLine("Package is null");
            return false;
        }

        if (package.Id <= 0)
        {
            Console.WriteLine($"Invalid package ID: {package.Id}");
            return false;
        }

        if (string.IsNullOrEmpty(package.Description))
        {
            Console.WriteLine("Package description is empty");
            return false;
        }

        return true;
    }
}
