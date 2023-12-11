using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenTrigger : MonoBehaviour
{
    [SerializeField] EndScreen endScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<FirstPersonController>().moveEnabled = false;
            endScreen.endScreen();
        }
    }
}
