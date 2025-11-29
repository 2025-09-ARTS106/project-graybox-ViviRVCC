using UnityEngine;

public class collisionDetection : MonoBehaviour
{
    public weaponController wp;
    public GameObject HitParticles;
    public enemyLogic enemyL;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy" && wp.isAttacking)
        {
            Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("Hit");
            Destroy(other.gameObject);
            Instantiate(HitParticles, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);     

        }
    
    }

 
}
