using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScr : MonoBehaviour
{
    
    void Start()
    {
        Invoke(nameof(Destroy),7f);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
