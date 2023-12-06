using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IlluminateTrigger : MonoBehaviour
{
    Light pointLight;
    Material lanternMaterial;
    Color pastEmission;

    private void Start()
    {
        pointLight = GetComponentInChildren<Light>();
        var renderer = GetComponentInParent<MeshRenderer>();
        lanternMaterial = renderer.material;
        pastEmission = lanternMaterial.GetColor("_EmissionColor");
        lanternMaterial.SetColor("_EmissionColor", Color.black);
    }
    private void OnTriggerEnter(Collider other)
    {
        pointLight.enabled = true;
        lanternMaterial.SetColor("_EmissionColor", pastEmission);
    }
}
