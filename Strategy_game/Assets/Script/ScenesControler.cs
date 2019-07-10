using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesControler : MonoBehaviour {
    [SerializeField]
    Map tip;

	// Use this for initialization
	void Start () {
        tip.CreateMap();
        tip.StartSearch(5, 3, 4);
	}
	
}
