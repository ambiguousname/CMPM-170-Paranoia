using StarterAssets;
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
        if (args.arguments.Count > 0)
        {

            bool enabled = bool.Parse(args.arguments[0]);
            transform.GetChild(0).gameObject.SetActive(enabled);
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<FirstPersonController>().moveEnabled = !enabled;
        }
    }
}
