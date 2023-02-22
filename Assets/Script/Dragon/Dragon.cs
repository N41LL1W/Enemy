using UnityEngine;
using UnityEngine.UI;

namespace Script.Dragon
{
    public class Dragon : MonoBehaviour
    {
        public int HP = 100;
        public Slider healthBar;
        public Animator animator;

        public GameObject fireBall;
        public Transform fireBallPoint;

        private void Update()
        {
            healthBar.value = HP;
        }

        public void Scream()
        {
            FindObjectOfType<AudioManager>().Play("DragonScream");
        }
    
        public void Attack()
        {
            FindObjectOfType<AudioManager>().Play("DragonAttack");
        }

        public void TakeDamage(int damageAmount)
        {
            HP += damageAmount;
            if (HP <= 0)
            {
                FindObjectOfType<AudioManager>().Play("DragonDeath");
                animator.SetTrigger("die");
                GetComponent<Collider>().enabled = false;
            }

            else
            {
                FindObjectOfType<AudioManager>().Play("DragonDamage");
                animator.SetTrigger("damage");
            }
        }
    }
}
