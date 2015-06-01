using UnityEngine;
using System.Collections;

public class SpellProjectile : MonoBehaviour {

       void Start()
        {
            name = gameObject.name;
        }


        // Update is called once per frame
        void Update()
        {
            Vector3 pos = transform.position;
            pos.x += 0.1f;
            transform.position = pos;
        }

	       void OnCollisionEnter(Collision col)
        {

            float hit = Random.Range(0, 10);
            int damage = 20;
          /*  if (hit < accuracy)
            {
                col.gameObject.SendMessage("TakeHit", damage);

            }*/
               if(col.gameObject.tag.Equals("Character"))
               {
                   col.gameObject.SendMessage("TakeHit", damage);
                   Debug.Log("Hit");
                   Destroy(gameObject);
              
               }
         
        }
	}

