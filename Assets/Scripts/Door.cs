using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool HideDoor = true;
    public float AnimeTime = 0.8f;
    
    public void Open()
    {
        StopAllCoroutines();
        StartCoroutine(RotateMe(Vector3.up * (90 + (HideDoor ? 0 : 90)), AnimeTime));
    }
    public void Close()
    {
        StopAllCoroutines();
        StartCoroutine(RotateMe(Vector3.down * 0, AnimeTime));
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown("e"))
    //    {
    //        Open();
    //    }
    //    if (Input.GetKeyDown("q"))
    //    {
    //        Close();
    //    }
    //}

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(/*transform.eulerAngles + */byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        transform.rotation = toAngle;
    }

}
