using System.Collections;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public GameObject Scythe;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;
    public AudioClip ScytheSlash;
    public bool isAttacking = false;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                SwordAttack();
            }
        }
    }


    public void SwordAttack()
    {

        isAttacking = true;
        CanAttack = false;
        Animator anim = Scythe.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(ScytheSlash);
        StartCoroutine(ResetAttackCooldown());

    }


    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }

}



