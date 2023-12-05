using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanoiaTrigger : MonoBehaviour
{
    public string eventName;
    public List<string> arguments;

    protected bool wasTriggered = false;

    protected virtual void Triggered(Collider other)
    {
        if (wasTriggered) return;
        if (other.tag == "Player")
        {
            ParanoiaManager.Broadcast(this, new ParanoiaArgs(eventName, arguments));
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
