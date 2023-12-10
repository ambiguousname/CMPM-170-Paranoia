using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotAndCold : MonoBehaviour
{
    Renderer _rend;
    [SerializeField] GameObject goal;

    Color originalColor;
    float startDist;

    // Start is called before the first frame update
    void Start()
    {
        _rend = GetComponent<Renderer>();

        goal.SetActive(true);

        startDist = Vector3.Distance(transform.position, goal.transform.position);
        originalColor = _rend.material.GetColor("_EmissionColor");

    }

    // Update is called once per frame
    void Update()
    {
        float emission = 1 - Vector3.Distance(transform.position, goal.transform.position) / startDist;

        Color finalColor = Color.Lerp(Color.black, originalColor, emission);

        if (_rend != null)
        {
            _rend.material.SetColor("_EmissionColor", finalColor);

        }
    }
}
