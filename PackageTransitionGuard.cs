namespace FlexibleProcess;

public class PackageTransitionGuard: TransitionGuard<Package>
{
    public override bool Validate(Package processData)
    {
        // Здесь можно добавить любую необходимую логику проверки состояния
        // Например, проверить, находится ли объект в определенном состоянии
        if (processData.Description == "Посылка с книгами")
        {
            return true;
        }
        else
        {
            Console.WriteLine($"Переход невозможен: состояние объекта не соответствует требованиям.");
            return false;
        }
    }
}
