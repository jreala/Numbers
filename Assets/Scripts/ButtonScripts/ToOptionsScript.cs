using UnityEngine;
using System.Collections;

public class ToOptionsScript : MonoBehaviour {

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
        Application.LoadLevel("Options");
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
