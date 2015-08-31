using UnityEngine;
using System.Collections;
using System;

public class Button : MonoBehaviour 
{
    Tile touchedTL;
    Tile touchedTM;
    Tile touchedTR;
    Tile touchedL;
    Tile touchedR;
    Tile touchedBL;
    Tile touchedBM;
    Tile touchedBR;

    TileCondition tileCondition;
    ScoreScript scoreScript;

    void Awake()
    {
        tileCondition = gameObject.GetComponentInParent<TileCondition>();
        scoreScript = gameObject.GetComponentInParent<ScoreScript>();
    }

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        Tile touchedTile = gameObject.GetComponent<Tile>();
        if(!touchedTile.CanTouch)
        {
            return;
        }

        if (tileCondition.GetFirstTouch())
        {
            tileCondition.SetFirstTouch(false);
            tileCondition.DisableTileList();
        }

        touchedTile.CanTouch = false;
        touchedTile.touchy = touchedTile.CanTouch;
        touchedTile.Value.text = (Int32.Parse(touchedTile.Value.text) + 1).ToString();
        scoreScript.IncreaseScore(10);

        StartCoroutine(touchedTile.RotateDiagonal());

        /*
         *  If there's a non-zero tile next to the touched tile, increment it by one 
         */

        if (touchedTile.TopMid != null)
        {
            touchedTM = touchedTile.TopMid.GetComponent<Tile>();
            if (touchedTM.Value.text != "0")
            {
                scoreScript.IncreaseScore(10);
                StartCoroutine(touchedTM.RotateDiagonal());
                touchedTM.Value.text = (Int32.Parse(touchedTM.Value.text) + 1).ToString();
                touchedTM.CanTouch = false;
                touchedTM.touchy = touchedTM.CanTouch;

                if (Int32.Parse(touchedTM.Value.text) >= 10)
                {
                    touchedTM.UpdateTileImage();
                }
            }
            else
            {
                touchedTM.CanTouch = true;
                touchedTM.touchy = touchedTM.CanTouch;
                touchedTM.StartCoroutine(touchedTM.ChangeTileColors());
            }
        }

        if (touchedTile.Left != null)
        {
            touchedL = touchedTile.Left.GetComponent<Tile>();
            if (touchedL.Value.text != "0")
            {
                scoreScript.IncreaseScore(10);
                StartCoroutine(touchedL.RotateDiagonal());
                touchedL.Value.text = (Int32.Parse(touchedL.Value.text) + 1).ToString();
                touchedL.CanTouch = false;
                touchedL.touchy = touchedL.CanTouch;
                
                if (Int32.Parse(touchedL.Value.text) >= 10)
                {
                    touchedL.UpdateTileImage();
                }
            }
            else
            {
                touchedL.CanTouch = true;
                touchedL.touchy = touchedL.CanTouch;
                touchedL.StartCoroutine(touchedL.ChangeTileColors());
            }
        }

        if (touchedTile.Right != null)
        {
            touchedR = touchedTile.Right.GetComponent<Tile>();
            if (touchedR.Value.text != "0")
            {
                scoreScript.IncreaseScore(10);
                StartCoroutine(touchedR.RotateDiagonal());
                touchedR.Value.text = (Int32.Parse(touchedR.Value.text) + 1).ToString();
                touchedR.CanTouch = false;
                touchedR.touchy = touchedR.CanTouch;

                if (Int32.Parse(touchedR.Value.text) >= 10)
                {
                    touchedR.UpdateTileImage();
                }
            }
            else
            {
                touchedR.CanTouch = true;
                touchedR.touchy = touchedR.CanTouch;
                touchedR.StartCoroutine(touchedR.ChangeTileColors());
            }
        }

        if (touchedTile.BottomMid != null)
        {
            touchedBM = touchedTile.BottomMid.GetComponent<Tile>();
            if (touchedBM.Value.text != "0")
            {
                scoreScript.IncreaseScore(10);
                StartCoroutine(touchedBM.RotateDiagonal());
                touchedBM.Value.text = (Int32.Parse(touchedBM.Value.text) + 1).ToString();
                touchedBM.CanTouch = false;
                touchedBM.touchy = touchedBM.CanTouch;

                if (Int32.Parse(touchedBM.Value.text) >= 10)
                {
                    touchedBM.UpdateTileImage();
                }
            }
            else
            {
                touchedBM.CanTouch = true;
                touchedBM.touchy = touchedBM.CanTouch;
                touchedBM.StartCoroutine(touchedBM.ChangeTileColors());
            }
        }

        /*
         *  If there's a non-zero tile in a diagonal, take the two adjacent tiles to the diagonal and add them.
         *  Note : The minus one is because we want to take the sum of numbers pre-incrementing.
        */

        if (touchedTile.TopLeft != null)
        {
            touchedTL = touchedTile.TopLeft.GetComponent<Tile>();

            if (touchedTM.Value.text != "0" && touchedL.Value.text != "0")
            {
                scoreScript.IncreaseScore(50);
                StartCoroutine(touchedTL.RotateDiagonal());
                touchedTL.Value.text = (Int32.Parse(touchedTL.Value.text) + Int32.Parse(touchedTM.Value.text) + Int32.Parse(touchedL.Value.text) - 2).ToString();
                touchedTL.CanTouch = false;
                touchedTL.touchy = touchedTL.CanTouch;

                if (Int32.Parse(touchedTL.Value.text) >= 10)
                {
                    touchedTL.UpdateTileImage();
                }
            }
        }

