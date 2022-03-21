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
    //[SerializeField] TMP_Text _text;
    //[SerializeField] ScoreUI _score;
    //[SerializeField] ScoreManager _score;
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] BoxCollider2D _collider;
    [SerializeField] GameObject _healthBar;
    private AudioSource _source;

    private void Start()
    {
        _enemyHealth = _enemyMaxHealth;
        _source = GetComponent<AudioSource>();
    }
    public void TakeDamage(int damage)
    {
        _enemyHealth -= damage;
        
        if (_enemyHealth <=0)
        {
            _source.enabled = true;
            ScoreManager.score += _enemyMaxHealth;
            Die();
        }
    }
    void Die()
    {
        GameObject effect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
        _sprite.enabled = false;
        _collider.enabled = false;
        _healthBar.SetActive(false);
        Destroy(effect, 0.4f);
        Destroy(gameObject, 1f);
    }
}
