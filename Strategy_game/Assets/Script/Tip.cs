using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour
{
    private int cost;
    private bool search_bool = false;
    private bool attack_bool = false;
    private Color default_color;
    private Color control_color;
    public Material material_color;
    private int movepower = -1;
    private int attack_range = -1;

    // Use this for initialization
    void Start()
    {
        material_color = GetComponent<Renderer>().material;
        default_color = material_color.color;
        control_color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.search_bool)
        {
            this.material_color.color = Color.gray;
        }
    }

    // 移動コスト
    public int Cost
    {
        set
        {
            this.cost = value;
        }
        get
        {
            return this.cost;
        }
    }
    // 移動範囲
    public bool Search_bool
    {
        set
        {
            this.search_bool = value;
        }
        get
        {
            return this.search_bool;
        }
    }
    //  攻撃範囲
    public bool Attack_bool
    {
        set
        {
            this.attack_bool = value;
        }
        get
        {
            return this.attack_bool;
        }
    }
    // 行動力
    public int Movepower
    {
        set
        {
            this.movepower = value;
        }
        get
        {
            return this.movepower;
        }
    }
    // 攻撃範囲
    public int Attack_range
    {
        set
        {
            this.attack_range = value;
        }
        get
        {
            return this.attack_range;
        }
    }
}
