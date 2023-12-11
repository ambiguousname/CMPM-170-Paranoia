using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanoiaCameraSkybox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParanoiaManager.AddParanoiaEvent("CameraSkyboxClear", SkyboxClear);
    }

    void SkyboxClear(object sender, ParanoiaArgs args)
    {
        if (TryGetComponent(out Camera cam))
        {
            cam.clearFlags = CameraClearFlags.SolidColor;
        }
    }
}
