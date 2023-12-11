using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanoiaTrigger : MonoBehaviour
{
    public List<string> events;
    public List<string> arguments;

    public bool wasTriggered = false;

    private void Start()
    {
        ParanoiaManager.AddParanoiaEvent(name + "SetTriggered", SetTriggered);
    }

    void SetTriggered(object sender, ParanoiaArgs args)
    {
        bool triggered = false;
        if (args.arguments.Count >= 1)
        {
            triggered = bool.Parse(args.arguments[0]);
        }

        wasTriggered = triggered;
    }

    protected virtual void Triggered(Collider other)
    {
        if (wasTriggered) return;
        if (other.tag == "Player")
        {
            foreach (var e in events)
            {
                ParanoiaManager.Broadcast(this, new ParanoiaArgs(e, arguments));
            }
            wasTriggered = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Triggered(other);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
