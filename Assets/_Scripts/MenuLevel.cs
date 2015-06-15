using UnityEngine;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

public class MenuLevel : MonoBehaviour
{
    public Transform Man_Mot;
    public GameObject button_left;
    public GameObject button_right;
    
    
    //Quản lý 2 màn chơi
    public GameObject panel_1;
    public GameObject panel_2;
    public Transform P_Center;
    public Transform P_Left;
    public Transform P_Right;


    void Start()
    {
        StartCoroutine(Show(Man_Mot, true));

        StartCoroutine(iTweenHelper.ScaleForever(button_left, button_left.transform.localScale, new Vector3(0.1f, 0.1f, 0)));
        StartCoroutine(iTweenHelper.ScaleForever(button_right, button_right.transform.localScale, new Vector3(0.1f, 0.1f, 0)));
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("menu_1");
        }
    }

    private IEnumerator Show(Transform Man, bool isShow)
    {
        Vector3 s = isShow ? new Vector3(1, 1, 1) : new Vector3(0, 0, 0);

        for (int i = 0; i < Man.childCount; i++)
        {
            iTween.ScaleTo(Man.GetChild(i).gameObject, iTween.Hash("time", 2, "scale", s, "easetype", iTween.EaseType.easeOutBounce));
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(iTweenHelper.Rigging(Man.GetChild(i).gameObject, Man.GetChild(i).position,new Vector3(0,3,0),Random.Range(2f,3f)));
        }
    }

    public void Click(int button)
    {
        if (button == 1)
        {
            //Click nút trái
            //Chuyển Panel 1 sang trái, panel 2 sang giữa
        }
        else
        {
            //Click nút phải
            //Chuyển panel2 sang phải, panel 1 ra giữa
        }
    }

    public void LoadLevel(int level)
    {
        Application.LoadLevel("Level_1");
    }
}
