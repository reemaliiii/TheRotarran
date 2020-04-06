using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;

    public float LeftClamp = 0;
    public float RightClamp = 0;
    public float TopClamp = 0;
    public float DownClamp = 0;



    // How long the object should shake for.
    public float shakeDuration = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;



    void Update()
    {
        originalPos = new Vector3(Mathf.Clamp(player.transform.position.x, LeftClamp, RightClamp) + offset.x, Mathf.Clamp(player.transform.position.y, DownClamp, TopClamp) + offset.y, offset.z);

        if (shakeDuration > 0)
        {
            this.transform.position = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            this.transform.position = originalPos;
        }
    }

}