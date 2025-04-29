namespace FlexibleProcess;

// Класс, представляющий посылку
public class Package
{
    public int Id { get; set; }
    public string Description { get; set; }

    public override string ToString()
    {
        return $"Посылка #{Id}: {Description}";
    }
}
