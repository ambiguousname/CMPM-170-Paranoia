using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IlluminateTrigger : MonoBehaviour
{
    Light pointLight;
    Material lanternMaterial;
    Color pastEmission;

    public bool isFake = false;

    private void Start()
    {
        pointLight = GetComponentInChildren<Light>();
        var renderer = GetComponentInParent<MeshRenderer>();
        lanternMaterial = renderer.material;
        pastEmission = lanternMaterial.GetColor("_EmissionColor");
        lanternMaterial.SetColor("_EmissionColor", Color.black);

        ParanoiaManager.AddParanoiaEvent(transform.parent.name + "Light", Lightable);
        ParanoiaManager.AddParanoiaEvent(transform.parent.name, Delete);
    }

    private void Delete(object sender, ParanoiaArgs args)
    {
        transform.parent.gameObject.SetActive(false);
    }

    private void Lightable(object sender, ParanoiaArgs args)
    {
        bool on = false;
        if (args.arguments.Count >= 1)
        {
            on = bool.Parse(args.arguments[0]);
        }

        pointLight.enabled = on;
        if (!on) {
            lanternMaterial.SetColor("_EmissionColor", Color.black);
        } else
        {
            lanternMaterial.SetColor("_EmissionColor", pastEmission);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isFake) {
            pointLight.enabled = true;
            lanternMaterial.SetColor("_EmissionColor", pastEmission);
            isFake = true;
        }
    }
}
