using UnityEngine;
using System.Collections;

public class TileCondition : MonoBehaviour {

    private static int numWinTiles = 0;
    private static int completedTiles = 0;
    private Tile[] tiles;

    private static bool FirstTouch = true;

    private ScoreScript scoreScript;

    public TileList tileList;
    public GameObject winBoard;

    void Awake()
    {
        scoreScript = gameObject.GetComponent<ScoreScript>();
    }

    public void Restart()
    {
        tileList.Restart();
        SetFirstTouch(true);
        tiles = tileList.GetTileList();
        numWinTiles = 0;
        completedTiles = 0;
        HowManyWinTiles();
    }

    public bool GetFirstTouch()
    {
        return FirstTouch;
    }

    public void SetFirstTouch(bool touch)
    {
        FirstTouch = touch;
    }

    public int NumberOfWinTiles()
    {
        return numWinTiles;
    }

    public int NumberOfCompletedTiles()
    {
        return completedTiles;
    }

    public void DisableTileList()
    {
        tiles = tileList.GetTileList();
        foreach (Tile tile in tiles)
        {
            tile.CanTouch = false;
            tile.touchy = tile.CanTouch;
        }
    }

    public static void DecreaseCompletedTiles()
    {
        completedTiles--;
    }

    public void CheckForWin()
    {
        completedTiles++;
                
        if (completedTiles >= numWinTiles)
        {
            Win();
        }
    }
    
    /*
     *  Private Classes 
     */

    private void HowManyWinTiles()
    {
        foreach (Tile tile in tiles)
        {
            if(tile.IsWinCondition)
            {
                numWinTiles++;
            }
        }
    }

    public void Win()
    {
        GameInformation.CompletedLevel(LevelManager.GetLevel());
        GameInformation.CheckHighScore(LevelManager.GetLevel(), scoreScript.GetFinalScore());
        SaveLoad.SaveGameInformation();
        winBoard.SetActive(true);
    }

}
