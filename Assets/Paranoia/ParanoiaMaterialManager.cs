using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParanoiaMaterialManager : MonoBehaviour
{
    public string managerName = "ParanoiaMaterial";
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        ParanoiaManager.AddParanoiaEvent(managerName + "EmissionColor", EmissionColor);
        ParanoiaManager.AddParanoiaEvent(managerName + "EmissionColorIntensity", EmissionColorIntensity);
    }

    private void EmissionColorIntensity(object sender, ParanoiaArgs args)
    {
        Color c = mat.GetColor("_EmissionColor");
        float intensity = 1;
        if (args.arguments.Count >= 1)
        {
            intensity = float.Parse(args.arguments[0]);
        }
        c.r *= intensity;
        c.g *= intensity;
        c.b *= intensity;
        mat.SetColor("_EmissionColor", c);
    }

    private void EmissionColor(object sender, ParanoiaArgs args)
    {
        Color c = Color.black;
        if (args.arguments.Count >= 1)
        {
            ColorUtility.TryParseHtmlString(args.arguments[0], out c);
        }
        mat.SetColor("_EmissionColor", c);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
