using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip BreakSound;
    [SerializeField] GameObject blockSparklesVFX;     //Create VFX prefab is GameObject  
    
    [SerializeField] Sprite[] hitSprites;
    
    // Cached reference
    Level level;
 
    // State variables
    [SerializeField] int timeHit; // To do only serialized for debug purposes


    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();       // call Counting blocks method from Level.cs
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  //Came from Refactorings method
    {
        if (tag == "Breakable")
        {
            HandleHit();

        }
    }

    private void HandleHit()
    {
        timeHit++;
        int maxHits = hitSprites.Length + 1;
        if (timeHit >= maxHits)
        {
            DestroyedBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timeHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("block sprite is missing from array" + gameObject.name);
        }
        
    }


    //จะไม่ยุ่งอะไรกับตรงนี้มาก so จึงสร้างอีก method โดย Refactorings จนกลายเป็นข้างบน
    private void DestroyedBlock() //Came from Refactorings method 
    {
        PlayBlockDestroSFX();
        Destroy(gameObject); //Call AddToScore() from GameStatus
        
        level.BlockDestroyed(); // Call Decreased Method from Level.cs
        TriggerSparklesVFX();

    }

    private void PlayBlockDestroSFX()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position); //play audio with camera pos.
    }


    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
       Destroy(sparkles, 1f);
    }


}
