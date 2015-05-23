using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject Spell;
    private bool spellRecognized;
    private bool gestureRecognized;
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


        //if the gesture and name of the spell are correct, the spell is cast. otherwise, the cast fails.
        if (gestureRecognized || spellRecognized)
        {
            castStartTimer += Time.deltaTime;

            if (castStartTimer <= castWaitMax)
            {
                if (gestureRecognized && spellRecognized)
                {
                    gameObject.SendMessage("Cast", Spell);
                    castStartTimer = 0;
                    spellRecognized = false;
                    gestureRecognized = false;
                }
            }
            else {
                gameObject.SendMessage("FailCast");
                spellRecognized = false;
                gestureRecognized = false;
                castStartTimer = 0;
            }

        }
 
      
	}

    void RecognizeGesture(int gesture) {
        gestureRecognized = true;
        spellRecognized = true;
        
    }

    
}
