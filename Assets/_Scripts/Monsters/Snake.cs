using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ship")
        {
            //Di chuyeenr
            iTween.MoveTo(this.gameObject, iTween.Hash("time",5f,));
        }
    }
}
