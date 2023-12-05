using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanoiaTrigger : MonoBehaviour
{
    public string eventName;
    public string arguments;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ParanoiaManager.Broadcast(this, new ParanoiaArgs(eventName, arguments));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
