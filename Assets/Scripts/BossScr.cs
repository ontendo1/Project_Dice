using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScr : MonoBehaviour
{
    [SerializeField] GameObject checkGroundObj;
    [SerializeField] bool onGround;
    [SerializeField] GameObject player;
    Vector3 defaultScale,defaulRot;
    void Start()
    {
        player = GameObject.Find("MainCharacter");
        defaultScale = transform.localScale;
        defaulRot = transform.eulerAngles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player.transform.position.x > transform.position.x)
        {
            transform.localScale = defaultScale;
            transform.eulerAngles = defaulRot;
        }
        else
        {
            transform.localScale = new Vector3(-defaultScale.x, defaultScale.y, defaultScale.z);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, 120f, transform.eulerAngles.z);
        }
        onGround = Physics.CheckSphere(checkGroundObj.transform.position, 0.15f, LayerMask.GetMask("Plane"));
    }

    public bool IsGround()
    {
        return onGround;
    }
}
