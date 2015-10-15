using UnityEngine;
using System.Collections;

public class ToCredits : MonoBehaviour {

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        Application.LoadLevel("Credits");
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
