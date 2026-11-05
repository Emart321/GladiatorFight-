using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SP
{
    public class EnemyStats : MonoBehaviour
    {
        public int healthLevel = 10;
        public int maxHealth;
        public int currentHealth;

        Animator animator;
        Collider collider;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            collider = GetComponent<CapsuleCollider>();
        }

        // Start is called before the first frame update
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            currentHealth = currentHealth - damage;

            animator.Play("straight_sword_oh_hit_F_01");

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("shield_oh_death_01");
                Destroy(collider);
            }
        }

    }
}
