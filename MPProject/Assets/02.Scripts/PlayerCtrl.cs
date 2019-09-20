////////////////////////////////////////////////////////////////////////////////////////////////////////////
// PlayerCtrl.cs
////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Player Control Class
//
// This class can control all of player's information.
//
// Changes
// 190920 Namhun Kim
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class PlayerCtrl : MonoBehaviour
{
    // Keyboard Input
    private float horizontal; // horizontal
    private float vertical; // vertical

    // Transform component
    public Transform cameraTr; // Camera transform
    private Transform playerTr; // Player transform

    // Player movement
    private float playerSpeed = 10.0f; // movement speed

    void Start()
    {
        playerTr = this.GetComponent<Transform>(); // Get Component from inspector

        horizontal = 0.0f;
        vertical = 0.0f;
    }
    
    void Update()
    {
        //
        // Move player object
        Vector3 _dir = CalculateMoveDir();

        playerTr.Translate(_dir * playerSpeed * Time.deltaTime, Space.Self); // move
    }
    
    
    // private Vector3 CalculateMoveDir()
    //
    // This function calculates moving direction and return direction.
    //
    // @param    void
    // @return   Vector3   Player movement direction.
    // 
    // Changes
    // 190920 Namhun Kim
    // Write function.
    private Vector3 CalculateMoveDir()
    {
        // Get keyboard input
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        // Camera direction
        Vector3 _forward = cameraTr.forward;
        Vector3 _right = cameraTr.right;

        // Fix Y axis
        _forward.y = 0.0f;
        _right.y = 0.0f;

        // Return moving direction
        return _forward * vertical + _right * horizontal;
    }
}
