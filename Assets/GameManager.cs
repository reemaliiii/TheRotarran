using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;
    public int Keys;
    public int RoomCount;
    public Door[] doors;
    int currentDoorProgress;

    public void OpenBox()
    {
        switch (Keys)
        {
            case 1: // You Choose Wisely
                break;
            case 2: // Fool
                break;
            default: // 8aby
                break;
        }
    }

    private void Awake()
    {
        if (!instace)
        {
            instace = this;
        }
    }
    private void Start()
    {
        Keys = 0;
        currentDoorProgress = 0;
    }

    public void OpenDoor(int i)
    {
        doors[i].Unlocked = true;
    }

}
