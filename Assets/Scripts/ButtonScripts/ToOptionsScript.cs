using UnityEngine;
using System.Collections;

public class ToOptionsScript : MonoBehaviour {

    public TileCondition tileCondition;

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        if (Application.loadedLevelName != "Menu" && Application.loadedLevelName != "Options" && Application.loadedLevelName != "Tutorial" && Application.loadedLevelName != "Tutorial2")
        {
            tileCondition.Restart();
            tileCondition.DisableTileList();
        }
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
