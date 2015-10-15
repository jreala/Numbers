using UnityEngine;
using System.Collections;

public class ToTutorial : MonoBehaviour {

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        Application.LoadLevel("Tutorial");
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
