using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour
{

    // Use this for initialization
    private GameObject mouth;
    [SerializeField]
    private bool isMoving = true;
    void Start()
    {
        mouth = this.transform.GetChild(0).gameObject;
        Vector3[] arr = iTweenPath.GetPath("Path_1");
        iTween.MoveTo(this.gameObject, iTween.Hash("path", arr, "time", 10f, "easetype", iTween.EaseType.linear));
        StartCoroutine(DopDop());
    }

    IEnumerator DopDop()
    {
        while(true)
        {
            if (isMoving)
            {
                iTween.RotateTo(mouth, new Vector3(0, 0, 0), 1f);
                yield return new WaitForSeconds(1);
                iTween.RotateTo(mouth, new Vector3(0, 0, 20), 1f);
            }
            yield return new WaitForSeconds(1);
        }
    }
}
