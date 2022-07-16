using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<DiceBehaviour> _dices;

    void Awake()
    {
        _dices = new List<DiceBehaviour>();
    }

}
