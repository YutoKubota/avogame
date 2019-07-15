using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    private string name;
    private int hp;
    private int M_hp;   // 最大体力
    private int power;  // 攻撃力
    private int x;      //X座標
    private int y;      //Y座標
    private bool acted = false;
    private int moveRange = 4;
    private bool moved = false;

    /* Character(string name, int hp, int power, int x, int y)
    {
        this.name = name;
        this.hp = hp;
        this.M_hp = hp;
        this.power = power;
        this.X = x;
        this.Y = y;
        this.Acted = false;
        this.moveRange = 4;
    }*/


    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }
    public int Hp
    {
        get
        {
            return this.hp;
        }
        set
        {
            this.hp = value;
        }

    }
    public int Power
    {
        get
        {
            return this.power;
        }
        set
        {
            this.power = value;
        }
    }
    public int X
    {
        get
        {
            return this.x;
        }
        set
        {
            x = value;
        }
    }
    public int Y
    {
        get
        {
            return this.y;
        }
        set
        {
            this.y = value;
        }
    }

    public int MoveRange
    {
        get
        {
            return this.moveRange;
        }
        set
        {
            this.moveRange = value;
        }
    }
    public bool Acted
    {
        get
        {
            return this.acted;
        }
        set
        {
            this.acted = value;
        }
    }

    public bool Moved
    {
        get
        {
            return this.moved;
        }
        set
        {
            this.moved = value;
        }
    }

    public void Attack(Character c)
    {
        Debug.Log(this.name + "が" + c.name + "に" + this.power + "のダメージを与えた");
        c.Damage(this.power);
        this.Acted = true;
    }
    public void Damage(int damage)
    {
        hp -= damage;
        Debug.Log(damage + "のダメージを受けた");
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
    }

    public void move(int x, int y)
    {
        this.X = x;
        this.Y = y;
        this.gameObject.transform.position = new Vector3((float)(5 * X + 2.5), 0, (float)(5 * Y + 2.5));
    }
}
