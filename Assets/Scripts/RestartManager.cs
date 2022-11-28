using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartManager : MonoBehaviour
{
    CanvasGroup retry;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}