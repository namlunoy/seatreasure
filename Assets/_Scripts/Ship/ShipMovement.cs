using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    private ShipController ship;
    [SerializeField]
    private float speed;
    private bool isMoving = false;
    private Vector3 currentDir;
    private Vector2 force;
    private Rigidbody2D rig;
    public CNAbstractController joystick;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ship = GetComponent<ShipController>();
        force = new Vector2();
        joystick.FingerLiftedEvent += joystick_FingerLiftedEvent;
        joystick.FingerTouchedEvent += joystick_FingerTouchedEvent;
        joystick.ControllerMovedEvent += joystick_ControllerMovedEvent;

    }

    void joystick_ControllerMovedEvent(Vector3 dir, CNAbstractController arg2)
    {
        currentDir = dir.normalized;
    }

    void joystick_FingerTouchedEvent(CNAbstractController obj)
    {
        isMoving = true;
    }

    void joystick_FingerLiftedEvent(CNAbstractController obj)
    {
        isMoving = false;
       // rig.velocity = Vector2.zero;
    }

    void Update()
    {
        if (ship.IsAlive)
        {
            MoveByKeyboard();
        }

        if (isMoving)
        {
            force.x = currentDir.x;
            force.y = currentDir.y;

            //transform.Translate(currentDir * speed * Time.deltaTime);
            rig.AddForce(force * speed);

            if (currentDir.x >= 0)
                transform.localScale = new Vector3(1, 1, 1);
            else transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void FixedUpdate()
    {
       
    }


    private void MoveByKeyboard()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            this.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.localScale = new Vector3(1, 1, 1);
            this.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
            this.transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.DownArrow))
            this.transform.Translate(Vector3.down * Time.deltaTime * speed);
 
    }

}
