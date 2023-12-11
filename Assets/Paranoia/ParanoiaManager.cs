using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParanoiaArgs : EventArgs
{
    public string eventName { get; }

    public List<string> arguments { get; }

    public ParanoiaArgs(string name, List<string> args) { eventName = name; arguments = args; }
};

public delegate void ParanoiaInstance(object sender, ParanoiaArgs arguments);

public class ParanoiaManager : MonoBehaviour
{
    private static event EventHandler<ParanoiaArgs> paranoiaEvent;
    private static Dictionary<string, ParanoiaInstance> subscribers = new Dictionary<string, ParanoiaInstance>();

    private void EventRecieved(object sender, ParanoiaArgs args)
    {
        if (subscribers.TryGetValue(args.eventName, out ParanoiaInstance del))
        {
            del(sender, args);
        }
    }

    public static void AddParanoiaEvent(string name, ParanoiaInstance callback)
    {
        subscribers.Add(name, callback);
    }

    public static void RemoveParanoiaEvent(string name)
    {
        subscribers.Remove(name);
    }

    public static void Broadcast(object sender, ParanoiaArgs args)
    {
        paranoiaEvent.Invoke(sender, args);
    }

    public static void ResetEvents()
    {
        subscribers.Clear();
    }

    private void Awake()
    {
        paranoiaEvent += EventRecieved;
    }
};
