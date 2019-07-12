using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    public float posi_x;
    public float posi_y;
    public int movepower;

	// Use this for initialization
	void Start () {
        posi_x = this.transform.localPosition.x;
        posi_y = this.transform.localPosition.z;
        movepower = 4;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
