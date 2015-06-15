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


    #endregion

    ShipController() { Instance = this; }

    void Start()
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Saw")
        {
            Application.LoadLevel(0);
        }
    }


}
