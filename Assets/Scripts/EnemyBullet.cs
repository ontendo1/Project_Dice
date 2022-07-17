using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] int _bulletDamage = 10;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            MainCharacter mainCharacter = other.gameObject.GetComponent<MainCharacter>();
            mainCharacter.GetHit(_bulletDamage);
        }

        Destroy(gameObject);
    }
}
