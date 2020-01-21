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
    [SerializeField] bool isAutoPlayEnabled;

    //State Variables
    [SerializeField]  int currentScore = 0;

    public int Length { get; private set; }

    private void Awake()
    {
        int gameStatusCount = FindObjectOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        else if(gameStatusCount <= 1)
        {
          
            DontDestroyOnLoad(gameObject);
          
        }
    }



   

    // Update is called once per frame
    void Update()
    {
   
        scoreText.text = currentScore.ToString();
        Time.timeScale = gameSpeed;
    }

    //Call from Block.cs make this to PUBLIC
    public void AddToScore() 
    {
        currentScore += ScorePerBlockDestroyed ;
       
    }

    public void ResetGame()
    {
        Destroy(gameObject);
     

    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

}
