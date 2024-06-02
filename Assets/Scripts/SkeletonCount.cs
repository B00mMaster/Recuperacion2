using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkeletonCount : MonoBehaviour
{
    public GameObject[] skeleton;
    
    void Update()
    {
        SkDead();
    }

    void SkDead()
    {
        bool skDead = true;
        
        //each skeleton  is stored
        foreach (GameObject sk in skeleton)
        {
            if (sk != null)
            {
                //access the other if when sk desappear
                skDead = false;
                break;
            }
        }
        if (skDead)
        {
            SceneManager.LoadScene("YouWin");
        }
    }
}
