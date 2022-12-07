using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] TMP_Text killsText;
    [SerializeField] TMP_Text scoreText;

    void Start()
    {
        scoreText.text = ("Score: ") + GameManager.instance.distanceText.text;
        killsText.text = GameManager.instance.pointsText.text;
        Cursor.lockState = CursorLockMode.None;
        if (GameManager.instance.highscore == true)
        {
            GameManager.instance.highscoreScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

}
