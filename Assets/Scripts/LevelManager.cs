using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    private static int levelSelected = 0;

    public static int GetLevel()
    {
        return levelSelected;
    }

    public static void SetLevel(int levelChosen)
    {
        levelSelected = levelChosen;
    }
}
