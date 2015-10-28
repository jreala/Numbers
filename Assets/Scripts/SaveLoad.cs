using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {

    private static string path = Application.persistentDataPath;

    public static void SaveGameInformation()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Open(path + "/progress.gd", FileMode.OpenOrCreate);
        //Debug.Log(path);
        ProgressTracker data = new ProgressTracker();
        data.levelCompleted = GameInformation.CompletedLevels;
        data.highScores = GameInformation.HighScoresOnLevels;

        binaryFormatter.Serialize(file, data);
        file.Close();
    }

    public static void LoadGameInformation()
    {
        if (File.Exists(path + "/progress.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path + "/progress.gd", FileMode.Open);
            ProgressTracker data = (ProgressTracker)bf.Deserialize(file);
            file.Close();

            GameInformation.CompletedLevels = data.levelCompleted;
            GameInformation.HighScoresOnLevels = data.highScores;
        }
    }
}
