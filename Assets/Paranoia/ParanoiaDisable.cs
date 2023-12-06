using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanoiaDisable : MonoBehaviour
{
    public int childIndex = 0;
    public string eventName = "ChildDisable";
    // Start is called before the first frame update
    void Start()
    {
        ParanoiaManager.AddParanoiaEvent(eventName, ChildDisable);
    }

    void ChildDisable(object sender, ParanoiaArgs args)
    {
        bool enabled = false;

        if (args.arguments.Count >= 1)
        {
            enabled = bool.Parse(args.arguments[0]);
        }

        transform.GetChild(childIndex).gameObject.SetActive(enabled);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
