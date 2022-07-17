using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnderinScriptiGeleneKadar : MonoBehaviour
{
    //kolları bacakları falan da önderin yaptığı gibi ayırmalıyım. 
    [SerializeField] GameObject[] _childs;

    [Header("DiceMan'imizin özelliklerini doldurma")]
    int _health = 1;
    int _attack = 1;
    int _moveSpeed = 1;

    void Awake()
    {
        
        //Diğer scene'e geçerken destroy olmamak
        DontDestroyOnLoad(gameObject);


    }

    void Update()
    {

    }

    public void ModifyHealth(int value)
    {
        _health += value;
        Debug.Log("health " + _health);
    }

    public void ModifyAttack(int value)
    {
        _attack += value;
        Debug.Log("attack " + _attack);
    }

    public void ModifyMoveSpeed(int value)
    {
        _moveSpeed += value;
        Debug.Log("movespeed " + _moveSpeed);
    }
}
