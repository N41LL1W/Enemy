using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInt : MonoBehaviour
{
    Animator animator;
    
    public float hp, hpMax = 100;
    public float damage = 20;
    public string damageTag;

    public bool isAtacking = false;
    public string[] dAnims;
    
    void Start()
    {
        hp = hpMax;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != damageTag)
            return;
        
        DamageInt di = other.transform.root.GetComponent<DamageInt>();

        if(di.isAtacking == false)
            return;
        
        hp -= di.damage;
        PlayDamageAnim();
        di.isAtacking = false;


    }

    void PlayDamageAnim(){
        if(dAnims.Length != 0){
            int r = Random.Range(0,dAnims.Length);
            animator.Play(dAnims[r]);
        }
    }
    
    void GoAtk(){
        isAtacking = true;
    }

    void NotAtk(){
        isAtacking = false;
    }
}