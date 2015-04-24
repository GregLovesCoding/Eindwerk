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
        Vector3 pos = transform.position;
        pos.x += 1;
        transform.position = pos;
	}

    void OnCollisionEnter(Collision col) { }
}
