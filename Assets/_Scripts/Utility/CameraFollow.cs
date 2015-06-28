using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform theObject;
    private ShipController ship;

    private Vector3 offset;

    void Start()
    {
        offset = this.transform.position - theObject.position;
        ship = theObject.gameObject.GetComponent<ShipController>();
    }

    void Update()
    {
        if (ship != null && ship.IsAlive)
            this.transform.position = Vector3.Lerp(this.transform.position, offset + theObject.position, 0.9f);
    }
}
