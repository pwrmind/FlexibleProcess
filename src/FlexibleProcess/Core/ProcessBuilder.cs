using System;
using System.Collections.Generic;

namespace FlexibleProcess;

/// <summary>
/// Fluent builder for creating and configuring processes
/// </summary>
/// <typeparam name="T">The type of data associated with the process</typeparam>
public class ProcessBuilder<T>
{
    private Stage _initialStage;
    private T _processData;
    private readonly List<Stage> _stages = new();
    private readonly List<Transition<T>> _transitions = new();

    /// <summary>
    /// Sets the initial stage for the process
    /// </summary>
    /// <param name="stageName">Name of the initial stage</param>
    /// <returns>The builder instance</returns>
    public ProcessBuilder<T> WithInitialStage(string stageName)
    {
        _initialStage = new Stage(stageName);
        _stages.Add(_initialStage);
        return this;
    }

    /// <summary>
    /// Sets the process data
    /// </summary>
    /// <param name="data">The data to associate with the process</param>
    /// <returns>The builder instance</returns>
    public ProcessBuilder<T> WithProcessData(T data)
    {
        _processData = data;
        return this;
    }

    /// <summary>
    /// Adds a new stage to the process
    /// </summary>
    /// <param name="stageName">Name of the stage to add</param>
    /// <returns>The builder instance</returns>
    public ProcessBuilder<T> AddStage(string stageName)
    {
        var stage = new Stage(stageName);
        _stages.Add(stage);
        return this;
    }

    /// <summary>
    /// Adds a transition between stages
    /// </summary>
    /// <param name="fromStageName">Name of the source stage</param>
    /// <param name="toStageName">Name of the target stage</param>
    /// <param name="eventName">Name of the event that triggers the transition</param>
    /// <param name="emitter">The entity that emits the event</param>
    /// <param name="handler">Optional custom handler for the transition</param>
    /// <param name="guard">Optional custom guard for the transition</param>
    /// <returns>The builder instance</returns>
    public ProcessBuilder<T> AddTransition(
        string fromStageName,
        string toStageName,
        string eventName,
        IEmitter emitter,
        TransitionHandler<T> handler = null,
        TransitionGuard<T> guard = null)
    {
        var fromStage = _stages.Find(s => s.Name == fromStageName);
        var toStage = _stages.Find(s => s.Name == toStageName);

        if (fromStage == null || toStage == null)
        {
            throw new ArgumentException("Source or target stage not found");
        }

        var transitionEvent = new Event(eventName, emitter);
        var transition = new Transition<T>(transitionEvent.GetType(), fromStage, toStage, handler, guard);
        _transitions.Add(transition);

        return this;
    }

    /// <summary>
    /// Builds and returns the configured process
    /// </summary>
    /// <returns>A new Process instance</returns>
    public Process<T> Build()
    {
        if (_initialStage == null)
        {
            throw new InvalidOperationException("Initial stage must be set");
        }

        if (_processData == null)
        {
            throw new InvalidOperationException("Process data must be set");
        }

        var process = new Process<T>(_initialStage, _processData);

        // Add all stages
        foreach (var stage in _stages)
        {
            if (stage != _initialStage)
            {
                process.AddStage(stage);
            }
        }

        // Add all transitions
        foreach (var transition in _transitions)
        {
            process.AddTransition(transition);
        }

        return process;
    }
} 