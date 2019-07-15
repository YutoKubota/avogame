using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUnit : Character
{
    /*public MyUnit(string name, int hp, int power, int x, int y) : base(name, hp, power, x, y)
    { 
    }*/

    // Use this for initialization
    void Start () {
        base.Name = "myunit";
        base.Hp = 20;
        base.Power = 5;
        base.X = 10;
        base.Y = 1;
    {
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
