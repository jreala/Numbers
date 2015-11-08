using UnityEngine;
using System.Collections;
using System;

public class ScoreScript : MonoBehaviour {

    public TextMesh scoreText;
    public TextMesh highScore;
    public TileList tileList;
    private int points;
    private int finalScore;

	void Awake () 
    {
        highScore.text = GameInformation.HighScoresOnLevels[LevelManager.GetLevel()-1].ToString();
        scoreText.text = "0";
        points = 0;
	}
	
    public void IncreaseScore(int amount)
    {
        points += amount;
        scoreText.text = Convert.ToString(points);
    }

    public void DecreaseScore(int amount)
    {
        points -= amount;
        scoreText.text = Convert.ToString(points);
    }

    public string GetScore()
    {
        return Convert.ToString(points); 
    }

    public int GetFinalScore()
    {
        return points;
    }

    public string FinalCalculation()
    {
        // Point Modifier = For Each Win Tile, (Win Tile - 10) / 100
        int pointMultiplier = 0;

        int[] winningTiles = tileList.winningTiles;
        Tile[] tiles = tileList.GetTileList();
        for(int i = 0; i < winningTiles.Length; i++)
        {
            pointMultiplier += (Convert.ToInt32(tiles[winningTiles[i]].Value.text) - 10) / 10;
        }

        finalScore = points + (points * pointMultiplier);

        return finalScore.ToString();
    }
}
