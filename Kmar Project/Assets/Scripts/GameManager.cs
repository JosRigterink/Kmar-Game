using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement playermovement;

    public int distance;
    public int kills;
    public bool highscore;

    [Header("UIelements")]
    public Image healthbarImage;
    public Image fuelbarImage;
    public GameObject gameOverScreen;
    public GameObject highscoreScreen;
    public TMP_Text distanceText;
    public TMP_Text pointsText;
    public TMP_Text highscoreText;
    public TMP_Text highscoreUI;

    private void Awake()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        highscoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        highscoreUI.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    } 

    public void HighScore()
    {
        if (distance > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", distance);
            highscoreText.text = "Highscore: " + distance.ToString();
            highscoreUI.text = "Highscore: " + distance.ToString();
            highscore = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.RoundToInt(player.transform.position.z * 2);
        distanceText.text = distance.ToString() + "m ";
        HighScore();
    }
}
