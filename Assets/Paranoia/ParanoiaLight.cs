using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanoiaLight : MonoBehaviour
{
    public string lightName = "AmbientLight";
    new Light light;
    // Start is called before the first frame update
    void Start()
    {
        ParanoiaManager.AddParanoiaEvent(lightName, Light);
        ParanoiaManager.AddParanoiaEvent(lightName + "Range", LightRange);
        light = GetComponent<Light>();
    }

    private void LightRange(object caller, ParanoiaArgs args)
    {
        float range = 0.0f;
        if (args.arguments.Count >= 1)
        {
            range = float.Parse(args.arguments[0]);
        }

        light.range = range;
    }

    private void Light(object caller, ParanoiaArgs args)
    {
        bool on = false;

        if (args.arguments.Count >= 1)
        {
            on = bool.Parse(args.arguments[0]);
        }


        light.enabled = on;
    }
}
