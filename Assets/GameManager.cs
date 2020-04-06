using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instace;
    public int Keys;
    public int RoomCount;
    public Door[] doors;
    int currentDoorProgress;
    public Text KeysScore;

    public GameObject bombTable;
    public GameObject BossRoom;
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

        Invoke("Boss", 2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.HandleGameManagerEscape();
        }
    }

    public void OpenDoor(int i)
    {
        //doors[i].Unlocked = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    /*
     public void QuitGame()
     {
         Application.Quit();
     }*/

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void UnlockBoss()
    {
        BossRoom.SetActive(true);
    }

    public void UpdateKeysScore(int keys)
    {
        KeysScore.text = keys.ToString() + "*";
    }

    public void ShowBombTable()
    {
        //bombTable.SetActive(true);
    }

    private void Boss()
    {
        BossRoom.SetActive(false);
    }
}
