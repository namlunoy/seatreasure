using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour
{
    private Transform theOpen;
    private bool isOpened = false;
    private bool isTheLeftOne = false;
    public bool isFake = false;

    void Start()
    {
        theOpen = transform.GetChild(0);
        isTheLeftOne = this.gameObject.name.Contains("left");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ship" && isOpened == false)
        {
            StartCoroutine(Collected());
        }
    }

    private IEnumerator Collected()
    {
        GameObject daulau = this.transform.GetChild(2).gameObject;
        if (isFake)
        {
            this.transform.GetChild(1).gameObject.SetActive(false);
            daulau.SetActive(true);
        }

        isOpened = true; GetComponent<AudioSource>().Play();
        iTween.ShakePosition(this.gameObject, iTween.Hash("time", 1, "amount", new Vector3(0.1f, 0.1f, 0)));
        yield return new WaitForSeconds(1);
        Vector3 rotate = isTheLeftOne == false ? new Vector3(0, 0, -20 * Mathf.PI / 180f) : new Vector3(0, 0, 20 * Mathf.PI / 180f);
       
        iTween.RotateBy(theOpen.gameObject, iTween.Hash("time", 1, "easetype", iTween.EaseType.easeOutCirc, "amount", rotate));

        if (isFake)
        {
            iTween.MoveBy(daulau, Vector3.up, 2);
            iTween.ScaleTo(daulau, new Vector3(0.5f, 0.5f, 0.5f), 2);
        }
    }
}
