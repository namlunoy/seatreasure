using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour {
    [SerializeField]
    private float speed;
	
	void Update () {
        transform.Rotate(new Vector3(0, 0, 1), speed);
	}
}
