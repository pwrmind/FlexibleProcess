namespace FlexibleProcess;

public class Stage
{
    public string Name { get; private set; }
    public string Status { get; set; } // Состояние этапа (например, "В процессе", "Завершен")

    public Stage(string name)
    {
        Name = name;
        Status = "Не начат"; // Начальное состояние
    }

    public override string ToString()
    {
        return $"{Name} ({Status})";
    }
}
