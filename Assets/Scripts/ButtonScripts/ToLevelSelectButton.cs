using UnityEngine;
using System.Collections;

public class ToLevelSelectButton : MonoBehaviour {

    public TileCondition tileCondition;

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        if (tileCondition != null)
        {
            tileCondition.Restart();
            tileCondition.DisableTileList();
        }
        Application.LoadLevel("LevelSelect");
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
