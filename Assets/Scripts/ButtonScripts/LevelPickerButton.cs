using UnityEngine;
using System.Collections;
using System;

public class LevelPickerButton : MonoBehaviour {

    public TextMesh textMesh;
    private SpriteRenderer sr;
    private int level;

    void Awake()
    {
        level = Int32.Parse(textMesh.text);
        sr = this.gameObject.GetComponent<SpriteRenderer>();

        // Moved here from update
        if (GameInformation.CompletedLevels[Int32.Parse(textMesh.text) - 1] == 1)
        {
            sr.color = Color.yellow;
        }
    }

    void Update()
    {
        
    }

    void OnTouchDown()
    {
    }

    void OnTouchUp()
    {
        LevelManager.SetLevel(level);
        Application.LoadLevel("Board");
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }
}
