using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesControler : MonoBehaviour {
    [SerializeField]
    Map tip;
    [SerializeField]
    Character ch;

	// Use this for initialization
	void Start () {
        tip.CreateMap();
        tip.StartSearch(ch.posi_x, ch.posi_y, ch.movepower);
	}
	
}
