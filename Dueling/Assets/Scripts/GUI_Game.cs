using UnityEngine;
using System.Collections;

public class GUI_Game : MonoBehaviour {




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void SetStatus(int health,int mana,int shield,string name,int playerNumber) { 
           int pos;
        if (playerNumber==1)
        {
            pos = 10;
        }
        else  {

            pos = Screen.width - 100;
        }
        GUI.Label(new Rect(pos, 10, 100, 30), "Player:" + playerNumber);
        GUI.Label(new Rect(pos, 40, 100, 30), "Health:" + health);
        GUI.Label(new Rect(pos, 70, 100, 30), "Mana:" + mana);
    
    }
}
