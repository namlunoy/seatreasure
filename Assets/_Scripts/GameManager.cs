using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

    //Các thành phần giao diện
    public GameObject panel_pause;

    // Use this for initialization
    void Start()
    {
        iTween.FadeTo(panel_pause, 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Các sự kiện ngoài UI
    public void ClickSetting()
    {

    }
    #endregion
}
