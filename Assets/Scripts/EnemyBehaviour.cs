using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] int _enemyHealth = 100;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _bulletSpeed = 2f;
    [SerializeField] float _enemyFiringRate = 2f;
    [SerializeField] Vector3 _gapToStartFiring;

    MainCharacter _mainCharacter;
    Vector3 _direction;
    Coroutine _firingCoroutine;

    void Awake()
    {
        _mainCharacter = FindObjectOfType<MainCharacter>();
    }

    void Update()
    {
        Vector3 gap = _mainCharacter.transform.position - transform.position;
        _direction = gap.normalized;

        //oyuncuyla arasında belli bir mesafe olduğunda ateş etmeye başlasın
        //mesafe yaklaştıysa ve coroutine null ise ateş etmeye başla else stop coroutine
        if (gap.x < _gapToStartFiring.x && _firingCoroutine == null)
        {
            _firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (gap.x > _gapToStartFiring.x && _firingCoroutine != null)
        {
            StopCoroutine(_firingCoroutine);
        }

    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject clone = Instantiate(_bullet, transform.position, _bullet.transform.rotation);
            clone.GetComponent<Rigidbody>().velocity = _direction * _bulletSpeed;
            Destroy(clone, 3f);

            yield return new WaitForSeconds(_enemyFiringRate);
        }
    }


}
