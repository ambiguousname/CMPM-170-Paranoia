using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{

    [SerializeField] GameObject[] _textMeshes;
    Canvas _canvas;

    private void Start()
    {
        _canvas = GetComponent<Canvas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("MonsterTest", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            Application.Quit();
        }
    }

    public void endScreen()
    {
        _canvas.enabled = true;
        StartCoroutine(CycleText());
    }

    IEnumerator CycleText() 
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < _textMeshes.Length; i++) 
        {
            _textMeshes[i].SetActive(true);
            if (i < _textMeshes.Length - 1)
            {
                yield return new WaitForSeconds(3);
                _textMeshes[i].SetActive(false);
                yield return new WaitForSeconds(1);
            }
        }
    }
}
