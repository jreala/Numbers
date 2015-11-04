using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoad {

    private static string path = Application.persistentDataPath;

    public static void SaveGameInformation()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Open(path + "/save.ecs", FileMode.OpenOrCreate);

        ProgressTracker data = new ProgressTracker();
        data.levelCompleted = GameInformation.CompletedLevels;
        data.highScores = GameInformation.HighScoresOnLevels;

        binaryFormatter.Serialize(file, data);
        file.Close();
    }

    public static void LoadGameInformation()
    {
        if (File.Exists(path + "/save.ecs"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(path + "/save.ecs", FileMode.Open);
            ProgressTracker data = (ProgressTracker)bf.Deserialize(file);
            file.Close();

            GameInformation.CompletedLevels = data.levelCompleted;
            GameInformation.HighScoresOnLevels = data.highScores;
        }
    }
}
