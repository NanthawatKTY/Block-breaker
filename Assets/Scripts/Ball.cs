
using UnityEngine;

public class Ball : MonoBehaviour { 

    //config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] float randomFactor = 0.2f;

    //Array
    [SerializeField] AudioClip[] ballSounds;


    //State
    Vector2 paddleToBallVector;
    bool hasStarted = false;


    //Cahced component reference Arraya
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) //if doesn't click mouse
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick() // if click mouse = 0
    {
        
        if (Input.GetMouseButtonDown(0)) 
        {
            hasStarted = true;    //change hasStarted to true
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x , paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }


    //Audio when the ball bounce everything//

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor),Random.Range(0f, randomFactor));
        if (hasStarted) //When the game has started play audio
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
           myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak; 
        }
    }
}
