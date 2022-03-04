using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] string _dontHitTag;
    [SerializeField] GameObject _hitEffect;
    [SerializeField] int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(_dontHitTag))
        {
            GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
            }
            Destroy(effect, 0.3f);
            Destroy(gameObject);
        }
    }
}
