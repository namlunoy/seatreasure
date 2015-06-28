using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public Transform theObject;

    private Vector3 offset;

    void Start()
    {
        offset = this.transform.position - theObject.position;

    }

    void Update()
    {
        if (theObject != null)
            this.transform.position = Vector3.Lerp(this.transform.position, offset + theObject.position, 0.9f);
        //  this.transform.position = offset + theObject.position;
    }
}
