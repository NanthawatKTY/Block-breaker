using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Config Parameters
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits ; //Show only x ais it's 0-16 from L to R
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y); // x=mousePos , y=Already its pos

        //limit & stop paddle going off the screen by serialize variables for min and max
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX , maxX); 
        transform.position = paddlePos;

    }
}
