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
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Gesture");
            gestureRecognized = true;
        }

        
 
        //if the gesture and name of the spell are correct, the spell is cast. otherwise, the cast fails.
        if (gestureRecognized || spellRecognized)
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
                    Debug.Log("initiate cast succeed");
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
        int key = GetKey();
        if (key != 0)
        {
            gestureRecognized = true;
            Debug.Log(key);
        }

    }

    void RecognizeSpell(string spell)
    {
        if (!spellRecognized) spellName = spell;
        spellRecognized = true;
        gestureRecognized = true;
    }

    //temporary function to check gestures

    int GetKey()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        { 
            return 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            return 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            return 4;
        }
  
        return 0;
    }

}
