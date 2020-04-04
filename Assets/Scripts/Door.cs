using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool HideDoor = true;
    public float AnimeTime = 0.8f;
    public bool Unlocked;

    bool IsOpen;
    public Vector3 Axis;

    Transform DoorMesh;

    private void Start()
    {
        DoorMesh = transform.GetChild(0);
    }
    void OpenDoor()
    {
        StopAllCoroutines();
        StartCoroutine(RotateMe(Axis * (90 + (HideDoor ? 0 : 90)), AnimeTime));
    }
    void CloseDoor()
    {
        StopAllCoroutines();
        StartCoroutine(RotateMe(Axis * 0, AnimeTime));
    }
    void OnInteract(GameObject Caller)
    {
        Debug.Log(Caller.name + " Interact with " + name);

        if (Unlocked)
        {
            if (IsOpen)
            {
                IsOpen = false;
                CloseDoor();
            }
            else
            {
                IsOpen = true;
                OpenDoor();
            }

        }
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
        var fromAngle = DoorMesh.rotation;
        var toAngle = Quaternion.Euler(/*transform.eulerAngles + */DoorMesh.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            DoorMesh.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        DoorMesh.rotation = toAngle;
    }

}
