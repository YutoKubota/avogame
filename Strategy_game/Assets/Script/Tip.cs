using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tip : MonoBehaviour
{
    private int cost;
    private bool search_bool = false;
    private Color default_color;
    private Color control_color;
    public Material material_color;
    private int movepower = -1;

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

    public void SetCost(int cost)
    {
        this.cost = cost;
    }
    public int GetCost()
    {
        return this.cost;
    }
    public void SetSearch_boll(bool judge)
    {
        this.search_bool = judge;
    }
    public bool GetSearch_bool()
    {
        return this.search_bool;
    }
    public void SetMovepower(int m)
    {
        this.movepower = m;
    }
    public int GetMovepower()
    {
        return this.movepower;
    }
}
