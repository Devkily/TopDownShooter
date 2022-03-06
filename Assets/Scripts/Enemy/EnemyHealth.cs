using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] GameObject _deathEffect;
    
    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <=0)
        {
            Die();
        }
    }
    void Die()
    {
        GameObject effect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.4f);
        Destroy(gameObject);
    }
}
