using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Button : MonoBehaviour 
{
    UndoMove undo;
    List<TileScore> undoTiles;
    List<Tile> openedTiles;
    int undoScore = 0;

    Tile touchedTL;
    Tile touchedTM;
    Tile touchedTR;
    Tile touchedL;
    Tile touchedR;
    Tile touchedBL;
    Tile touchedBM;
    Tile touchedBR;

    Tile touchedTile;

    TileCondition tileCondition;
    ScoreScript scoreScript;

    void Awake()
    {
        undo = gameObject.GetComponentInParent<UndoMove>();
        tileCondition = gameObject.GetComponentInParent<TileCondition>();
        scoreScript = gameObject.GetComponentInParent<ScoreScript>();
    }

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        touchedTile = gameObject.GetComponent<Tile>();
        if(!touchedTile.CanTouch)
        {
            return;
        }

        if (tileCondition.GetFirstTouch())
        {
            tileCondition.SetFirstTouch(false);
            tileCondition.DisableTileList();
        }

        undoTiles = new List<TileScore>();
        openedTiles = new List<Tile>();
        undoScore = 0;

        touchedTile.CanTouch = false;
        touchedTile.touchy = touchedTile.CanTouch;
        touchedTile.Value.text = (Int32.Parse(touchedTile.Value.text) + 1).ToString();
        scoreScript.IncreaseScore(10);

        StartCoroutine(touchedTile.RotateDiagonal());

        undoTiles.Add(new TileScore(touchedTile, 1));
        undoScore += 10;

        /*
         *  If there's a non-zero tile next to the touched tile, increment it by one 
         */

        // Top Mid
        if(touchedTile.TopMid != null)
        {
            Adjacent(touchedTile.TopMid.GetComponent<Tile>());
        }
        // Left
        if (touchedTile.Left != null)
        {
            Adjacent(touchedTile.Left.GetComponent<Tile>());
        }
        // Right
        if (touchedTile.Right != null)
        {
            Adjacent(touchedTile.Right.GetComponent<Tile>());
        }
        // Bottom Mid
        if (touchedTile.BottomMid != null)
        {
            Adjacent(touchedTile.BottomMid.GetComponent<Tile>());
        }

        /*
         *  If there's a non-zero tile in a diagonal, take the two adjacent tiles to the diagonal and add them.
         *  Note : The minus one is because we want to take the sum of numbers pre-incrementing.
        */

        // Top Left
        if (touchedTile.TopLeft != null && touchedTile.TopMid != null && touchedTile.Left != null)
        {
            Diagonal(touchedTile.TopLeft.GetComponent<Tile>(), touchedTile.TopMid.GetComponent<Tile>(), touchedTile.Left.GetComponent<Tile>());
        }
        // Top Right
        if (touchedTile.TopRight != null && touchedTile.TopMid != null && touchedTile.Right != null)
        {
            Diagonal(touchedTile.TopRight.GetComponent<Tile>(), touchedTile.TopMid.GetComponent<Tile>(), touchedTile.Right.GetComponent<Tile>());
        }
        // Bot Left
        if (touchedTile.BottomLeft != null && touchedTile.BottomMid != null && touchedTile.Left != null)
        {
            Diagonal(touchedTile.BottomLeft.GetComponent<Tile>(), touchedTile.BottomMid.GetComponent<Tile>(), touchedTile.Left.GetComponent<Tile>());
        }
        // Bot Right
        if (touchedTile.BottomRight != null && touchedTile.BottomMid != null && touchedTile.Right != null)
        {
            Diagonal(touchedTile.BottomRight.GetComponent<Tile>(), touchedTile.BottomMid.GetComponent<Tile>(), touchedTile.Right.GetComponent<Tile>());
        }

        undo.AddUndo(undoTiles, undoScore, openedTiles);

        for (int i = 0; i < undoTiles.Count; i++)
        {
            CheckForWin(undoTiles[i].tile);
        }
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }

    private void Adjacent(Tile tile)
    {
        if (tile.Value.text != "0")
        {
            undoTiles.Add(new TileScore(tile, 1));
            scoreScript.IncreaseScore(10);
            undoScore += 10;
            StartCoroutine(tile.RotateDiagonal());
            tile.Value.text = (Int32.Parse(tile.Value.text) + 1).ToString();
            tile.CanTouch = false;
            tile.touchy = tile.CanTouch;

            if (Int32.Parse(tile.Value.text) >= 10)
            {
                tile.UpdateTileImage();
            }
        }
        else
        {
            if (!tile.CanTouch)
            {
                openedTiles.Add(tile);
            }
            tile.CanTouch = true;
            tile.touchy = tile.CanTouch;
            tile.StartCoroutine(tile.ChangeTileColors());
        }
    }

    private void Diagonal(Tile tile, Tile adjacent1, Tile adjacent2)
    {
        if (adjacent1.Value.text != "0" && adjacent2.Value.text != "0")
        {
            int tileScoreValue = Int32.Parse(adjacent1.Value.text) + Int32.Parse(adjacent2.Value.text) - 2;
            undoTiles.Add(new TileScore(tile, tileScoreValue));
            scoreScript.IncreaseScore(50);
            undoScore += 50;
            StartCoroutine(tile.RotateDiagonal());
            tile.Value.text = (Int32.Parse(tile.Value.text) + Int32.Parse(adjacent1.Value.text) + Int32.Parse(adjacent2.Value.text) - 2).ToString();
            tile.CanTouch = false;
            tile.touchy = tile.CanTouch;

            if (Int32.Parse(tile.Value.text) >= 10)
            {
                tile.UpdateTileImage();
            }
        }
    }

    private void CheckForWin(Tile tile)
    {
        if(tile.IsWinCondition && Int32.Parse(tile.Value.text) >= 10 && !tile.WinMarked)
        {
            tile.WinMarked = true;
            tileCondition.CheckForWin();
        }
    }
}
