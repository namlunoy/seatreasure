using UnityEngine;
using System.Collections;

public class StarTurn : MonoBehaviour {
    
    private Transform child;

	// Use this for initialization
	void Start () {
        child = this.transform.GetChild(0);
        child.gameObject.SetActive(false);
	}

    public void Turn(bool on_off)
    {
        child.gameObject.SetActive(on_off);
    }
}
