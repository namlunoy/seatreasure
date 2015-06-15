using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform theObject;

    private Vector3 offset;

	void Start () {
        offset = this.transform.position - theObject.position;

	}
	
	void Update () {
        this.transform.position = Vector3.Lerp(this.transform.position, offset + theObject.position, Time.deltaTime);
	}
}