        if (touchedTile.TopRight != null)
        {
            touchedTR = touchedTile.TopRight.GetComponent<Tile>();
            if (touchedTM.Value.text != "0" && touchedR.Value.text != "0")
            {
                scoreScript.IncreaseScore(50);
                StartCoroutine(touchedTR.RotateDiagonal());
                touchedTR.Value.text = (Int32.Parse(touchedTR.Value.text) + Int32.Parse(touchedTM.Value.text) + Int32.Parse(touchedR.Value.text) - 2).ToString();
                touchedTR.CanTouch = false;
                touchedTR.touchy = touchedTR.CanTouch;

                if (Int32.Parse(touchedTR.Value.text) >= 10)
                {
                    touchedTR.UpdateTileImage();
                }
            }
        }

        if (touchedTile.BottomLeft != null)
        {
            touchedBL = touchedTile.BottomLeft.GetComponent<Tile>();
            if (touchedBM.Value.text != "0" && touchedL.Value.text != "0")
            {
                scoreScript.IncreaseScore(50);
                StartCoroutine(touchedBL.RotateDiagonal());
                touchedBL.Value.text = (Int32.Parse(touchedBL.Value.text) + Int32.Parse(touchedBM.Value.text) + Int32.Parse(touchedL.Value.text) - 2).ToString();
                touchedBL.CanTouch = false;
                touchedBL.touchy = touchedBL.CanTouch;

                if (Int32.Parse(touchedBL.Value.text) >= 10)
                {
                    touchedBL.UpdateTileImage();
                }
            }
        }

        if (touchedTile.BottomRight != null)
        {
            touchedBR = touchedTile.BottomRight.GetComponent<Tile>();
            if (touchedBM.Value.text != "0" && touchedR.Value.text != "0")
            {
                scoreScript.IncreaseScore(50);
                StartCoroutine(touchedBR.RotateDiagonal());
                touchedBR.Value.text = (Int32.Parse(touchedBR.Value.text) + Int32.Parse(touchedBM.Value.text) + Int32.Parse(touchedR.Value.text) - 2).ToString();
                touchedBR.CanTouch = false;
                touchedBR.touchy = touchedBR.CanTouch;
                
                if (Int32.Parse(touchedBR.Value.text) >= 10)
                {
                    touchedBR.UpdateTileImage();
                }
            }
        }

        touchedTile.ColorTile(Color.blue);

        #region Check for Win

        if (touchedTile != null && touchedTile.IsWinCondition)
        {
            if (Int32.Parse(touchedTile.Value.text) >= 10 && !touchedTile.WinMarked)
            {
                touchedTile.WinMarked = true;
                tileCondition.CheckForWin();
            }
        }

        if (touchedBR != null && touchedBR.IsWinCondition)
        {
            if (Int32.Parse(touchedBR.Value.text) >= 10 && !touchedBR.WinMarked)
            {
                touchedBR.WinMarked = true;
                touchedBR.touchy = touchedBR.CanTouch;
                tileCondition.CheckForWin();
            }
        }

        if (touchedBL != null && touchedBL.IsWinCondition)
        {
            if (Int32.Parse(touchedBL.Value.text) >= 10 && !touchedBL.WinMarked)
            {
                touchedBL.WinMarked = true;
                touchedBL.touchy = touchedBL.CanTouch;
                tileCondition.CheckForWin();
            }
        }

        if (touchedTR != null && touchedTR.IsWinCondition)
        {
            if (Int32.Parse(touchedTR.Value.text) >= 10 && !touchedTR.WinMarked)
            {
                touchedTR.WinMarked = true;
                touchedTR.touchy = touchedTR.CanTouch;
                tileCondition.CheckForWin();
            }
        }

        if (touchedTL != null && touchedTL.IsWinCondition)
        {
            if (Int32.Parse(touchedTL.Value.text) >= 10 && !touchedTL.WinMarked)
            {
                touchedTL.WinMarked = true;
                touchedTL.touchy = touchedTL.CanTouch;
                tileCondition.CheckForWin();
            }
        }

        if (touchedBM != null && touchedBM.IsWinCondition)
        {
            if (Int32.Parse(touchedBM.Value.text) >= 10 && !touchedBM.WinMarked)
            {
                touchedBM.WinMarked = true;
                tileCondition.CheckForWin();
            }
        }

        if (touchedR != null && touchedR.IsWinCondition)
        {
            if (Int32.Parse(touchedR.Value.text) >= 10 && !touchedR.WinMarked)
            {
                touchedR.WinMarked = true;
                tileCondition.CheckForWin();
            }
        }

        if (touchedTM != null && touchedTM.IsWinCondition)
        {
            if (Int32.Parse(touchedTM.Value.text) >= 10 && !touchedTM.WinMarked)
            {
                touchedTM.WinMarked = true;
                tileCondition.CheckForWin();
            }
        }

        if (touchedL != null && touchedL.IsWinCondition)
        {
            if (Int32.Parse(touchedL.Value.text) >= 10 && !touchedL.WinMarked)
            {
                touchedL.WinMarked = true;
                tileCondition.CheckForWin();
            }
        }

        #endregion 
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
