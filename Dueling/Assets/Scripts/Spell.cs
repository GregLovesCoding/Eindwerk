using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

    private int damage;
    private float accuracy = 5;
    private string name;

	// Use this for initialization
	void Start () {
        name = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += 1;
        transform.position = pos;
	}

    void OnCollisionEnter(Collision col) {

        float hit = Random.Range(0,10);
        if (hit < accuracy) {
            col.gameObject.SendMessage("ChangeHealth",damage);
        }

    
    }
}
