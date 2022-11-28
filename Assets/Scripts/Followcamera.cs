using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core.Easing;

public class Followcamera : MonoBehaviour
{


    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        MoveForward();
    }

    void MoveForward()
    {
        transform.DOMoveZ(transform.position.z + 5, 1f).SetEase(Ease.Linear).OnComplete(MoveForward);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
