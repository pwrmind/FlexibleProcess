namespace FlexibleProcess;

class Program
{
    static void MainV1(string[] args)
    {
        // Создаем этапы
        Stage stage1 = new Stage("Этап 1");
        Stage stage2 = new Stage("Этап 2");
        Stage stage3 = new Stage("Этап 3");

        // Создаем инициаторов событий
        IEmitter user1 = new UserInitiator("1");
        IEmitter system = new SystemInitiator("SYS-001");
        IEmitter user2 = new UserInitiator("2");
        IEmitter externalService = new ExternalServiceInitiator("EXT-001");

        // Создаем события с указанием инициатора
        Event eventA = new Event("Событие A", user1);
        Event eventB = new Event("Событие B", system);
        Event eventC = new Event("Событие C", user2);
        Event eventD = new Event("Событие D", externalService);

        // Создаем объект, к которому привязан процесс (например, посылка)
        var package = new Package { Id = 1, Description = "Посылка с книгами" };

        // Создаем процесс, привязанный к посылке
        Process<Package> process = new Process<Package>(stage1, package);

        // Добавляем этапы в процесс
        process.AddStage(stage2);
        process.AddStage(stage3);

        // Создаем пользовательские обработчики переходов
        var customHandler1 = new CustomTransitionHandler1<Package>();
        var customHandler2 = new CustomTransitionHandler2<Package>();
		
		// Проверки состояния объекта при переходе
        var stateGuard = new PackageTransitionGuard();

        // Создаем переходы с обработчиками
        Transition<Package> transition1 = new Transition<Package>(eventA.GetType(), stage1, stage2, customHandler1, guard: stateGuard);
        Transition<Package> transition2 = new Transition<Package>(eventB.GetType(), stage1, stage3, customHandler2, guard: stateGuard);
        Transition<Package> transition3 = new Transition<Package>(eventC.GetType(), stage2, stage3, guard: stateGuard);
        Transition<Package> transition4 = new Transition<Package>(eventD.GetType(), stage3, stage1, guard: stateGuard);

        // Добавляем переходы в процесс
        process.AddTransition(transition1);
        process.AddTransition(transition2);
        process.AddTransition(transition3);
        process.AddTransition(transition4);

        // Обработка событий
        process.HandleEvent(eventA); // Переход на Этап 2 с вызовом обработчика
        process.HandleEvent(eventC); // Переход на Этап 3 без обработчика
        process.HandleEvent(eventD); // Переход на Этап 1 без обработчика
        process.HandleEvent(eventB); // Переход на Этап 3 с вызовом обработчика

        // Выводим историю переходов
        process.PrintHistory();
    }
}
