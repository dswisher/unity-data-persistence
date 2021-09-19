using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataMangler : MonoBehaviour
{

    public static DataMangler Instance;

    public string PlayerName { get; set; }

    public string HighPlayerName { get; set; }
    public int HighScore { get; set; }

    private void Awake()
    {
        // If there is already an instance, destroy this new one
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
	    }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }


    public void SaveScore()
    {
        var data = new SaveData
        {
            HighPlayerName = HighPlayerName,
            HighScore = HighScore
        };

        Debug.Log($"Saving high score, player={data.HighPlayerName}, score={data.HighScore}");

        var json = JsonUtility.ToJson(data);

        File.WriteAllText(BuildFileName(), json);
    }


    public void LoadScore()
    {
        var path = BuildFileName();

        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<SaveData>(json);

            HighPlayerName = data.HighPlayerName;
            HighScore = data.HighScore;

            Debug.Log($"Loaded high score, player={HighPlayerName}, score={HighScore}");
	    }
    }


    private string BuildFileName()
    {
        return Application.persistentDataPath + "/savefile.json";
    }


    [Serializable]
    public class SaveData
    {
        public string HighPlayerName;
        public int HighScore;
    }
}
