using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanoiaOnOffTrigger : ParanoiaTrigger
{
    public float secsToWait = 1.0f;

    public string postTimerEventName;
    public List<string> postTimerEventArgs;
       
    protected override void Triggered(Collider other)
    {
        base.Triggered(other);
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(secsToWait);
        ParanoiaManager.Broadcast(this, new ParanoiaArgs(postTimerEventName, postTimerEventArgs));
    }
}
