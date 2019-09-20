////////////////////////////////////////////////////////////////////////////////////////////////////////////
// GameMgr.cs
////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Game Manager Class
//
// This class can manage all of game logics
//
// Changes
// 190920 Namhun Kim
// Write class
////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class GameMgr : MonoBehaviour
{
    private GameObject[] zombies; // Zombies object pool.
    private GameObject minDistObj = null; // Minimum distance object.

    void Start()
    {
        zombies = GameObject.FindGameObjectsWithTag("ZOMBIE");

        // Error
        if(zombies == null)
        {
            Debug.Log("Can't find Zombie objects");
        }
    }
    
    void Update()
    {
        FindMinDistZombie();
    }
    
    // private void FindMinDistZombie()
    //
    // This function finds Zombie object minimum distance.
    // Compare to the previous object, and if the new object is smaller, renew it.
    // After find min distance object, change color to red.
    //
    // @param    void
    // @return   void
    //
    // Changes
    // 190920 Namhun Kim
    // Write function.
    private void FindMinDistZombie()
    {
        // Error
        if(zombies == null)
        {
            Debug.Log("Can't find Zombie objects");
            return;
        }

        // Finds min distance object
        foreach (GameObject _zombie in zombies)
        {
            if (minDistObj == null) // minDistObj is empty
            {
                minDistObj = _zombie;
            }
            else if(minDistObj == _zombie) // If doesn't change before, continue loop.
            {
                continue;
            }
            else if (minDistObj.GetComponent<ZombieCtrl>().distance >_zombie.GetComponent<ZombieCtrl>().distance)
            {
                minDistObj.GetComponent<MeshRenderer>().material.color = Color.blue; // Change color to blue again.
                minDistObj = _zombie; // New min distance object.
            }
        }

        minDistObj.GetComponent<MeshRenderer>().material.color = Color.red; // Change color to red.
    }
}
