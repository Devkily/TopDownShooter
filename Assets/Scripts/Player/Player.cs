using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashColdown;
    [SerializeField] private float _dashDuration;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Camera _cam;
    float _moveS;
    float xPosition;
    float yPosition;
    Vector2 _movement;
    Vector2 _mousePos;
    private void Start()
    {
        _moveS = _moveSpeed;
    }
    
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        if (_moveSpeed == _moveS && _movement.x != 0 && _movement.y != 0)
        {
            _moveSpeed /= 1.6f;
        }
        else if (_moveSpeed != _moveS)
        {
            if (_movement.x == 0 || _movement.y == 0)
            {
                _moveSpeed *= 1.6f;
            }
        }
        _rigidbody.MovePosition(_rigidbody.position + _movement * _moveSpeed * Time.fixedDeltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
        
        
        

        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private float time = 0f;
    private void Dash()
    {
        xPosition = _rigidbody.transform.position.x;
        yPosition = _rigidbody.transform.position.y;
        if (Time.time >= time)
        {
            _rigidbody.DOMove(new Vector2(xPosition + (_dashSpeed * _movement.x*_moveSpeed), yPosition + (_dashSpeed * _movement.y*_moveSpeed)), _dashDuration).SetEase(Ease.Linear); //ассет DOTween из assetstore
            time = Time.time + _dashColdown;
        }
    }

    private void FixedUpdate()
    {        
        Vector2 lookDir = _mousePos - _rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 0f;
        _rigidbody.rotation = angle;
    }
    

    public void TakeDamage(int damage)
    {
        xPosition = _rigidbody.transform.position.x;
        yPosition = _rigidbody.transform.position.y;
        _health -= damage;
        //_rigidbody.DOMove(new Vector2(xPosition, yPosition + (_dashSpeed * _moveSpeed)), _dashDuration).SetEase(Ease.Linear);
        if (_health <= 0)
        {
            _health = 0;
            Die();
        }
    }
    void Die()
    {
        SceneManager.LoadScene(0);
    }
}
