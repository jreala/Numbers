using UnityEngine;
using System.Collections;

public class SubMenuClose : MonoBehaviour {

    public MenuSystem menuSystem;

    void OnTouchDown()
    {   
    }

    void OnTouchUp()
    {
        menuSystem.currentGameState = GameState.Playing;
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
