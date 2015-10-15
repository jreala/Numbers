using UnityEngine;
using System.Collections;

public class ToTutorialNext : MonoBehaviour {

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        Application.LoadLevel("Tutorial2");
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
