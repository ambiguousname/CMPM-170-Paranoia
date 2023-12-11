using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanoiaMeshRender : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParanoiaManager.AddParanoiaEvent(transform.name + "RecurseMeshRender", RecursiveMeshRender);
    }

    void RecursiveMeshRender(object sender, ParanoiaArgs args)
    {
        bool enabled = false;
        if (args.arguments.Count >= 1)
        {
            enabled = bool.Parse(args.arguments[0]);
        }
        MeshRenderRecurse(transform, enabled);
    }

    void MeshRenderRecurse(Transform t, bool e)
    {
        t.GetComponent<MeshRenderer>().enabled = e;
        for (var i = 0; i < t.childCount; i++) {
            MeshRenderRecurse(t.GetChild(i), e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
