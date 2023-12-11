using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanoiaTrigger : MonoBehaviour
{
    public List<string> events;
    public List<string> arguments;

    protected bool wasTriggered = false;

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
