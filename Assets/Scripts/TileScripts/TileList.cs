using UnityEngine;
using System.Collections;

public class TileList : MonoBehaviour
{
    public TileCondition tileCondition;
    public Tile[] tileList;
    public int selectedLevel;
    public int[] winningTiles;
    public static float Timer = 0;
    public static bool IncrementTimer = true;

    void Awake()
    {
        tileCondition.Restart();
    }

    void Start()
    {
        Restart();
        StartCoroutine(ControlTimer());
    }

    private IEnumerator ControlTimer()
    {
        while(true)
        {
            while(Timer < 1)
            {
                Timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            while (Timer > 0)
            {
                Timer -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
        }
    }

    public void DisableColliders()
    {
        if (tileList != null && tileList.Length > 0)
        {
            foreach (Tile tile in tileList)
            {
                tile.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    public void EnableColliders()
    {
        if (tileList != null && tileList.Length > 0)
        {
            foreach (Tile tile in tileList)
            {
                tile.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            }
        }
    }

    public void Restart()
    {
        selectedLevel = LevelManager.GetLevel();
        CreateWinningTiles(selectedLevel);
        LoadWinningTiles();
    }

    public Tile[] GetTileList()
    {
        return tileList;
    }

    private void LoadWinningTiles()
    {
        for(int i = 0; i < winningTiles.Length; i++)
        {
            tileList[winningTiles[i]].IsWinCondition = true;
        }
    }

    private void CreateWinningTiles(int level)
    {
        switch (level)
        {
            case 1:
                winningTiles = new int[] { 12 };
                break;
            case 2:
                winningTiles = new int[] { 11, 13 };
                break;
            case 3:
                winningTiles = new int[] { 2, 22 };
                break;
            case 4:
                winningTiles = new int[] { 7, 17 };
                break;
            case 5:
                winningTiles = new int[] { 10, 14 };
                break;
            case 6:
                winningTiles = new int[] { 2, 10, 12, 14 };
                break;
            case 7:
                winningTiles = new int[] { 5, 9, 15, 19 };
                break;
            case 8:
                winningTiles = new int[] { 6, 8, 16, 18 };
                break;
            case 9:
                winningTiles = new int[] { 7, 11, 13, 17 };
                break;
            case 10:
                winningTiles = new int[] { 11, 16, 13, 18, 7 };
                break;
            case 11:
                winningTiles = new int[] { 3, 13, 23, 6, 16 };
                break;
            case 12:
                winningTiles = new int[] { 6, 11, 15, 16, 17 };
                break;
            case 13:
                winningTiles = new int[] { 2, 12, 22, 10, 14 };
                break;
            case 14:
                winningTiles = new int[] { 6, 8, 16, 18, 12 };
                break;
            case 15:
                winningTiles = new int[] { 15, 16, 17, 18, 19 };
                break;
            case 16:
                winningTiles = new int[] { 15, 11, 7, 13, 19 };
                break;
            case 17:
                winningTiles = new int[] { 3, 8, 13, 18, 23 };
                break;
            case 18:
                winningTiles = new int[] { 6, 7, 8, 16, 17, 18 };
                break;
            case 19:
                winningTiles = new int[] { 6, 7, 8, 11, 13, 16, 17, 18 };
                break;
            case 20:
                winningTiles = new int[] { 5, 6, 7, 8, 9, 11, 13, 15, 16, 17, 18, 19 };
                break;
        }
    }
}
