using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnderinScriptiGeleneKadar : MonoBehaviour
{
    //diğer scriptten zarlara göre health vs gibi özellikleri doldurucaz burada. Hepsi isthrowed olunca. ----------- Bitti
    //kolları bacakları falan da önderin yaptığı gibi ayırmalıyım. 

    [Header("Tüm zarlar atıldı mı diye kontrol etme")]
    List<DiceBehaviour> _throwedDices;
    public List<DiceBehaviour> ThrowedDices
    {
        get { return _throwedDices; }
    }
    int _totalDiceCount;

    [Header("DiceMan'imizin özelliklerini doldurma")]
    int _health = 1;
    int _attack = 1;
    int _moveSpeed = 1;

    void Awake()
    {
        _throwedDices = new List<DiceBehaviour>();

        //Diğer scene'e geçerken destroy olmamak
        DontDestroyOnLoad(gameObject);

        //toplam zar sayısı almak
        foreach (DiceBehaviour dice in GetComponentsInChildren<DiceBehaviour>())
        {
            _totalDiceCount++;
        }
        Debug.Log(_totalDiceCount);

    }

    void Update()
    {
        if (_totalDiceCount == _throwedDices.Count)
        {
            foreach (DiceBehaviour dice in _throwedDices)
            {
                if (dice.IsHead || dice.IsTrunk)
                {
                    _health += dice.WinnerNumber;
                }
                else if (dice.IsArm)
                {
                    _attack += dice.WinnerNumber;
                }
                else if (dice.IsLeg)
                {
                    _moveSpeed += dice.WinnerNumber;
                }
            }

            Debug.Log("health: " + _health);
            Debug.Log("attack: " + _attack);
            Debug.Log("speed: " + _moveSpeed);

            _totalDiceCount = 0;
        }
    }
}
