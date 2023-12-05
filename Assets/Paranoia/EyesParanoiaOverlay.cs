using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesParanoiaOverlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ParanoiaManager.AddParanoiaEvent("Eyes", Eyes);
    }

    public void Eyes(object sender, ParanoiaArgs args)
    {
        transform.GetChild(0).gameObject.SetActive(bool.Parse(args.argument));
    }
}
