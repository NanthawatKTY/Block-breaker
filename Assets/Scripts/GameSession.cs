using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    //Config Paragrams
    [Range(0.1f, 5f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int ScorePerBlockDestroyed = 83;
    [SerializeField] TextMeshProUGUI scoreText;

    //State Variables
    [SerializeField] int currentScore = 0;

    public int Length { get; private set; }

    private void Awake()
    {
        int gameStatusCount = FindObjectOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        scoreText.text = currentScore.ToString(); //Score at Start
    }


    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    //Call from Block.cs make this to PUBLIC
    public void AddToScore() 
    {
        currentScore += ScorePerBlockDestroyed ;
        scoreText.text = currentScore.ToString(); //Score Update
    }

    public void ResetGame()
    {

        scoreText.text = "";
        Destroy(gameObject);

    }

}
