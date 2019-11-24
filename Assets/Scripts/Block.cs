using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip BreakSound;
    
    // Cached reference
    Level level;
   

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();       // call Counting blocks method from Level.cs
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position); //play audio with camera pos.
        Destroy(gameObject);
    }


}
