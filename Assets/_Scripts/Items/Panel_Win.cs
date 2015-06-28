using UnityEngine;
using System.Collections;

/**Kịch bản hiển thị win pane
 * Cái victory hiện từ trên xuống
 * Các button hiện từ dưới lên
 * Các ngôi sao đập vào vị trí của nó
*/

public class Panel_Win : MonoBehaviour
{




    public GameObject[] stars;
    public Transform[] positions;

    void Start()
    {
        StartCoroutine(ShowStar());
    }

    public IEnumerator ShowStar()
    {
        yield return new WaitForSeconds(1.5f);
        for (int i = 0; i < ShipController.Instance.StarCount; i++)
        {
            iTween.MoveTo(stars[i], positions[i].position, 0.5f);
            yield return new WaitForSeconds(0.35f);
        }
    }
}
