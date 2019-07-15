using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    private MyUnit[] myUnits;
    private Enemy[] enemies;
    private Character activeCharacter;
    private Character passiveCharacter;
    private bool isMyUnit;
    private bool isSelectedAC;
    private bool isSelectedPC;

    private void Start()
    {
        int[] mx = new int[1];
        mx[0] = 10;
        int[] my = new int[1];
        my[0] = 1;
        int[] ex = new int[1];
        ex[0] = 10;
        int[] ey = new int[1];
        ey[0] = 18;
        int myUnitNum = 1;
        int enemyNum = 1;
        myUnits = new MyUnit[myUnitNum];
        enemies = new Enemy[enemyNum];
        this.isMyUnit = false;
        this.isSelectedAC = false;
        this.isSelectedPC = false;
        for (int i = 0; i < myUnits.Length; i++)
        {
            //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            GameObject cube = GameObject.Find("Cube");
            cube.transform.position = new Vector3((float)(5 * mx[i] + 2.5), 0, (float)(5 * my[i] + 2.5));
            myUnits[i] = cube.GetComponent<MyUnit>();
        }
        for (int i = 0; i < enemies.Length; i++)
        {
            //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            GameObject sphere = GameObject.Find("Sphere");
            sphere.transform.position = new Vector3((float)(5 * ex[i] + 2.5), 0, (float)(5 * ey[i] + 2.5));
            enemies[i] = sphere.GetComponent<Enemy>();
        }
    }

    public int  existMyUnit(int x_, int y_)
    {
        for (int i = 0; i < myUnits.Length; i++)
        {
            if(myUnits[i].X == x_ && myUnits[i].Y == y_)
            {
                return i;
            }
        }
        return -1;
    }

    public int existEnemy(int x_, int y_)
    {
        for (int i = 0; i < this.enemies.Length; i++)
        {
            if (this.enemies[i].X == x_ && this.enemies[i].Y == y_)
            {
                return i;
            }
        }
        return -1;
    }


    public bool changeActiveCharacter(int x, int y)
    {
        if (!this.isSelectedAC)
        {
            this.isMyUnit = false;
            int myUnitIndex = existMyUnit(x, y);
            if (myUnitIndex != -1 && !this.myUnits[myUnitIndex].Acted)
            {
                this.activeCharacter = myUnits[myUnitIndex];
                this.IsSelectedAC = true;
                this.isMyUnit = true;
                Debug.Log("Active!");
                return true;

            }
            int enemyIndex = existEnemy(x, y);
            if (enemyIndex != -1 && !this.enemies[myUnitIndex].Acted)
            {
                this.activeCharacter = enemies[enemyIndex];
                this.isMyUnit = false;
                this.IsSelectedAC = true;
                Debug.Log("Active!");
                return true;
            }
        }
        return false;
    }

    public bool changePassiveCharacter(int x, int y)
    {
        if (this.isSelectedAC)
        {
            if (!this.isSelectedPC)
            {
                int myUnitIndex = existMyUnit(x, y);
                if (myUnitIndex != -1)
                {
                    this.passiveCharacter = myUnits[myUnitIndex];
                    this.isSelectedPC = true;
                    Debug.Log("Passive!");
                    return true;
                }
                int enemyIndex = existEnemy(x, y);
                if (enemyIndex != -1)
                {
                    this.IsSelectedPC = true;
                    this.passiveCharacter = enemies[enemyIndex];
                    Debug.Log("Passive!");
                    return true;
                }
            }
        }
        return false;
    }

    public Character getAciveCharacter ()
    {
        return this.activeCharacter;
    }

    public Character getPassiveCharacter()
    {
        return this.passiveCharacter;
    }

    public bool getIsMyUnit()
    {
        return this.isMyUnit;
    }

    public void turnEndAction()
    {
        for (int i = 0; i < myUnits.Length; i++)
        {
            myUnits[i].Acted = false;
            myUnits[i].Moved = false;
        }
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].Acted = false;
            enemies[i].Moved = false;
        }
    }

    public bool IsSelectedAC
    {
        get
        {
            return this.isSelectedAC;
        }
        set
        {
            this.isSelectedAC = value; 
        }
    }

    public bool IsSelectedPC
    {
        get
        {
            return this.isSelectedPC;
        }
        set
        {
            this.isSelectedPC = value;
        }
    }

    public bool isDestracted()
    {
        for (int i = 0; i < enemies.Length; i++ )
        {
            if (enemies[i].Hp > 0)
            {
                return false;
            }
        }
        return true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
