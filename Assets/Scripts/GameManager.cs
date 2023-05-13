using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            init();
            return;
        }
        else {
            Destroy(gameObject);
        }
    }

    private const string highScoreKey = "HighScore";

    public int HighScore
    {
        get
        {
            return PlayerPrefs.GetInt(highScoreKey,0);
        }
        set
        {
            PlayerPrefs.SetInt(highScoreKey, value);
        }
    }

    public bool IsInitialized { get; set;}
    public int CurrentScore { get; set;}

    private void init() {
        CurrentScore = 0;
        IsInitialized = false;
    }

    private const string MainMenu = "MainMenu";
    private const string GamePlay = "GamePlay";

    public void GoToMainMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu);
    }

      public void GoToGamePlay() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(GamePlay);
    }
}
 