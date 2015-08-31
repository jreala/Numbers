using UnityEngine;
using System.Collections;

public class ToMenuButton : MonoBehaviour {

    public AdHandler adHandler;

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        adHandler.DestroyBanner();
        Application.LoadLevel("Menu");
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
