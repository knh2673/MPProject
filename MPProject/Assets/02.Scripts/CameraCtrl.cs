////////////////////////////////////////////////////////////////////////////////////////////////////////////
// CameraCtrl.cs
////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Camera Control Class
//
// This class can control main camera movement.
//
// Changes
// 190920 Namhun Kim
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////
public class CameraCtrl : MonoBehaviour
{
    // Transform components
    public Transform targetTr;
    private Transform cameraTr;

    // Camera movement
    private float dist = 10.0f; // distance between target and camera.
    private float height = 2.0f; // height between target and camera.
    private float dampTrace = 20.0f; // soft follow.

    // Camera rotation
    private float rotSpeed = 200.0f; // rotation speed.
    private float xRot; // X rotation.
    private float yRot; // Y rotation.
    private Vector3 dir; // Rotation direction.
    
    void Start()
    {
        cameraTr = this.GetComponent<Transform>();
    }
    
    void LateUpdate()
    {
        FollowCamera();
    }

    // private void FollowCamera()
    //
    // This function sets camera position from target.
    // If target moves, camera follows target.
    //
    // @param    void
    // @return   void
    // 
    // Changes
    // 190920 Namhun Kim
    // Write function.
    private void FollowCamera()
    {
        xRot += Input.GetAxis("Mouse Y") * rotSpeed * Time.deltaTime * -1;
        yRot += Input.GetAxis("Mouse X") * rotSpeed * Time.deltaTime;

        xRot = Mathf.Clamp(xRot, 0.0f, 70.0f);

        dir = Quaternion.Euler(xRot, yRot, 0f) * Vector3.forward;

        // Set camera position
        cameraTr.position = Vector3.Lerp(
            cameraTr.position,
            targetTr.position - (dir * dist) + (dir * height), // backward as much as distance, up as much as height
            Time.deltaTime * dampTrace 
            );

        // Set camera to look target
        cameraTr.LookAt(targetTr.position);
    }
}
