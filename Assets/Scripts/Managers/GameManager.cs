using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// GameManager class controlls the display of text during the game and takes care of restarting it and checking win condition
/// 
/// </summary>
public class GameManager : MonoBehaviour
{

    public Text RestartText;
    public Text WinText;
    public Text LoseText;
    public Text NameText;
    public Text HelpText;
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
        NameText.enabled = true;
        HelpText.enabled = true;
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
	    if (Input.anyKeyDown)
	    {
            NameText.enabled = false;
	    }
	    if (Input.GetKeyDown(KeyCode.H))
	    {
	        HelpText.enabled = !HelpText.enabled;
	    }
	    if (Input.GetKeyDown(KeyCode.R))
	    {
            TargetEnemy.VisibleEnemies.Clear();
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
