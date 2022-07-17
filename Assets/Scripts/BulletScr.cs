using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScr : MonoBehaviour
{
    ParticleSystem ps;
    [SerializeField] GameObject particleEff;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        Invoke(nameof(Destroy),7f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy();
        }
    }
    void Destroy()
    {
        particleEff.SetActive(true);
        particleEff.transform.parent = null;
        Destroy(gameObject);
    }
}
