using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    [SerializeField] private bool isEnemyAttack = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyHealth enemyHealth = other.gameObject.GetComponent<EnemyHealth>();
        Indestructible indesctruitible = other.gameObject.GetComponent<Indestructible>();
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();

        if (!other.isTrigger && (enemyHealth || indesctruitible || player))
        {
            if ((player && isEnemyAttack) || (enemyHealth && !isEnemyAttack))
            {
                if (player) { player.TakeDamage(1, transform); }
                    
                //player?.TakeDamage(1, transform);
            }
            /*else if (!other.isTrigger && indesctruitible)
            {
                Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            */
        }

    }
}
