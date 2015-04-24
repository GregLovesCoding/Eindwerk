using UnityEngine;
using System.Collections;
using System.Threading;
public class Character : MonoBehaviour {

    public int health;
    public int mana;
    public int damage;
    public int defense;
    public int healthRegen=1;
    public int manaRegen=1;
    public int accuracy;
    public int critChance;
    private bool canAttack;
    public bool isPlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //regenerate health and magic
         ChangeHealth(healthRegen);
         ChangeMana(manaRegen);
        
	}


    void Cast(GameObject Spell) {

      GameObject spellObject=(GameObject) Instantiate(Spell,transform.position,transform.rotation);
      Vector3 Caster=transform.position;
      Vector3 Target;

      if (isPlayer) { 
      
      
      }
        
       

    }


    void ChangeHealth(int newHealth) {

        if (health <= 100 && health >=0) health+=newHealth;
    
    }

    void ChangeMana(int newMana) {
        if (mana < 100 && health >=0 ) mana += newMana;
    
    }


    void ChangeStatus() { }



}
