using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int BreakableBlocks; // Serialzed for debugging purposes

    public void CountBreakableBlocks()
    {
        BreakableBlocks++;

    }
    
}
