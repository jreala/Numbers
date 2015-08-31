using UnityEngine;
using System.Collections;

public class ToOptionsScript : MonoBehaviour {

    public AdHandler adHandler;
    public TileCondition tileCondition;

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        if (Application.loadedLevel != 0 && Application.loadedLevel != 2)
        {
            tileCondition.Restart();
            tileCondition.DisableTileList();
        }
        adHandler.DestroyBanner();
        Application.LoadLevel("Options");
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
