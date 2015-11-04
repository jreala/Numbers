using UnityEngine;
using System.Collections;

public class ToLevelSelectButton : MonoBehaviour {

    //public AdHandler adHandler;
    public TileCondition tileCondition;

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        if (Application.loadedLevel != 1)
        {
            tileCondition.Restart();
            tileCondition.DisableTileList();
        }
        //adHandler.DestroyBanner();
        Application.LoadLevel("LevelSelect");
    }

    void OnTouchStay()
    {
        //Debug.Log(gameObject.name + " : Stay");
    }

    void OnTouchExit()
    {
        //Debug.Log(gameObject.name + " : Exit");
    }
}
