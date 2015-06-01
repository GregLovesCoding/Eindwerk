using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUI_Game : MonoBehaviour
{

    private int healthL = 0;
    private int manaL = 0;
    private int shieldL;
    private float castTimerL;
    private string nameL;

    private int healthR;
    private int manaR;
    private int shieldR;
    private string nameR;

    private int playerNumber;

    private Image healthbarL;
    private Image manabarL;
    private Image castbarL;


    // Use this for initialization
    void Start()
    {
       healthbarL = GameObject.Find("Healthbar").GetComponent<Image>();
        manabarL = GameObject.Find("Manabar").GetComponent<Image>();
        castbarL = GameObject.Find("Castbar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

      float health = (float)healthL / 100.0f;
        Debug.Log("health:" + health);
        healthbarL.fillAmount = health;
        manabarL.fillAmount = (float)manaL / 100;
        castbarL.fillAmount = castTimerL / 100;
    }

    void SetStatus(int health, int mana, int shield, string name, int playerNumber)
    {

        if (playerNumber == 1)
        {
            healthL = health;
            manaL = mana;
            nameL = name;

        }
        else
        {
            healthR = health;
            manaR = mana;
            nameR = name;

        }
    }

    void SetHealth(int health)
    {
        healthL = health;

    }

    void SetMana(int mana)
    {
        manaL = mana;
    }

    void SetCastTimer(float time)
    {
        castTimerL = time;
    }

    /*   void OnGUI() {

           int pos;
           if (playerNumber == 1)
           {
               pos = 10;
           }
           else
           {

               pos = Screen.width - 100;
           }
         //  GUI.Label(new Rect(pos, 10, 100, 30), "Player:" + playerNumber);
         //  GUI.Label(new Rect(pos, 40, 100, 30), "Health:" + healthL);
          // GUI.Label(new Rect(pos, 70, 100, 30), "Mana:" + manaL);


         //  castbarL.fillAmount = castbarL
      
    
       }*/
}
