using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    public int damage;
    public string effect;
    public int cooldown;
    public int castTime;
    public int Type;
    public int effectTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col) { }
}
