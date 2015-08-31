using UnityEngine;
using System.Collections;

public class RestartLevelButton : MonoBehaviour {

    public AdHandler adHandler;
    public TileCondition tileCondition;

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        adHandler.DestroyBanner();

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
