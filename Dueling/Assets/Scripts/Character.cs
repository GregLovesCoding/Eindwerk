using UnityEngine;
using System.Collections;
using System.Threading;
public class Character : MonoBehaviour
{

    public class Spell
    {
       
        public string name;
        public int type;
        public int value;
        public int cost;
        public int cooldown;
        public int castTime;
        public int accuracy;
        public bool ready;
     
      


        public Spell(string name,int type,int value,int cost, int cooldown, int castTime,int accuracy) {

            this.name = name;
            this.type = type;
            this.value = value;
            this.cost = cost;
            this.cooldown = cooldown;
            this.castTime = castTime;
            this.accuracy = accuracy;

        }

 
 
    
    }

    public int playerNumber;
    public int health = 1;
    public int mana = 1;
    public int damage;
    public int defense;
    public int healthRegen = 1;
    public int manaRegen = 1;
    public int accuracy;
    public int critChance;
    private bool canAttack;
    public bool isPlayer;
    private Spell[] spells;
    // Use this for initialization
    void Start()
    {
      
           spells=new Spell[4];
           spells[0]= new Spell("Fire",1,damage*2,20,1,1,1);
           spells[1] = new Spell("Shield", 2, damage * 2, 20, 1, 1, 1);
           spells[2] = new Spell("Stun", 3, damage * 2, 20, 1, 1, 1);
           spells[3] = new Spell("Heal", 4, damage * 2, 20, 1, 1, 1);

    }

    // Update is called once per frame
    void Update()
    {

        //regenerate health and magic
        if (health > 0) {
            ChangeHealth(healthRegen);
            ChangeMana(manaRegen);
        }
 

    }


    void Cast(GameObject Spell)
    {
        bool canCast = true;
        for (int i = 0; i < spells.Length; i++) {
            if (spells[i].name == Spell.name) {
                canCast = true;
            }
       
        }
        if (canCast)
        {
            GameObject spellObject = (GameObject)Instantiate(Spell, transform.position, transform.rotation);
            Vector3 Caster = transform.position;

            spellObject.name = Spell.ToString();

            Vector3 Target;

            if (isPlayer)
            {


            }
        }
        else { 
            TakeHit(damage); 
        }
   



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
        else {
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
        if (playerNumber==1)
        {
            pos = 10;
        }
        else  {

            pos = Screen.width - 100;
        }
        GUI.Label(new Rect(pos, 10, 100, 30), "Player:" + playerNumber);
        GUI.Label(new Rect(pos, 40, 100, 30), "Health:" + health);
        GUI.Label(new Rect(pos, 70, 100, 30), "Mana:" + mana);
       
        

    }

}
