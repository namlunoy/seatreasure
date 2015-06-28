using UnityEngine;
using System.Collections;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.UI;

public class MenuLevel : MonoBehaviour
{
    public Sprite imageLock;
    public Transform Man_Mot;
    public GameObject button_left;
    public GameObject button_right;

    void Start()
    {
        StartCoroutine(Show(Man_Mot, true));

        StartCoroutine(iTweenHelper.ScaleForever(button_left, button_left.transform.localScale, new Vector3(0.1f, 0.1f, 0)));
        StartCoroutine(iTweenHelper.ScaleForever(button_right, button_right.transform.localScale, new Vector3(0.1f, 0.1f, 0)));
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("Start");
        }
    }

    private IEnumerator Show(Transform Man, bool isShow)
    {
        Vector3 s = isShow ? new Vector3(1, 1, 1) : new Vector3(0, 0, 0);

        for (int i = 0; i < Man.childCount; i++)
        {
            Transform button = Man.GetChild(i);
            iTween.ScaleTo(button.gameObject, iTween.Hash("time", 2, "scale", s, "easetype", iTween.EaseType.easeOutBounce));
            //Xác định hình ảnh
            if (UserData.Instance.active[i + 1] == false)
                button.GetChild(0).GetComponent<Image>().sprite = imageLock;
            //Xác định số sao
            for (int starcount = 1; starcount <= UserData.Instance.stars[i + 1]; starcount++)
                button.GetChild(1).GetChild(starcount - 1).GetChild(0).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(iTweenHelper.Rigging(button.gameObject, button.position, new Vector3(0, 3, 0), Random.Range(2f, 3f)));
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
       if(UserData.Instance.active[level])
       {
           GameManager.selectedLevel = level;
           print("Click level: " + level.ToString());
           Application.LoadLevel("Level_"+level);
       }
    }
}
