using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour {

    //Friend player1 = new Friend("りんご", 100, 10, 0, 0); //名前、HP、攻撃力、X座標、Y座標
    //Enemy enemy1 = new Enemy("いがぐり", 150, 5, 10, 10); //名前、HP、攻撃力、X座標、Y座標
    Character player1 = new Character("りんご", 100, 10, 0, 0);
    //Character player2 = new Character("ぶどう", 100, 10, 0, 0);
    Character enemy = new Character("いがぐり", 150, 5, 10, 10);
    //Friend[] party = { player1, player2};

    // Use this for initialization
    void Start () {
       

        player1.Attack(enemy); //攻撃から相手の被ダメまで表示
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
