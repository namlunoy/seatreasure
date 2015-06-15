using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{

    public RectTransform[] items;
    public RectTransform btPlay;
    public RectTransform btSettings;

    public Transform playPos;
    public Transform[] items_pos;
    public Transform setting_pos;

    //Trạng thái của thanh settings
    private bool isOpenSettings = false;
    void Start()
    {
        iTween.MoveTo(btPlay.gameObject, iTween.Hash("time", 2, "position", playPos.position, "easetype", iTween.EaseType.easeOutBounce));
        StartCoroutine(Rigging());

        iTween.MoveTo(btSettings.gameObject, setting_pos.position, 3);
        for (int i = 0; i < items.Length; i++)
            iTween.MoveTo(items[i].gameObject, setting_pos.position, 3);

        StartCoroutine(iTweenHelper.Rigging(btSettings.gameObject, setting_pos.position, new Vector3(0, 3, 0), 1.5f, 2.7f));
    }

    IEnumerator Rigging()
    {
        yield return new WaitForSeconds(2.1f);
        StartCoroutine(iTweenHelper.Rigging(btPlay.gameObject, btPlay.gameObject.transform.position, new Vector3(0, 6, 0)));
    }

    public void ClickPlay()
    {
        Application.LoadLevel("menu_2");
    }

    public void ClickSettings()
    {
        Vector3 goc = new Vector3(0, 0, 0.8f);
        if (isOpenSettings)
        {
            //Đóng lại
            for (int i = 0; i < items.Length; i++)
            {
                float time = 0.5f;
                iTween.MoveTo(items[i].gameObject, setting_pos.position, time);
                iTweenHelper.ScaleTo(items[i].gameObject, new Vector3(0.5f, 0.5f, 1), time);
                iTween.RotateBy(btSettings.gameObject, goc, 0.5f);
            }
        }
        else
        {
            //Mở ra
            for (int i = 0; i < items.Length; i++)
            {
                float time = 1f + i * 0.7f;
                iTween.MoveTo(items[i].gameObject, items_pos[i].position, time);
                iTweenHelper.ScaleTo(items[i].gameObject, new Vector3(1, 1, 1), time);
                iTween.RotateBy(btSettings.gameObject, -1 * goc, 1f);
            }
        }
        isOpenSettings = !isOpenSettings;
    }

    public void ButtonDown(BaseEventData e)
    {
        if (e.selectedObject != null)
            iTweenHelper.ScaleTo(e.selectedObject, new Vector3(0.8f, 0.8f, 0), 0.5f);
    }
    public void ButtonUp(BaseEventData e)
    {
        if (e.selectedObject != null)
            iTweenHelper.ScaleTo(e.selectedObject, new Vector3(1, 1, 0), 0.5f);
    }
}
