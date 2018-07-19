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

    //public GameObject PlayerSpawnPoint, EnemySpawnPoint1, EnemySpawnPoint2, EnemySpawnPoint3, EnemySpawnPoint4;

    private bool gameOver, restart;
    // Use this for initialization
    void Start ()
    {
        gameOver = false;
        restart = false;
        RestartText.enabled = false;
        LoseText.enabled = false;
        WinText.enabled = false;
        NameText.enabled = false;
    }

    public void GameOver()
    {
        gameOver = true;
        LoseText.enabled = true;
        RestartText.enabled = true;
        restart = true;
    }

    public void WinScreen()
    {
        gameOver = true;
        WinText.enabled = true;
        RestartText.enabled = true;
        restart = true;
    }
	// Update is called once per frame
	void Update () {
	    if (restart && Input.GetKeyDown(KeyCode.R))
	    {
	        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	    }
	}
}
