using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool victory;
    public GameObject gameOverPanel;
    public GameObject VictoryScreen;
    void Start()
    {
        gameOver = false;
        victory = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        if(victory)
        {
            Time.timeScale = 0;
            VictoryScreen.SetActive(true);
        }
    }
}
