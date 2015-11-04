using UnityEngine;
using System.Collections;

public enum GameState
{
    Playing = 0,
    Paused = 1,
    Win = 2
};

public class MenuSystem : MonoBehaviour {

    public GameObject[] objects;
    public GameObject pauseMenu;

    // 0 none, 1 pause, 2 win
    //public int IsPaused = 0;

    public GameState currentGameState = GameState.Playing;

	// Update is called once per frame
	void Update () 
    {
        GameStateSwitch();   
	}

    private void GameStateSwitch()
    {
        if (currentGameState != GameState.Win)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (currentGameState == GameState.Paused)
                {
                    currentGameState = GameState.Playing;
                }
                else
                {
                    currentGameState = GameState.Paused;
                }
            }
        }

        switch (currentGameState)
        {
            case GameState.Paused:
                Time.timeScale = 0;
                PauseGame();
                break;
            case GameState.Playing:
                Time.timeScale = 1;
                UnPauseGame();
                break;
            case GameState.Win:
                Time.timeScale = 1;
                WinGame();
                break;
        }
    }

    private void WinGame()
    {
        DisableObjects();
    }

    private void UnPauseGame()
    {
        EnableObjects();
        pauseMenu.SetActive(false);
        
    }

    private void PauseGame()
    {
        // Show Pause Menu
        pauseMenu.SetActive(true);

        // Disable any buttons or other objects in the screen.
        DisableObjects();
    }

    private void DisableObjects()
    {
        if (objects != null && objects.Length > 0)
        {
            foreach (GameObject obj in objects)
            {
                BoxCollider2D[] children = obj.GetComponentsInChildren<BoxCollider2D>();
                foreach(BoxCollider2D child in children)
                {
                    child.enabled = false;
                }

                if (obj.GetComponent<BoxCollider2D>() != null)
                {
                    obj.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }

    private void EnableObjects()
    {
        if (objects != null && objects.Length > 0)
        {
            foreach (GameObject obj in objects)
            {
                BoxCollider2D[] children = obj.GetComponentsInChildren<BoxCollider2D>();
                foreach (BoxCollider2D child in children)
                {
                    child.enabled = true;
                }

                if (obj.GetComponent<BoxCollider2D>() != null)
                {
                    obj.GetComponent<BoxCollider2D>().enabled = true;
                }
            }
        }
    }

}
