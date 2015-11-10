using UnityEngine;
using System.Collections;

public class TileScore
{
    public Tile tile { get; set; }
    public int score { get; set; }
	
    public TileScore(Tile tile, int score)
    {
        this.tile = tile;
        this.score = score;
    }
}
