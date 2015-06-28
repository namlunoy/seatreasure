using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour
{
    private Animator animator;
    private Vector3 originalPos;
    private AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        originalPos = transform.position;
        StartCoroutine(Rigging());
    }

    IEnumerator Rigging()
    {
        while (true)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash("time", 1, "easetype", iTween.EaseType.linear, "position", originalPos + new Vector3(0, 0.1f)));
            yield return new WaitForSeconds(1);
            iTween.MoveTo(this.gameObject, iTween.Hash("time", 1, "easetype", iTween.EaseType.linear, "position", originalPos - new Vector3(0, 0.1f)));
            yield return new WaitForSeconds(1);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ship")
        {
            audio.Play();
            animator.SetTrigger("GetStar");
        }
    }


    public void End()
    {
        Destroy(this.gameObject);
    }
}
