﻿using UnityEngine;
using System.Collections;

/*
 * Quản lý các công việc chung
 * 
 * 1. Ăn sao
 * 2. Pause game
 * 3. Lose game
 * 4. Win game
 * 
 * */


public class GameManager : MonoBehaviour
{
    //Biến này để truy cập vào nó tại mọi nơi
    public static GameManager Instance;
    public static int selectedLevel = 1;
    //Các thành phần giao diện
    public GameObject panel_pause;
    public GameObject panel_win;
    public GameObject panel_lose;
    public GameObject[] toTurnOff;
    public GameObject[] starsInMenu;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        print("Selected level: " + selectedLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.LoadLevel("Menu");
    }

    #region Sự kiện trong game

    public IEnumerator Game_Win()
    {
        //Lưu data
        UserData.Instance.stars[selectedLevel] = ShipController.Instance.StarCount;
        UserData.Instance.active[selectedLevel + 1] = true;
        UserData.Instance.Save();

        yield return new WaitForSeconds(2f);
        foreach (GameObject o in toTurnOff)
            o.SetActive(false);
        panel_win.SetActive(true);
    }

    public IEnumerator Game_Over_Async()
    {
        //Lưu data
        UserData.Instance.stars[selectedLevel] = ShipController.Instance.StarCount;
        UserData.Instance.Save();

        foreach (GameObject o in toTurnOff)
            o.SetActive(false);

        yield return new WaitForSeconds(1.5f);
        print("show panel");
        panel_lose.SetActive(true);
    }

    public void AnSao(int stt)
    {
        iTween.ScaleTo(starsInMenu[stt - 1], iTween.Hash("scale", new Vector3(1f, 1f, 1), "time", 0.5f, "easetype", iTween.EaseType.easeOutBack));
        // iTween.ScaleTo(starsInMenu[stt - 1], iTween.Hash("scale", new Vector3(1f, 1f, 1), "time", 0.1f, "delay",0.5f));
    }

    #endregion


    #region Các sự kiện ngoài UI

    public void ClickSetting()
    {
        foreach (GameObject o in toTurnOff)
            o.SetActive(false);
        panel_pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ClickResume()
    {
        foreach (GameObject o in toTurnOff)
            o.SetActive(true);
        panel_pause.SetActive(false);
        Time.timeScale = 1;
    }

    public void Click_Replay()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Click_Menu()
    {
        Time.timeScale = 1;
        Application.LoadLevel("Menu");
    }

    public void Click_Next()
    {
        print("next level");
        selectedLevel++;
        Application.LoadLevel("Level_" + selectedLevel);
    }

    #endregion
}
