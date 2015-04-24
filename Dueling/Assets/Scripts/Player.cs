using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject Spell;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            gameObject.SendMessage("Cast",Spell);
        
        }
	}
}
