using UnityEngine;
using System.Collections;

public class Snake : MonoBehaviour
{
    private bool _isAlive = true;
    public bool IsAlive { get { return _isAlive; } }
    private Animator animator;
    private bool isMoving = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ship" && isMoving == false)
        {
            
            //Di chuyeenr
            isMoving = true;
            iTween.MoveTo(this.gameObject, iTween.Hash("time", 8f, "path", iTweenPath.GetPath("Snake"), "easetype", iTween.EaseType.linear));
            animator.SetTrigger("WakeUp");
        }

        if (other.gameObject.name == "Active")
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        print("Snake va vao cai gi do!");
        if (other.gameObject.tag == "TangDa")
        {
            //Pha tang da
            other.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

            //Tu chet
            _isAlive = false;
            animator.SetTrigger("Die");
            //Tach cac bo phan ra!
            for (int index = 5; index <= 8; index++)
                this.transform.GetChild(index).GetComponent<HingeJoint2D>().enabled = false;
        }
    }

    void TinhDay()
    {

    }

    void Chet()
    {

    }
}
