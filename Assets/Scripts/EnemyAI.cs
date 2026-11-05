using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace SP
{

    public class EnemyAI : MonoBehaviour
    {
        public GameObject player;
        public Transform target; // the player's transform
        public PlayerStats playerStats;
        public EnemyStats enemyStats;




        public float speed = 5f; // the enemy's movement speed
        public float attackRange = 3f; // the range at which the enemy can attack
        public float attackCooldown = 2f; // the time between attacks
                                          //public float dodgeChance = 0.3f; // the chance that the enemy will dodge an attack
        int horizontal;



        private Animator animator; // the enemy's animator


        private float timeSinceLastAttack; // the time since the enemy's last attack
        private bool isDodging; // whether the enemy is currently dodging



        void Start()
        {
            animator = GetComponent<Animator>();
            horizontal = Animator.StringToHash("Horizontal");

        }



        void Update()
        {
            // if the player is in range, move towards them and attack if possible

            if (enemyStats.currentHealth > 0 && playerStats.currentHealth > 0)
            {

                if (Vector3.Distance(transform.position, target.position) < attackRange)
                {
                    animator.SetFloat(horizontal, 0f, 0.1f, Time.deltaTime);

                    transform.LookAt(target);

                    if (!isDodging && timeSinceLastAttack > attackCooldown)
                    {
                        //int attackType = Random.Range(0, 2);
                        int attackType = 0;
                        if (attackType == 0)
                        {
                            //animator.SetTrigger("Attack1");
                            playerStats.TakeDamage(30);
                        }

                        // else
                        // {
                        //     //animator.SetTrigger("Attack2");
                        // }

                        timeSinceLastAttack = 0f;
                    }
                }

                else // otherwise, move towards the player
                {
                    animator.SetFloat(horizontal, 5f, 0.1f, Time.deltaTime);
                    transform.LookAt(target);
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }



                // update the attack cooldown timer

                timeSinceLastAttack += Time.deltaTime;
            }

            else
            {
                animator.SetFloat(horizontal, 0f, 0.1f, Time.deltaTime);
            }
        }



        /*public void TakeDamage(int damage)

        {

            if (!isDodging && Random.value < dodgeChance)

            {
                animator.SetTrigger("Dodge");

                isDodging = true;

                Invoke("EndDodge", 1f);
            }

            else
            {
                animator.SetTrigger("TakeDamage");

                // reduce the enemy's health here
            }
        }*/



        private void EndDodge()
        {
            isDodging = false;
        }



        // void OnTriggerEnter(Collider other)

        // {

        //     // if the enemy collides with the player, deal damage

        //     if (other.CompareTag("Player"))
        //     {

        //         PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

        //         if (playerHealth != null)
        //         {
        //             playerHealth.TakeDamage(10);
        //         }
        //     }
        // }

    }
}