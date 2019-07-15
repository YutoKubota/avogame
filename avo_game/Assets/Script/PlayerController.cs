using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    CharacterController chara;
    Map map;
    int x, y, mapWidth;
    bool isMyTurn;

    private void Start()
    {
        chara = GameObject.Find("CharacterController").GetComponent<CharacterController>();
        map = GameObject.Find("Terrain").GetComponent<Map>();
        this.x = 0;
        this.y = 0;
        this.mapWidth = 20;
        this.IsMyTurn = true;

    }
	
	// Update is called once per frame
	void Update () {
        map.updateCurrent(this.x, this.y);
		if (this.isMyTurn)
        {
            this.changeXY();
            this.action();
        }
	}

    public bool IsMyTurn
    {
        set
        {
            this.isMyTurn = value;
        }
        get
        {
            return this.isMyTurn;
        }
    }

    public void action()
    {
        if (!chara.IsSelectedAC)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bool success = chara.changeActiveCharacter(this.x, this.y);
                if (success)
                {
                    map.StartSearch(this.chara.getAciveCharacter());
                }
                else
                {
                    this.isMyTurn = false;
                    chara.turnEndAction();
                    map.Reset_Range();
                }

            }
        }
        else if (!chara.IsSelectedPC && !chara.getAciveCharacter().Moved)
        {
            chara.getAciveCharacter().move(this.x, this.y);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                chara.getAciveCharacter().Moved = true;
                map.StartAttackRange(chara.getAciveCharacter(), 1);

            }
        }
        else if (!chara.IsSelectedPC)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (this.x == chara.getAciveCharacter().X && this.y == chara.getAciveCharacter().Y)
                {
                    chara.getAciveCharacter().Acted = true;
                    chara.IsSelectedAC = false;
                    map.Reset_Range();
                    return;
                }
                bool success = chara.changePassiveCharacter(this.x, this.y);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                map.StartAttackRange(chara.getAciveCharacter(), 1);
                if (map.GetArray(x, y).Attack_bool)
                {
                    chara.getAciveCharacter().Attack(chara.getPassiveCharacter());
                    chara.IsSelectedAC = false;
                    chara.IsSelectedPC = false;
                    map.Reset_Range();
                }
            }
        }


    } 
    
    public void changeXY()
    {
        if (!chara.IsSelectedPC)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                if(this.x > 0)
                {
                    this.x--;
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (this.x < mapWidth - 1)
                {
                    this.x++;
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (this.y > 0)
                {
                    this.y--;
                }
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if (this.y < mapWidth - 1)
                {
                    this.y++;
                }
            }
        }
    }
}
