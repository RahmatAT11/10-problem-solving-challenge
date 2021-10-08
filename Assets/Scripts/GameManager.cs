using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            if (_instance == null)
            {
                Debug.LogError("GameManager not found!");
            }

            return _instance;
        }
    }

    private float scoreLimit = 10f;
    public bool isGameOver = false;

    private void Update()
    {
        if (ScoreManager.Instance.Score > scoreLimit)
        {
            isGameOver = true;
            UIManager.Instance.SetGameOverPanelActive();
        }
    }

    public void GameOver()
    {
        if (isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
