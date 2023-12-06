using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanoiaLight : MonoBehaviour
{
    public string lightName = "AmbientLight";
    // Start is called before the first frame update
    void Start()
    {
        ParanoiaManager.AddParanoiaEvent(lightName, Light);
    }

    private void Light(object caller, ParanoiaArgs args)
    {
        bool on = false;

        if (args.arguments.Count >= 1)
        {
            on = bool.Parse(args.arguments[0]);
        }


        if (TryGetComponent(out Light light)) {
            light.enabled = on;
        }
        
    }
}
