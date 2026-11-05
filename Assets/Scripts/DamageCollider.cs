using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public class DamageCollider : MonoBehaviour
    {
        Collider damageCollider;

        InputHandler inputHandler;
        WeaponSlotManager weaponSlotManager;
        AnimatorHandler animatorHandler;
        public string lastAttack;


        public int currentWeaponDamage = 25;
        public int currentHeavyWeaponDamage = 50;

        private void Awake()
        {
            damageCollider = GetComponent<Collider>();
            damageCollider.gameObject.SetActive(true);
            damageCollider.isTrigger = true;
            damageCollider.enabled = false;

        }

        public void EnableDamageCollider()
        {
            damageCollider.enabled = true;
        }

        public void DisableDamageCollider()
        {
            damageCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Player")
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                

                if (playerStats != null)
                {
                    playerStats.TakeDamage(currentWeaponDamage);
                }
            }

            if (collision.tag == "Enemy")
            {
                EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
                InputHandler inputHandler = GetComponent<InputHandler>();

                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(currentWeaponDamage);


                }
                /*if (enemyStats != null && )
                {
                    enemyStats.TakeDamage(currentHeavyWeaponDamage);
                }*/
                

            }
        }
    }
}
