﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public Vector3 offset;
    private float currentZoom = 10f;

    public float zoomSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    private float pitch = 2f;
    private float yawSpeed = 5f;
    private float currentYaw=0f;
    // Update is called once per frame
    void Update(){
        currentZoom-=Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom=Mathf.Clamp(currentZoom,minZoom,maxZoom);
        
        currentYaw -= target.rotation.x*yawSpeed*Time.deltaTime;
    }
    void LateUpdate()
    {
        transform.position = target.position-offset*currentZoom;
        transform.LookAt(target.position+Vector3.up*pitch);
        transform.RotateAround(target.position, Vector3.up, currentYaw);
        
        
    }
}
