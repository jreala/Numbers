using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

    private static GameInformation instanceRef;
    private static AudioSource audioSource;

    public static int[] CompletedLevels = new int[20] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    public static int[] HighScoresOnLevels = new int[20] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    void Awake()
    {
        if(instanceRef == null)
        {
            instanceRef = this;
            audioSource = gameObject.GetComponent<AudioSource>();
            
            if (PlayerPrefs.HasKey("VolumeLevel"))
            {
                audioSource.volume = PlayerPrefs.GetFloat("VolumeLevel", 1.0f);
            }
            
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }

        SaveLoad.LoadGameInformation();
        
    }

    public static GameInformation GetInstance()
    {
        return instanceRef;
    }

    public static AudioSource GetAudioSource()
    {
        return audioSource;
    }

    public static void CompletedLevel(int level)
    {
        CompletedLevels[level - 1] = 1;
    }

    public static void CheckHighScore(int level, int score)
    {
        if(score > HighScoresOnLevels[level - 1])
        {
            HighScoresOnLevels[level - 1] = score;
            //Debug.Log("Score swapped! New High Score : " + score);
        }
        else
        { 
            //Debug.Log("Old Score Kept : " + HighScoresOnLevels[level - 1]); 
        }
    }
}
