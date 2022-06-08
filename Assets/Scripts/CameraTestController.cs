using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraTestController : MonoBehaviour
{
    public GameObject playerController;
    public Vector3 distance;
    public GameObject SpeedTrailEffectPrefab;
    public bool cameraStart = false;
    public bool cameraDistance = false;

    private void Start()
    {
        distance = transform.position - playerController.transform.position;
    }

    public void LateUpdate()
    {
        
            transform.position = new Vector3(distance.x + playerController.transform.position.x, transform.position.y,
                distance.z + playerController.transform.position.z);
    }
}