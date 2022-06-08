using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class engel1 : MonoBehaviour
{
    void Start()
    {
        ObjectRotate();
    }

    public void ObjectRotate()
    {
        transform.DORotate(new Vector3(transform.transform.eulerAngles.x, 500, transform.transform.eulerAngles.z), 1.2f, RotateMode.FastBeyond360).SetEase(Ease.Linear, .5f).OnComplete(
            () => { ObjectRotate(); }
        );
    }
}