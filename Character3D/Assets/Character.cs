using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    private string name;
    private int hp;
    private int M_hp;   // 最大体力
    private int power;  // 攻撃力
    private int x;      //X座標
    private int y;      //Y座標

    public Character(string name, int hp, int power, int x, int y)
    {
        this.name = name;
        this.hp = hp;
        this.M_hp = hp;
        this.power = power;
        this.x = x;
        this.y = y;
    }

    /*
    public string Name
    {
        get
        {
            return this.name;
        }
    }
    public int Hp
    {
        get
        {
            return this.hp;
        }
        
    }
    public int Power
    {
        get
        {
            return this.power;
        }
    }
    public int X
    {
        get
        {
            return this.x;
        }
    }
    public int Y
    {
        get
        {
            return this.y;
        }
    }
    */

    public void Attack(Character c)
    {
        Debug.Log(this.name+ "が" + c.name + "に" + this.power + "のダメージを与えた");
        c.Damage(this.power);
    }
    public void Damage(int damage)
    {
        this.hp -= damage;
        Debug.Log(damage + "のダメージを受けた");
        /*
        if (this.hp <= 0)
        {
            hp = 0;
            Debug.Log(this.name + "の残りHP: " + this.hp);
            Debug.Log(this.name + "は倒れた！");
        }
        if (this.hp > 0)
        {
            Debug.Log(this.name + "の残りHP: " + this.hp);
        }
        */
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
