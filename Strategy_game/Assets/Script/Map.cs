﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    private float terrainWidth;
    private float terrainLength;
    private float terrainHeight;
    private float terrainY;
    private float tipWidth;
    private float tipLength;
    private float tipHeight;
    private float tipX;
    private float tipY;
    private int arraysizex;
    private int arraysizey;
    private Tip[,] tipArray;
    GameObject map_tip;
    GameObject ter;
    GameObject stageObject;
    GameObject copy_tip;

    // Use this for initialization
    void Start () {
        map_tip = GameObject.Find("Tip");
        ter = GameObject.Find("Terrain");
        stageObject = GameObject.FindWithTag("Stage");
        Terrain terrain = Terrain.activeTerrain;
        terrainWidth = terrain.terrainData.size.x;  // 地面のサイズ
        terrainLength = terrain.terrainData.size.z; // 地面のサイズ
        terrainY = ter.transform.localPosition.y;     // 地面の初期位置(Y)
        tipWidth = map_tip.transform.localScale.x;  // マスの大きさ(X)
        tipLength = map_tip.transform.localScale.z; // マスの大きさ(Z)
        tipX = map_tip.transform.localPosition.x;   // マスの初期位置(X)
        tipY = map_tip.transform.localPosition.z;   // マスの初期位置(Z)
        arraysizex = (int)(terrainWidth / tipWidth);
        arraysizey = (int)(terrainLength / tipLength);

        // 複製したマスの配列
        tipArray = new Tip[arraysizex, arraysizey];
    }

    // Update is called once per frame
    void Update () {
    }

    // マップチップ作成
    public void CreateMap()
    {
        for (int y = 0; y < arraysizey; y++)
        {
            for (int x = 0; x < arraysizex; x++)
            {
                // 地面の高さ
                terrainHeight = Terrain.activeTerrain.terrainData.GetInterpolatedHeight
                    ((x * tipWidth + tipX) / terrainWidth, (y * tipLength + tipY) / terrainLength);
                tipHeight = terrainHeight + 0.1f + terrainY;
                // 複製する場所の指定
                Vector3 CreatePoint = new Vector3
                    (tipWidth * x + tipX, tipHeight, tipLength * y + tipY);
                // 複製
                copy_tip = Instantiate(map_tip, CreatePoint, Quaternion.identity) as GameObject;
                // ダウンキャスト
                //Tip tipBase = copy_tip[x, y].GetComponent<Tip>();
                // 複製したマス(スクリプト)を配列に格納する
                tipArray[x, y] = copy_tip.GetComponent<Tip>();
                // マップチップごとの移動コストを入力
                tipArray[x, y].SetCost(1);
                // Stageオブジェクトの下に作成する
                tipArray[x, y].transform.parent = stageObject.transform;
            }
        }
        Destroy(map_tip);
    }
    // 移動
    public void move(float pl_x,　float pl_y, Character ch)
    {
        int x= (int)(pl_x / tipWidth);
        int y = (int)(pl_y / tipLength);
        ch.posi_x = x * tipWidth;
        ch.posi_y = y * tipLength;
    }
    // 移動範囲探索
    public void StartSearch(float posi_x, float posi_y, int movepower)
    {
        int x = (int)(posi_x / tipWidth);
        int y = (int)(posi_y / tipLength);
        Reset_Range();
        Search4(x, y, movepower);
    }
    public void Search4(int x,int y,int m)
    {
        int search_cost;
        this.tipArray[x, y].SetMovepower(m);
        this.tipArray[x, y].SetSearch_boll(true);

        if (0 < x - 1 && x + 1 < arraysizex && 0 < y - 1 && y + 1 < arraysizey)
        {

            // 上方向
            search_cost = m - this.tipArray[x, y - 1].GetCost();
            if(this.tipArray[x, y -1].GetMovepower() < search_cost)
            {
                Search4(x, y - 1, search_cost);
            }
            // 下方向
            search_cost = m - this.tipArray[x, y + 1].GetCost();
            if (this.tipArray[x, y + 1].GetMovepower() < search_cost)
            {
                Search4(x, y + 1, search_cost);
            }
            // 左方向
            search_cost = m - this.tipArray[x - 1, y].GetCost();
            if (this.tipArray[x - 1, y].GetMovepower() < search_cost)
            {
                Search4(x - 1, y, search_cost);
            }
            // 右方向
            search_cost = m - this.tipArray[x + 1, y].GetCost();
            if (this.tipArray[x + 1, y].GetMovepower() < search_cost)
            {
                Search4(x + 1, y, search_cost);
            }
        }
    }
    public void Reset_Range()
    {
        for(int y = 0; y < arraysizey; y++)
        {
            for(int x = 0; x < arraysizex; x++)
            {
                this.tipArray[x, y].SetSearch_boll(false);
            }
        }
    }
    // 最短経路
}
