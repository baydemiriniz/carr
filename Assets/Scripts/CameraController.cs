using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerController;
    public Vector3 distance;
   public void Start()
   {
       distance = playerController.transform.position - transform.position;
   }
    
    public void LateUpdate()
    {
        transform.position = new Vector3(distance.x+playerController.transform.position.x,distance.y,distance.z);
    }
}
