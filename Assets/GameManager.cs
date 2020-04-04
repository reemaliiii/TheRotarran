using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;
    public int Keys;
    public int RoomCount;
    public Door[] doors;
    int currentDoorProgress;

    public PauseMenu pauseMenu;
    public bool pauseMenuActive = false;

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
        // get him back to the main menu after losing (after playing animation ) 
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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu.HandleGameManagerEscape();
        }
    }

    public void OpenDoor(int i)
    {
        doors[i].Unlocked = true;
    }

   /* public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }*/

}
