using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private int _playerHealth;
    [SerializeField] private int _playerMaxHealth;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _dashColdown;
    [SerializeField] private float _dashDuration;
    [SerializeField] private float _shootDelay;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Camera _cam;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private AudioClip[] _clips;
    [SerializeField] GameObject _deathMenu;
    private Shoot _shoot;
    private AudioSource _source;
    private Animator _animator;
    float _moveS;
    float xPosition;
    float yPosition;
    Vector2 _movement;
    Vector2 _mousePos;
    private static readonly int Shoot = Animator.StringToHash("Shoot");
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");

    private void Start()
    {
        _moveS = _moveSpeed;
        _playerHealth = _playerMaxHealth;
        _source = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _shoot = GetComponent<Shoot>();
        _healthBar.SetMaxHealth(_playerMaxHealth);
    }
    void Movement()
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
        if (_movement.x !=0 || _movement.y != 0)
        {
            if (!_source.isPlaying)
            {
                _source.PlayOneShot(_clips[0]);
            }
            _animator.SetBool(IsMoving, true);
        }
        else
        {
            _source.Stop();
            _animator.SetBool(IsMoving, false);
        }
        
    }
    float delay;
    void Update()
    {

        Movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }
        if (Input.GetButton("Fire1") && Time.time > delay)
        {
            _shoot.Fire();
            _animator.SetTrigger(Shoot);
            delay = Time.time + _shootDelay;
        }
        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

    }
    private float сooldown = 0f;
    private void Dash()
    {
        xPosition = _rigidbody.transform.position.x;
        yPosition = _rigidbody.transform.position.y;
        if (Time.time >= сooldown)
        {
            _rigidbody.DOMove(new Vector2(xPosition + (_dashSpeed * _movement.x * _moveSpeed), yPosition + (_dashSpeed * _movement.y * _moveSpeed)), _dashDuration).SetEase(Ease.Linear); //ассет DOTween из assetstore
            сooldown = Time.time + _dashColdown;
        }
    }

    private void FixedUpdate()
    {        
        Vector2 lookDir = _mousePos - _rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 0f;
        _rigidbody.rotation = angle;
    }


    public void TakeDamage(int damageValue)
    {
        _playerHealth -= damageValue;
        _healthBar.SetHealth(_playerHealth);
        if (_playerHealth <= 0)
        {
            _playerHealth = 0;
            Die();
        }
    }
    public void HealPlayer(int healValue)
    {
        _playerHealth += healValue;
        if (_playerHealth > _playerMaxHealth)
        {
            _playerHealth = _playerMaxHealth;
        }
        _healthBar.SetHealth(_playerHealth);
    }
    void Die()
    {
        _deathMenu.SetActive(true);
        Destroy(GameObject.Find("[DOTween]")); //исправление бага после рестарта (небыло возможности использовать Dash)
        gameObject.SetActive(false);
        Time.timeScale = 0;
    }
    
}
