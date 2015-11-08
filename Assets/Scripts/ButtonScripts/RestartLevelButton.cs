using UnityEngine;
using System.Collections;

public class RestartLevelButton : MonoBehaviour {

    public TileCondition tileCondition;

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        tileCondition.Restart();
        tileCondition.DisableTileList();

        Application.LoadLevel(Application.loadedLevel);
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
