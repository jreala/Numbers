using UnityEngine;
using System.Collections;

public class WinBoard : MonoBehaviour {

    public MenuSystem menuSystem;
    public ScoreScript scoreScript;
    public TextMesh pointText;

    void OnEnable()
    {
        menuSystem.currentGameState = GameState.Win;
        pointText.text = scoreScript.GetScore();
    }

}
