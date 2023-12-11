using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanoiaIterator : ParanoiaTrigger
{
    public int iteratorArg = 0;
    public AnimationCurve iteratorEvaluation;
    public float iteratorMult = 1.0f;

    public float duration = 1.0f;
    public float pause = 0.1f;
    protected override void Triggered(Collider other)
    {
        if (wasTriggered)
        {
            return;
        }

        if (other.tag == "Player") {
            wasTriggered = true;
            StartCoroutine(TriggerIteration());
        }
    }

    IEnumerator TriggerIteration()
    {
        for (float i = 0.0f; i < duration; i += pause)
        {
            float iteratorValue = iteratorEvaluation.Evaluate(i / duration) * iteratorMult;
            arguments[iteratorArg] = iteratorValue.ToString();
            
            foreach (var e in events)
            {
                ParanoiaManager.Broadcast(this, new ParanoiaArgs(e, arguments));
            }
            yield return new WaitForSeconds(pause);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
