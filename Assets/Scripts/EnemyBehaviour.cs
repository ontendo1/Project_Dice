using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] int _enemyHealth;
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
        transform.LookAt(_mainCharacter.transform);
        Vector3 gap = _mainCharacter.transform.position - transform.position;

        //oyuncuyla arasında belli bir mesafe olduğunda ateş etmeye başlasın
        //mesafe yaklaştıysa ve coroutine null ise ateş etmeye başla else stop coroutine
        if (gap.x < _gapToStartFiring.x && _firingCoroutine == null)
        {
            _direction = gap.normalized;
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
            GameObject clone = Instantiate(_bullet, transform.position, Quaternion.identity);
            clone.GetComponent<Rigidbody>().velocity = _direction * _bulletSpeed;
            Destroy(clone, 5f);

            yield return new WaitForSeconds(_enemyFiringRate);
        }
    }


}
