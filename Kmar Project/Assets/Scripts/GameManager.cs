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

    [Header("UIelements")]
    public Image healthbarImage;
    public Image fuelbarImage;
    public GameObject gameOverScreen;
    public GameObject highscoreScreen;
    public TMP_Text distanceText;
    public TMP_Text pointsText;

    private void Awake()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void speedincrease()
    {
        playermovement.speed += playermovement.speedIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.RoundToInt(player.transform.position.z * 2);
        distanceText.text = distance.ToString() + "m ";
    }
}
