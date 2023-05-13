using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Events;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    # region START
    private bool hasGameFinished;

    public static GamePlayManager Instance;

    public List<Color> Colors;

    private void Awake(){

        Instance = this;
        hasGameFinished = false;
        GameManager.Instance.IsInitialized = true;

        score = 0;
        _scoreText.text = score.ToString();
        StartCoroutine(SpawnScore());

    }

    #endregion
     
     #region SCORE

     private int score;
     [SerializeField] private TMP_Text _scoreText;
     [SerializeField] private AudioClip _pointClip;

     public void UpdateScore() {
        score++;
        SoundManager.Instance.PlaySound(_pointClip);
        _scoreText.text = score.ToString();

     }

     [SerializeField] private float _spawnTime;
     [SerializeField] private Score _scorePrefab;

     private Score CurrentScore;

    private IEnumerator SpawnScore() {
        Score prevScore = null;
        while (!hasGameFinished) {
            var tempScore = Instantiate(_scorePrefab);
        if (prevScore == null) {
                CurrentScore = tempScore;
                prevScore = tempScore;
        }
         else {
            prevScore = tempScore;
         }

         yield return new WaitForSeconds(_spawnTime);
    }

    }

     #endregion

     #region  GAME_OVER

     [SerializeField] private AudioClip _loseClip;
     public UnityAction GameEnd;

    public void GameEnded() {
            GameEnd?.Invoke();
            SoundManager.Instance.PlaySound(_loseClip);
            hasGameFinished=true;
            GameManager.Instance.CurrentScore = score;
            StartCoroutine(GameOver());
    }

    private IEnumerator GameOver() {
        yield return new WaitForSeconds(2.0f);
        GameManager.Instance.GoToMainMenu();
    }
     #endregion

}
