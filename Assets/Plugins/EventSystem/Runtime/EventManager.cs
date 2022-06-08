using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    private static readonly Dictionary<IEventKey, EventHolder> EventHolders = new Dictionary<IEventKey, EventHolder>();

    /// <summary>
    /// Adds given action with Key to event stack
    /// </summary>
    /// <param name="key"></param>
    /// <param name="action"></param>
    public static void Add(IEventKey key, Action action)
    {
        if (action == null)
        {
            Debug.LogError("Action cannot be NULL");
            return;
        }

        if (key == null)
        {
            Debug.LogError("Key cannot be NULL");
            return;
        }

        if (!EventHolders.ContainsKey(key))
            EventHolders.Add(key, new EventHolder());

        EventHolders[key].Add(action);
    }

    /// <summary>
    /// Removes from event stack given action with given key
    /// </summary>
    /// <param name="key"></param>
    /// <param name="action"></param>
    public static void Remove(IEventKey key, Action action)
    {
        if (action == null)
        {
            Debug.LogError("Action cannot be NULL");
            return;
        }

        if (key == null)
        {
            Debug.LogError("Key cannot be NULL");
            return;
        }

        if (!EventHolders.ContainsKey(key))
        {
            Debug.LogError("Key is not found.");
            return;
        }

        EventHolders[key].Remove(action);
    }

    public static void Trigger(IEventKey key)
    {
        if (key == null)
        {
            Debug.LogError("Key cannot be NULL");
            return;
        }

        if (!EventHolders.ContainsKey(key))
        {
            Debug.LogError("Key is not found.");
            return;
        }
        EventHolders[key].Trigger();
    }

    /// <summary>
    /// Clears all of the recorded events
    /// </summary>
    public static void Clear()
    {
        foreach (KeyValuePair<IEventKey, EventHolder> eventKeyValue in EventHolders)
            eventKeyValue.Value.Clear();

        EventHolders.Clear();
    }
}