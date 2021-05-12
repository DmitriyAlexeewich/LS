using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class TransfromModifier : MonoBehaviour
{

    Transform TransfromComponent;

    IEnumerator ScaleToSizeCoroutine;
    IEnumerator MoveToPointCoroutine;
    IEnumerator RotateToAngleCoroutine;

    public void Construct()
    {
        TransfromComponent = this.gameObject.GetComponent<Transform>();
    }

    public void StartScaleToSizeCoroutine(Vector3 Size, float Deltatime)
    {
    }

    public void StartMoveToPointCoroutine(Vector3 Point, float Deltatime)
    {
    }

    public void StartRotateToAngleCoroutine(Vector3 Angle, float Deltatime)
    {
    }

    IEnumerator ScaleToSize(Vector3 Size, float DeltaTime)
    {
        while (!TransfromComponent.Equals(Size))
        {
            float timer = 0;
            while (timer < DeltaTime)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            TransfromComponent.localScale = Vector3.Lerp(TransfromComponent.localScale)
        }
        yield return null;
    }

    IEnumerator MoveToPoint(Vector3 Point, float DeltaTime)
    {

        yield return null;
    }

    IEnumerator RotateToAngle(Vector3 Angle, float DeltaTime)
    {

        yield return null;
    }
}
