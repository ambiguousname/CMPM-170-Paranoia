using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IlluminateTrigger : MonoBehaviour
{
    Light pointLight;

    private void Start()
    {
        pointLight = GetComponentInChildren<Light>();
    }
    private void OnTriggerEnter(Collider other)
    {
        pointLight.enabled = true;
    }
}
