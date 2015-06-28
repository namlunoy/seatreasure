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
    private bool co_Key = false;

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
            StartCoroutine(Chet_Async());
        }
        else if (other.tag == "Star")
        {
            //Thực hiện ăn sao
            starCount++;
            GameManager.Instance.AnSao(starCount);
        }
        else if (other.tag == "Treasure")
        {
            if (other.gameObject.GetComponent<Treasure>().isFake)
                StartCoroutine(Chet_Async(2));
            else Thang();
        }
        else if (other.tag == "Symbol_Cut")
        {
            iTween.ScaleTo(other.gameObject, new Vector3(0, 0, 0), 1f);
            Destroy(other.gameObject, 1f);
            co_Symbol_Cut = true;
        }
        else if (other.gameObject.name == "SnakeZone")
        {
            other.gameObject.SetActive(false);
            print("You wake up the snake!");
        }
        else if (other.gameObject.name == "SnakeTrigger")
        {
            other.gameObject.SetActive(false);
            if (other.transform.parent.GetComponent<Snake>().IsAlive)
                StartCoroutine(Chet_Async(2));
        }
        else if (other.gameObject.name == "Key")
        {
            co_Key = true;
            iTween.ScaleTo(other.gameObject, Vector3.zero, 1);
            Destroy(other.gameObject, 1f);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Xich" && co_Symbol_Cut)
        {
            other.gameObject.GetComponent<HingeJoint2D>().enabled = false;
            co_Symbol_Cut = false;
        }
        else if (other.gameObject.name == "Door" && co_Key)
        {
            iTween.MoveTo(other.gameObject, other.gameObject.transform.position + Vector3.up * 2, 1f);
        }
    }

    public IEnumerator Chet_Async(float time = 0)
    {
        print("Chết");
        yield return new WaitForSeconds(time);
        animator.SetTrigger("Chet");
        _isAlive = false;
        StartCoroutine(GameManager.Instance.Game_Over_Async());
        Destroy(this.gameObject, 3);
    }

    public IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
    }
    public void Thang()
    {
        print("Thắng");
        _isAlive = false;
        StartCoroutine(GameManager.Instance.Game_Win());
    }
}
