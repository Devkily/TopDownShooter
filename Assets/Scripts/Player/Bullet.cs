using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletLiveTime;
    [SerializeField] string _dontHitTag;
    [SerializeField] GameObject _hitEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag(_dontHitTag))
        {
            GameObject effect = Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject ,_bulletLiveTime);
        }
    }
}
