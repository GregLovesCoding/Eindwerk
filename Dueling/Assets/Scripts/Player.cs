using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject Spell;
    private bool recognizeSpell;
    private bool recognizeGesture;
    private string spellName;
    private float castStartTimer;
    public float castWaitMax;
	// Use this for initialization
	void Start () {
        spellName = null;
        castStartTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {
            recognizeSpell = true;
          recognizeGesture = true;
        
        }

        //if the gesture and name of the spell are correct, the spell is cast. otherwise, the cast fails.
        if (recognizeGesture || recognizeSpell) {
            castStartTimer += Time.deltaTime;

            if (castStartTimer <= castWaitMax)
            {
                if (recognizeGesture && recognizeSpell)
                {
                    gameObject.SendMessage("Cast", Spell);
                    castStartTimer = 0;
                    recognizeSpell = false;
                    recognizeGesture = false;
                }
            }
            else {
                gameObject.SendMessage("FailCast");
                recognizeSpell = false;
                recognizeGesture = false;
                castStartTimer = 0;
            }

        }
 
      
	}

    
}
