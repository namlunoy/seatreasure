using UnityEngine;
using System.Collections;

public enum OpenType { LEFT, RIGHT, UP, DOWN }

public class Symbol_Open : MonoBehaviour
{
    public GameObject theDoor;
    public OpenType openType;
    public float size = 5;

    private Vector3 originalPos;
    private Vector3 openPos;

    void Start()
    {
        originalPos = theDoor.transform.position;


        StartCoroutine(iTweenHelper.Rigging(this.gameObject, this.transform.position, Vector3.up * 0.2f, 2));
        switch (openType)
        {
            case OpenType.LEFT:
                this.transform.rotation = new Quaternion(0, 0, 0, 0);
                openPos = originalPos + Vector3.left * size;
                break;
            case OpenType.RIGHT:
                this.transform.rotation = new Quaternion(0, 0, 180, 0);
                openPos = originalPos + Vector3.right * size;
                break;
            case OpenType.UP:
                this.transform.rotation = new Quaternion(0, 0, 270, 0);
                openPos = originalPos + Vector3.up * size;
                break;
            case OpenType.DOWN:
                this.transform.rotation = new Quaternion(0, 0, 90, 0);
                openPos = originalPos + Vector3.down * size;
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        iTween.MoveTo(theDoor, openPos, 1f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        var others = Physics2D.OverlapCircleAll(transform.position, GetComponent<CircleCollider2D>().radius);
        if (others.Length == 1)
            iTween.MoveTo(theDoor, originalPos, 1f);
     
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, GetComponent<CircleCollider2D>().radius);
    }
}
