using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UndoMove : MonoBehaviour {

    public ScoreScript scoreScript;

    private Dictionary<int, List<Tile>> undoDict;
    private Dictionary<int, int> undoScoreDict;
    private Dictionary<int, List<Tile>> tilesOpened;

    private int DictPosition { get; set; }

    void Awake()
    {
        undoDict = new Dictionary<int, List<Tile>>();
        undoScoreDict = new Dictionary<int, int>();
        tilesOpened = new Dictionary<int, List<Tile>>();
        DictPosition = 0;
    }

    public void AddUndo(List<Tile> tiles, int score, List<Tile> openedTiles)
    {
        undoDict[DictPosition] = tiles;
        undoScoreDict[DictPosition] = score;
        tilesOpened[DictPosition] = openedTiles;
        DictPosition += 1;
    }

    private void RemoveLast()
    {
        DictPosition -= 1;
        undoDict.Remove(DictPosition);
        tilesOpened.Remove(DictPosition);
    }

    public void ExecuteUndo()
    {
        if (DictPosition > 1)
        {
            List<Tile> tiles = new List<Tile>();
            if (undoDict.TryGetValue(DictPosition - 1, out tiles))
            {
                foreach (Tile tile in tiles)
                {
                    if (tiles[0] == tile)
                    {
                        EnableTileTouch(tile);
                        tile.ReEnableColorCoroutine();
                    }
                    
                    LowerTileScore(tile);
                    HideTileScore(tile);
                }
            }
            UndoScore();
            ReformatBoard();
            RemoveLast();
        }
    }

    private void LowerTileScore(Tile tile)
    {
        // TODO : Adjust for diagonal as it is not always 1
        if (Int32.Parse(tile.Value.text) > 0)
        {
            tile.Value.text = (Int32.Parse(tile.Value.text) - 1).ToString();
        }
    }

    public void UndoScore()
    {
        int score;
        if (undoScoreDict.TryGetValue(DictPosition - 1, out score))
        {
            scoreScript.DecreaseScore(score);
        }
    }

    private void HideTileScore(Tile tile)
    {
        if(Int32.Parse(tile.Value.text) <= 0)
        {
            tile.Value.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void EnableTileTouch(Tile tile)
    {
        tile.CanTouch = true;
        tile.touchy = true;
    }

    private void ReformatBoard()
    {
        List<Tile> tiles = new List<Tile>();
        if (tilesOpened.TryGetValue(DictPosition - 1, out tiles))
        {
            foreach (Tile tile in tiles)
            {
                tile.CanTouch = false;
                tile.touchy = false;
            }
        }
    }
}
