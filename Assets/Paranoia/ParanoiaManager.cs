using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParanoiaArgs : EventArgs
{
    public string eventName { get; }

    public string argument { get; }

    public ParanoiaArgs(string name, string arg) { eventName = name; argument = arg; }
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

    private void Awake()
    {
        paranoiaEvent += EventRecieved;
    }
};
