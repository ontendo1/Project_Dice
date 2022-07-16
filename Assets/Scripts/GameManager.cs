using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<DiceBehaviour> _dices;
    [SerializeField] float _delayForActivate = 2f;
    [SerializeField] float _delayForFreeze = 2f;

    int _throwedDices;

    void Update()
    {
        if (_throwedDices < _dices.Count)
        {
            if (_dices[_throwedDices].IsThrowed)
            {
                _throwedDices++;
                Invoke("ActivateGameobject", _delayForActivate);
                Debug.Log(_throwedDices);
            }
        }
        if (_dices.Count == _throwedDices)
        {
            Invoke("FreezeDices", _delayForFreeze);
        }
    }

    void FreezeDices()
    {
        foreach (DiceBehaviour dice in _dices)
        {
            if (dice != null)
            {
                dice.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    void ActivateGameobject()
    {
        if (_throwedDices < _dices.Count)
        {
            _dices[_throwedDices].gameObject.SetActive(true);
        }
    }
}