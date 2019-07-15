using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneController : MonoBehaviour {
    Map map;
    PlayerController player;
    CharacterController chara;
    int turn = 1;
	// Use this for initialization
	void Start () {
        Debug.Log("turn: " + turn);
        map = GameObject.Find("Terrain").GetComponent<Map>();
        player = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        chara = GameObject.Find("CharacterController").GetComponent<CharacterController>();
        map.CreateMap();
	}
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
    UnityEngine.Application.Quit();
#endif
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Escape)) Quit();
        if (!player.IsMyTurn)
        {
            
            this.turn++;
            Debug.Log("turn: " + turn);
            player.IsMyTurn = true;
        }
        if (chara.isDestracted())
        {
            SceneManager.LoadScene("ClearScene");
        }
	}
}
