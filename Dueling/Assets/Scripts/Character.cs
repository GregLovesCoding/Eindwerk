using UnityEngine;
using System.Collections;
using System.Threading;
public class Character : MonoBehaviour
{

    public class Spell
    {

        private string name;
        private int type;
        private int value;
        private int cost;
        private int cooldown;
        private int castTime;
        private int accuracy;
        private bool ready;
        private float cooldownProgress;





        public Spell(string name, int type, int value, int cost, int cooldown, int castTime, int accuracy)
        {

            this.name = name;
            this.type = type;
            this.value = value;
            this.cost = cost;
            this.cooldown = cooldown;
            this.castTime = castTime;
            this.accuracy = accuracy;

        }

        public string GetName()
        {
            return name;

        }

        public int GetType()
        {

            return type;
        }

        public int GetValue()
        {
            return value;
        }

        public int GetCost()
        {

            return cost;
        }

        public int GetCooldown()
        {
            return cooldown;

        }

        public int GetCastTime()
        {
            return castTime;

        }

        public int GetAccuracy()
        {
            return accuracy;
        }


    }

    public int playerNumber;
    public int health = 100;
    public int mana = 100;
    public int damage;
    public int defense;
    public int healthRegen = 1;
    public int manaRegen = 1;
    public int accuracy;
    public int critChance;

    private bool canAttack;
    public bool isPlayer;

    private Spell[] spells;
    private float regenCounter = 0;
    private float castTimer = 0;

    private bool startCast=false;
    private int castCooldown=0;

    private GameObject uiObj;


    // Use this for initialization
    void Start()
    {
       uiObj = GameObject.Find("Canvas");

        spells = new Spell[4];
        spells[0] = new Spell("Fire", 1, damage * 2, 20, 5, 1, 1);
        spells[1] = new Spell("Shield", 2, damage * 2, 20, 1, 1, 1);
        spells[2] = new Spell("Stun", 3, damage * 2, 20, 1, 1, 1);
        spells[3] = new Spell("Heal", 4, damage * 2, 20, 1, 1, 1);

    }

    // Update is called once per frame
    void Update()
    {
        if (playerNumber == 1) {
            uiObj.SendMessage("SetHealth", health);
            uiObj.SendMessage("SetMana", mana);
            uiObj.SendMessage("SetCastTimer", castTimer);
        }
        
        
       
        regenCounter += Time.deltaTime;
       // regenerate health and magic
        if (health > 0 && regenCounter >= 1)
        {
            ChangeHealth(healthRegen);
            ChangeMana(manaRegen);
            regenCounter = 0;
        }

        if (startCast)
        {
            castTimer += Time.deltaTime;
            if (castTimer >= castCooldown)
            {
                Debug.Log("Shots fired!");
                castTimer = 0;
                castCooldown = 0;
            }

        }


    }


    void Cast(string spell)
    {
       
        for (int i = 0; i < spells.Length; i++)
        {
            if (spell.Contains(spells[i].GetName()))
            {

                startCast = true;
                castCooldown = spells[i].GetCooldown();
                ChangeMana(-spells[i].GetCost());
                Debug.Log("start casting");
            }
            else {

               
            }

        }
       
     /*   if (canCast)
        {
            Debug.Log("Shots fired!");

          
         //   GameObject spellObject = (GameObject)Instantiate(Spell, transform.position, transform.rotation);
         //   Vector3 Caster = transform.position;

         //   spellObject.name = Spell.ToString();

         //   Vector3 Target;

            if (isPlayer)
            {


            }
        }
        else
        {
            TakeHit(damage);
        }
        */



    }

    void TakeHit(int damage)
    {
        Debug.Log("Hit:" + damage);
        ChangeHealth(-damage);
    }

    void ShowMiss() { }

    void ChangeHealth(int newHealth)
    {
        int sum = health + newHealth;

        if (sum > 100)
        {
            health = 100;
        }
        else if (sum < 0)
        {
            health = 0;
            Debug.Log("Game Over");
        }
        else
        {
            health += newHealth;
        }

    }

    void ChangeMana(int newMana)
    {
        int sum = mana + newMana;

        if (sum > 100)
        {
            mana = 100;
        }
        else if (sum < 0)
        {
            mana = 0;
        }
        else
        {
            mana += newMana;
        }

    }


    void ChangeStatus() { }

    void FailCast()
    {

        //do damage to self
        ChangeHealth(-damage);

        Debug.Log("cast failed");
    }


    void OnGUI()
    {
        int pos;
        if (playerNumber == 1)
        {
            pos = 10;
        }
        else
        {

            pos = Screen.width - 100;
        }
        GUI.Label(new Rect(pos, 10, 100, 30), "Player:" + playerNumber);
        GUI.Label(new Rect(pos, 40, 100, 30), "Health:" + health);
        GUI.Label(new Rect(pos, 70, 100, 30), "Mana:" + mana);
        GUI.Label(new Rect(pos, 100, 100, 30), "cooldown:" + castTimer);


    }

}
