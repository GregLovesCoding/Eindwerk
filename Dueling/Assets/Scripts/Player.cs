using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

 
    private bool spellRecognized=false;
    private bool gestureRecognized=false;

    private string spellName="";
    private float castStartTimer;
    public float castWaitMax;

    // Use this for initialization
    void Start()
    {
   
        spellName = null;
        castStartTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
  

        
 
        //if the gesture and name of the spell are correct, the spell is cast. otherwise, the cast fails.
        if ( gestureRecognized || spellRecognized)
        {
            castStartTimer += Time.deltaTime;

            if (castStartTimer <= castWaitMax)
            {
                if (gestureRecognized && spellRecognized)
                {
                    gameObject.SendMessage("Cast",spellName);
                    castStartTimer = 0;
                    spellRecognized = false;
                    gestureRecognized = false;
                    spellName = "";
                    Debug.Log("initiate cast succeeded");
                }
            }
            else
            {
                gameObject.SendMessage("FailCast");
                spellRecognized = false;
                gestureRecognized = false;
                castStartTimer = 0;
            }

        }


    }

    void RecognizeGesture()
    {
   
            gestureRecognized = true;

         Debug.Log("Gesture");
    }

    void RecognizeSpell(string spell)
    {
        if (!spellRecognized) spellName = spell;
        spellRecognized = true;
       
    }



}
