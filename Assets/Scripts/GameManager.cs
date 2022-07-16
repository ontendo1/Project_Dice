using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<DiceBehaviour> _dices;
    [SerializeField] float _delay = 2f;

    int _number;

    public int ThrowedDices { get; set; }

    void Update()
    {
        if (_dices[_number].IsThrowed && _number + 1 < _dices.Count)
        {
            _number++;
            Invoke("ActivateGameobject", _delay);
        }
    }

    void ActivateGameobject()
    {
        _dices[_number].gameObject.SetActive(true);
    }
}