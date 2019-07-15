using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    /*Enemy(string name, int hp, int power, int x, int y) : base(name, hp, power, x, y)
    {
    }*/
    // Use this for initialization
    void Start () {
        base.Name = "enemy";
        base.Hp = 20;
        base.Power = 5;
        base.X = 10;
        base.Y = 18;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
