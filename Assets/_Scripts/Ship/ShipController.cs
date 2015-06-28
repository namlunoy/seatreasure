using UnityEngine;
using System.Collections;

public class ShipController : MonoBehaviour
{

    #region Thuộc tính
    //Các lớp ngoài sẽ tham chiếu đến cái này
    public static ShipController Instance;

    //Xác định nó đang sống hay chết
    public bool IsAlive { get { return _isAlive; } }
    private bool _isAlive = true;
    private int starCount = 0;
    public int StarCount { get { return starCount; } }
    private Animator animator;
    private bool co_Symbol_Cut = false;

    #endregion

    ShipController() { Instance = this; }

    void Start()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Saw")
        {
            //Va phải cái cưa chết đứng
            _isAlive = false;
            GameManager.Instance.Game_Over_Async();

        }else if(other.tag == "Star"){
            //Thực hiện ăn sao
            starCount++;
            GameManager.Instance.AnSao(starCount);
        }
        else if (other.tag == "Treasure")
        {
            _isAlive = false;
            //Game Win
            StartCoroutine(GameManager.Instance.Game_Win());
        }
        else if (other.tag == "Symbol_Cut")
        {
            iTween.ScaleTo(other.gameObject, new Vector3(0, 0, 0), 1f);
            Destroy(other.gameObject, 1f);
            co_Symbol_Cut = true;
        }
        else if (other.gameObject.name == "Snake")
        {
            print("You wake up the snake!");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Xich" && co_Symbol_Cut)
        {
            other.gameObject.GetComponent<HingeJoint2D>().enabled = false;
            co_Symbol_Cut = false;
        }
    }

    public void Chet()
    {
        print("Chết");
        _isAlive = false;
        animator.SetTrigger("Chet");
        StartCoroutine(GameManager.Instance.Game_Over_Async());
        Destroy(this.gameObject,2);
    }
}
