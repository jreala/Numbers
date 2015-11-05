using UnityEngine;
using System.Collections;

public class ToMenuButton : MonoBehaviour {

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        Application.LoadLevel("Menu");
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
