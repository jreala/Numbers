using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class UndoMove : MonoBehaviour {

    public ScoreScript scoreScript;

    private Dictionary<int, List<TileScore>> undoDict;
    private Dictionary<int, int> undoScoreDict;
    private Dictionary<int, List<Tile>> tilesOpened;

    private int DictPosition { get; set; }

    void Awake()
    {
        undoDict = new Dictionary<int, List<TileScore>>();
        undoScoreDict = new Dictionary<int, int>();
        tilesOpened = new Dictionary<int, List<Tile>>();
        DictPosition = 0;
    }

    public void AddUndo(List<TileScore> tiles, int score, List<Tile> openedTiles)
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
            List<TileScore> tiles = new List<TileScore>();
            if (undoDict.TryGetValue(DictPosition - 1, out tiles))
            {
                foreach (TileScore tile in tiles)
                {
                    if (tiles[0] == tile)
                    {
                        EnableTileTouch(tile);
                        tile.tile.ReEnableColorCoroutine();   
                    }
                    UndoTileWin(tile.tile);
                    LowerTileScore(tile);
                    HideTileScore(tile);
                }
            }
            UndoScore();
            ReformatBoard();
            RemoveLast();
        }
    }

    private void LowerTileScore(TileScore tile)
    {
        if (Int32.Parse(tile.tile.Value.text) > 0)
        {
            tile.tile.Value.text = (Int32.Parse(tile.tile.Value.text) - tile.score).ToString();
        }
        tile.tile.UpdateTileImage();
    }

    public void UndoScore()
    {
        int score;
        if (undoScoreDict.TryGetValue(DictPosition - 1, out score))
        {
            scoreScript.DecreaseScore(score);
        }
    }

    private void HideTileScore(TileScore tile)
    {
        if (Int32.Parse(tile.tile.Value.text) <= 0 || Int32.Parse(tile.tile.Value.text) >= 10)
        {
            tile.tile.Value.GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            tile.tile.Value.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    private void EnableTileTouch(TileScore tile)
    {
        tile.tile.CanTouch = true;
        tile.tile.touchy = true;
    }

    private void UndoTileWin(Tile tile)
    {
        if(tile.IsWinCondition && Int32.Parse(tile.Value.text) >= 10)
        {
            TileCondition.DecreaseCompletedTiles();
            tile.WinMarked = false;
        }
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
