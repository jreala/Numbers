using UnityEngine;
using System.Collections;
using System;

public class LevelPickerButton : MonoBehaviour {

    public TextMesh textMesh;
    private SpriteRenderer sr;
    private int level;
    private int[] lockedLevels = new int[20] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    void Awake()
    {
        level = Int32.Parse(textMesh.text);
        sr = this.gameObject.GetComponent<SpriteRenderer>();

        // Moved here from update
        if (GameInformation.CompletedLevels[level - 1] == 1)
        {
            sr.color = Color.yellow;
        }

        LockLevels();

        if(lockedLevels[level - 1] == 1)
        {
            sr.color = Color.gray;
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
        if (lockedLevels[level - 1] != 1)
        {
            LevelManager.SetLevel(level);
            Application.LoadLevel("Board");
        }
    }

    void OnTouchStay()
    {
    }

    void OnTouchExit()
    {
    }

    private void LockLevels()
    {
        int[] completedLevels = GameInformation.CompletedLevels;
        if (completedLevels[0] != 1 || completedLevels[1] != 1 || completedLevels[2] != 1 || completedLevels[3] != 1 || completedLevels[4] != 1)
        {
            lockedLevels[5] = 1;
            lockedLevels[6] = 1;
            lockedLevels[7] = 1;
            lockedLevels[8] = 1;
            lockedLevels[9] = 1;
        }

        if (completedLevels[5] != 1 || completedLevels[6] != 1 || completedLevels[7] != 1 || completedLevels[8] != 1 || completedLevels[9] != 1)
        {
            lockedLevels[10] = 1;
            lockedLevels[11] = 1;
            lockedLevels[12] = 1;
            lockedLevels[13] = 1;
            lockedLevels[14] = 1;
        }
        if (completedLevels[10] != 1 || completedLevels[11] != 1 || completedLevels[12] != 1 || completedLevels[13] != 1 || completedLevels[14] != 1)
        {
            lockedLevels[15] = 1;
            lockedLevels[16] = 1;
            lockedLevels[17] = 1;
            lockedLevels[18] = 1;
            lockedLevels[19] = 1;
        }
    }
}
