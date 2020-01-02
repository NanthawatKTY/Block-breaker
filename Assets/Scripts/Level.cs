using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Parameters
    [SerializeField] int BreakableBlocks; // Serialzed for debugging purposes

    //Cached Reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {
        BreakableBlocks++;

    }

    public void BlockDestroyed()
    {
        BreakableBlocks--;
        if (BreakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
    
}
