using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int _enemyHealth;
    public int _enemyMaxHealth;
    [SerializeField] GameObject _deathEffect;
    [SerializeField] TMP_Text _text;
    [SerializeField] ScoreUI _score;

    private void Start()
    {
        _enemyHealth = _enemyMaxHealth;
        
    }
    public void TakeDamage(int damage)
    {
        _enemyHealth -= damage;
        
        if (_enemyHealth <=0)
        {
            _score._scoreUI += _enemyMaxHealth;
            _text.text = _score._scoreUI.ToString();
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
