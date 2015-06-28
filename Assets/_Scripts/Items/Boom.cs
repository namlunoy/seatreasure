using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boom : MonoBehaviour
{
    public Text txt;
    public int time;
    private bool isCounting = false;
    public GameObject particle;
    public float phamViNo;
    // Use this for initialization
    void Start()
    {
        txt.text = time.ToString();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        print("Va vào boom");
        if (other.collider.tag == "Ship" && isCounting == false)
        {
            print("Bắt đầu đếm!");
            isCounting = true;
            StartCoroutine(Counting());
        }
    }

    IEnumerator Counting()
    {
        do
        {
            time--;
            txt.text = time.ToString();
            yield return new WaitForSeconds(1);
        } while (time > 0);

        txt.text = "";

        iTween.ShakePosition(Camera.main.gameObject, new Vector3(1, 1, 1), 0.5f);

        Collider2D[] things = Physics2D.OverlapCircleAll(transform.position, phamViNo);

        foreach (Collider2D o in things)
        {
            if (o.tag == "Rock_Exp")
                o.gameObject.SetActive(false);
            else if (o.tag == "Ship")
                ShipController.Instance.Chet();
        }

        particle.transform.position = this.transform.position;
        particle.SetActive(true);
        Destroy(this.gameObject, 0.5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, phamViNo);
    }
}
