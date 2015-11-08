using UnityEngine;
using System.Collections;

public class UndoButton : MonoBehaviour {

    public UndoMove undo;

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        undo.ExecuteUndo();
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
