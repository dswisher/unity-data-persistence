using System.Collections;
using System.Collections.Generic;
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
    }
}
