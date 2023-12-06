using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupTrigger : MonoBehaviour
{
    [SerializeField] GameObject playerItem;

    private void OnTriggerEnter(Collider other)
    {
        playerItem.SetActive(true);
    }
}
