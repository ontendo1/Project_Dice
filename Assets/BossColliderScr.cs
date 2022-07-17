using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossColliderScr : MonoBehaviour
{
    GameObject parent;
    Animator anim;
    BossScr bossScr;
    void Start()
    {
        
        parent = transform.parent.gameObject;
        anim = parent.GetComponent<Animator>();
        anim.speed = 0;

        bossScr = parent.GetComponent<BossScr>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") )
        {
            anim.speed = 0.6f;
            if (!IsInvoking(nameof(CheckGround))){
                InvokeRepeating(nameof(CheckGround),0f,1f);
            }
        }
    }
    void CheckGround()
    {
        if (bossScr.IsGround())
        {
            anim.speed = 0;
            CancelInvoke(nameof(CheckGround));
        }
    }

}
