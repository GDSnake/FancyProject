using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text RestartText;
    public Text WinText;
    public Text LoseText;
    public Text NameText;
    public int NumberOfEnemies = 4;
   
    
    private bool _gameOver, _restart;
    // Use this for initialization
    void Start ()
    {
        _gameOver = false;
        _restart = false;
        RestartText.enabled = false;
        LoseText.enabled = false;
        WinText.enabled = false;
        NameText.enabled = false;
        
    }

    public void GameOver()
    {
        _gameOver = true;
        LoseText.enabled = true;
        RestartText.enabled = true;
        _restart = true;
    }

    public void WinScreen()
    {
        _gameOver = true;
        WinText.enabled = true;
        RestartText.enabled = true;
        _restart = true;
    }
	// Update is called once per frame
	void Update () {
	    if (_restart && Input.GetKeyDown(KeyCode.R))
	    {
	        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	    }
	}

    public void EnemyKilled()
    {
        NumberOfEnemies--;
        if (NumberOfEnemies == 0)
        {
            WinScreen();
           
        }
    }
}
