using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //main menu highscoreText
    [SerializeField] TMP_Text highscoreText;

    void Start()
    {
        //highscoretext gets set to the highscore Playerpref in the main menu
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void PlayGame()
    {
        //loads the levelscene
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        //Quit the Application
        Application.Quit();
        Debug.Log("Quit!");
    }
}
