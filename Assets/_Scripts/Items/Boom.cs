using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Boom : MonoBehaviour
{
    private AudioSource audio;
    public Text txt;
    private int time;
    private bool isCounting = false;
    public GameObject particle;
    public float phamViNo;
    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();

        if (!int.TryParse(txt.text, out time))
            time = 3;

        if (Application.loadedLevelName == "Level_5")
        {
            time = Random.Range(0, 2);
            txt.text = time.ToString();
        }
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
        while (time > 0)
        {
            time--;
            txt.text = time.ToString();
            yield return new WaitForSeconds(1);
        };

        txt.text = "";
        audio.Play();
        iTween.ShakePosition(Camera.main.gameObject, new Vector3(1, 1, 1), 0.5f);
        
        Collider2D[] things = Physics2D.OverlapCircleAll(transform.position, phamViNo);

        foreach (Collider2D o in things)
        {
            if (o.tag == "Rock_Exp")
                o.gameObject.SetActive(false);
            else if (o.tag == "Ship")
                StartCoroutine(ShipController.Instance.Chet_Async());
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
