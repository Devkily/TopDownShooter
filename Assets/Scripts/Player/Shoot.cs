using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _shotSpeed = 10f;
    [SerializeField] float _bulletLiveTime = 3f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    void Fire()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(_firePoint.up * _shotSpeed, ForceMode2D.Impulse);
        Destroy(bullet, _bulletLiveTime);
    }


}
