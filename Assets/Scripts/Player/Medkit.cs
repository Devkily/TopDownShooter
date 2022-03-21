using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] int _HPChange;
    [SerializeField] string _playerTag;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_playerTag))
        {
            var health = collision.GetComponent<Player>();
            if (health != null)
            {
                if (_HPChange > 0)
                {
                    health.HealPlayer(_HPChange);
                    Destroy(gameObject);
                }
            }
        }

    }

}
