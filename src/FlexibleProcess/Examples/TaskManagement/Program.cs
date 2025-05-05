namespace FlexibleProcess.Examples.TaskManagement;

class Program
{
    static void MainV2(string[] args)
    {
        // Create stages for individual tasks
        Stage taskIdle = new Stage("Idle");
        Stage taskRun = new Stage("Run");
        Stage taskComplete = new Stage("Complete");

        // Create stages for the task list
        Stage listActive = new Stage("Active");
        Stage listPaused = new Stage("Paused");
        Stage listCompleted = new Stage("Completed");

        // Create initiators
        IEmitter user = new UserInitiator("user1");
        IEmitter system = new SystemInitiator("SYS-001");

        // Create events for tasks
        Event startTask = new Event("StartTask", user);
        Event completeTask = new Event("CompleteTask", user);
        Event pauseTask = new Event("PauseTask", user);

        // Create events for task list
        Event startList = new Event("StartList", user);
        Event pauseList = new Event("PauseList", user);
        Event completeList = new Event("CompleteList", user);

        // Create task data
        var task1 = new TaskData
        {
            Id = 1,
            Title = "Implement login feature",
            Description = "Create user authentication system",
            Priority = 3,
            EstimatedTime = 120
        };

        var task2 = new TaskData
        {
            Id = 2,
            Title = "Fix critical bug",
            Description = "Resolve database connection issue",
            Priority = 5,
            EstimatedTime = 60
        };

        // Create task processes
        var taskProcess1 = new Process<TaskData>(taskIdle, task1);
        var taskProcess2 = new Process<TaskData>(taskIdle, task2);

        // Add stages to task processes
        taskProcess1.AddStage(taskRun);
        taskProcess1.AddStage(taskComplete);
        taskProcess2.AddStage(taskRun);
        taskProcess2.AddStage(taskComplete);

        // Create task list data
        var taskListData = new TaskListData(1, "Sprint 1 Tasks");
        taskListData.Tasks.Add(taskProcess1);
        taskListData.Tasks.Add(taskProcess2);

        // Create main process
        var mainProcess = new Process<TaskListData>(listActive, taskListData);
        mainProcess.AddStage(listPaused);
        mainProcess.AddStage(listCompleted);

        // Create transition guards and handlers
        var taskGuard = new TaskTransitionGuard();
        var taskHandler = new TaskTransitionHandler();

        // Add transitions for tasks
        var task1StartTransition = new Transition<TaskData>(taskIdle, startTask, taskRun, taskHandler, taskGuard);
        var task1CompleteTransition = new Transition<TaskData>(taskRun, completeTask, taskComplete, taskHandler, taskGuard);
        var task1PauseTransition = new Transition<TaskData>(taskRun, pauseTask, taskIdle, taskHandler, taskGuard);

        var task2StartTransition = new Transition<TaskData>(taskIdle, startTask, taskRun, taskHandler, taskGuard);
        var task2CompleteTransition = new Transition<TaskData>(taskRun, completeTask, taskComplete, taskHandler, taskGuard);
        var task2PauseTransition = new Transition<TaskData>(taskRun, pauseTask, taskIdle, taskHandler, taskGuard);

        // Add transitions to task processes
        taskProcess1.AddTransition(task1StartTransition);
        taskProcess1.AddTransition(task1CompleteTransition);
        taskProcess1.AddTransition(task1PauseTransition);

        taskProcess2.AddTransition(task2StartTransition);
        taskProcess2.AddTransition(task2CompleteTransition);
        taskProcess2.AddTransition(task2PauseTransition);

        // Add transitions for main process
        var listPauseTransition = new Transition<TaskListData>(listActive, pauseList, listPaused);
        var listResumeTransition = new Transition<TaskListData>(listPaused, startList, listActive);
        var listCompleteTransition = new Transition<TaskListData>(listActive, completeList, listCompleted);

        mainProcess.AddTransition(listPauseTransition);
        mainProcess.AddTransition(listResumeTransition);
        mainProcess.AddTransition(listCompleteTransition);

        // Demonstrate the process flow
        Console.WriteLine("Starting task management demonstration...\n");

        // Start working on task 1
        Console.WriteLine("Starting task 1...");
        taskProcess1.HandleEvent(startTask);
        task1.TimeSpent = 90; // Simulate work time
        taskProcess1.HandleEvent(completeTask);

        // Start working on task 2
        Console.WriteLine("\nStarting task 2...");
        taskProcess2.HandleEvent(startTask);
        task2.TimeSpent = 45; // Simulate work time
        taskProcess2.HandleEvent(pauseTask);

        // Pause the entire list
        Console.WriteLine("\nPausing task list...");
        mainProcess.HandleEvent(pauseList);

        // Resume the list
        Console.WriteLine("\nResuming task list...");
        mainProcess.HandleEvent(startList);

        // Complete task 2
        Console.WriteLine("\nCompleting task 2...");
        taskProcess2.HandleEvent(startTask);
        task2.TimeSpent = 60; // Complete the remaining work
        taskProcess2.HandleEvent(completeTask);

        // Complete the entire list
        Console.WriteLine("\nCompleting task list...");
        mainProcess.HandleEvent(completeList);

        // Print final status
        Console.WriteLine("\nFinal status:");
        Console.WriteLine(taskListData);
        Console.WriteLine("\nTask 1 status: " + taskProcess1.CurrentStage);
        Console.WriteLine("Task 2 status: " + taskProcess2.CurrentStage);

        // Print history
        Console.WriteLine("\nTask 1 history:");
        taskProcess1.PrintHistory();

        Console.WriteLine("\nTask 2 history:");
        taskProcess2.PrintHistory();

        Console.WriteLine("\nMain process history:");
        mainProcess.PrintHistory();
    }
} 