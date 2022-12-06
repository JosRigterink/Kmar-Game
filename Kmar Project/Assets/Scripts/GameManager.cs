using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] GameObject player;
    [SerializeField] PlayerMovement playermovement;

    public int distance;
    public int points;

    [Header("UIelements")]
    public GameObject gameOverScreen;
    public GameObject highscoreScreen;

    private void Awake()
    {
        instance = this;
    }

    public void speedincrease()
    {
        playermovement.speed += playermovement.speedIncrease;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.RoundToInt(player.transform.position.z);
    }
}
