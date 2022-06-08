using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class engel2 : MonoBehaviour
{
    public Vector3 initialpos;
    void Start()
    {
        initialpos = transform.position;
        ObjectRotate();
    }
    
    public void ObjectRotate()
    {
        transform.DOMoveY(initialpos.y+30f, Random.Range(0.2f,0.5f)).SetEase(Ease.Linear).OnComplete(
            () => {  
                transform.DOMoveY(initialpos.y, Random.Range(0.2f,0.5f)).SetEase(Ease.Linear).OnComplete(() =>
                {
                    ObjectRotate();
                }); 
            }
        );
    }
}
