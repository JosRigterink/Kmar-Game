using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]
    [SerializeField] GameObject player; 
    [HideInInspector]
    [SerializeField] PlayerMovement playermovement;

    [Header("User Stats")]
    public int distance;    //distance traveled by player
    public int kills;       // kills made by player

    [HideInInspector]
    public bool highscore;   //has achieved highscore

    [Header("Uielements")]
    public Image healthbarImage; 
    public Image fuelbarImage;     
    public GameObject gameOverScreen;  
    public GameObject highscoreScreen;

    [Header("UiTextElements")]
    public TMP_Text distanceText;   
    public TMP_Text pointsText;     //kills made by player in text
    public TMP_Text highscoreText;  //highscore of the player on text on the highscoreScreen
    public TMP_Text highscoreUI;    //highscore in game UI realtime

    private void Awake()
    {
        //makes the gameManager an instance
        instance = this;
        //locks mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        //sets the texts same as the HighScore playerpref in text
        highscoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        highscoreUI.text = "Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    } 

    public void HighScore()
    {
        //if distance is more then the playerpref highscore then that distance will be the new highscore and it will be updated on UI
        if (distance > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", distance);
            highscoreText.text = "Highscore: " + distance.ToString();
            highscoreUI.text = "Highscore: " + distance.ToString();
            highscore = true;
        }
    }

    void Update()
    {
        //keeps track of how far player has traveled and updates it on ui
        distance = Mathf.RoundToInt(player.transform.position.z * 2);
        distanceText.text = distance.ToString() + "m ";
        HighScore();
    }
}
