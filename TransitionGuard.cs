namespace FlexibleProcess;

public class TransitionGuard<T>
{
    public virtual bool Validate(T processData)
    {	
		Console.WriteLine($"Переход невозможен: состояние объекта не соответствует требованиям.");
        return false;
    }
}
