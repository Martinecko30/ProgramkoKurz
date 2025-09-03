using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Bird bird;
    [SerializeField] private PillairSpawner pillairSpawner;

    [SerializeField] private GameObject scoreObject;
    [SerializeField] private GameObject deathScreen;
    
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;

    private void Start()
    {
        Restart();
    }

    public void OpenDeathScreen()
    {
        deathScreen.SetActive(true);
        scoreObject.SetActive(false);

        scoreText.text = bird.Score.ToString();
        highScoreText.text = $"Highscore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
    
    public void Restart()
    {
        pillairSpawner.ClearAllPillairs();
        bird.transform.position = Vector3.zero;
        scoreObject.SetActive(true);
        deathScreen.SetActive(false);
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
