using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _player;
    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] string _playerTag = "Player";
    [SerializeField] float _attackSpeed;
    [SerializeField] int _attackDamage;
    Transform _folow;
    private Player _playerHealth;
    Vector2 movement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerHealth = FindObjectOfType<Player>();
        _player.GetComponent<Transform>();
    }


    private void Update()
    {

        _folow = _player.transform;
        Vector3 direction = _folow.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = angle;
        direction.Normalize();
        movement = direction;

    }
    private void FixedUpdate()
    {
        EnemyMove(movement);
    }
    void EnemyMove(Vector2 direction)
    {
        _rb.MovePosition((Vector2)transform.position + (direction * _speed * Time.deltaTime));
    }
    private float time = 0f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_playerTag) && time <= Time.time)
        {
            if (_playerHealth != null)
            {
                Vector2 rigit = _rb.transform.position;
                _rb.transform.position = rigit - movement*2;
                _playerHealth.TakeDamage(_attackDamage);
                time = Time.time + _attackSpeed;
            }
            
        }
    }


}
