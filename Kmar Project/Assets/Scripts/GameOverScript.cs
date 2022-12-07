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
        //unlocks the MouseCursor
        Cursor.lockState = CursorLockMode.None;

        //adds score from the GameManager to the ScoreText on the gameOverScreen
        scoreText.text = ("Score: ") + GameManager.instance.distanceText.text;
        
        //adds kills from the gameManager to the killtext on the gameOverScreens
        killsText.text = GameManager.instance.pointsText.text;

        // sets highscoreScreen active if the highscore bool in the gameManager is set to true 
        if (GameManager.instance.highscore == true)
        {
            GameManager.instance.highscoreScreen.SetActive(true);
        }
    }

    public void Restart()
    {
        //restarts this level
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu()
    {
        //loads the MainMenuScene
        SceneManager.LoadScene("MainMenuScene");
    }

}
