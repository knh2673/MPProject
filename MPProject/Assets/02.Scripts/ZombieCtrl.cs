////////////////////////////////////////////////////////////////////////////////////////////////////////////
// ZombieCtrl.cs
////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Zombie Control Class
//
// This class can control each zombie objects.
//
// Changes
// 190920 Namhun Kim
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class ZombieCtrl : MonoBehaviour
{
    private Transform zombieTr; // Zombie transform.
    private Transform playerTr; // Player transform.
    private float dist; // Distance between target and zombie.

    public float distance
    {
        get
        {
            return dist;
        }
    }
    
    void Start()
    {
        zombieTr = this.GetComponent<Transform>();
        playerTr = GameObject.FindGameObjectWithTag("PLAYER").GetComponent<Transform>();

        this.GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    
    void Update()
    {
        dist = Vector3.Distance(zombieTr.position, playerTr.position);
    }
}
