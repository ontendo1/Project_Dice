using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<DiceBehaviour> _dices;
    [SerializeField] float _delayForActivate = 2f;
    [SerializeField] float _delayForFreeze = 2f;
    [SerializeField] float _delayForLoading = 5f;

    OnderinScriptiGeleneKadar _diceMan;
    int _throwedDices;
    bool _canLoadNextScene = true;

    private void Awake()
    {
        _diceMan = FindObjectOfType<OnderinScriptiGeleneKadar>();
    }

    void Update()
    {
        //atılmış olanlar ve hepsi atıldıysa loading. bu sadece atma
        if (_throwedDices < _dices.Count)
        {
            if (_dices[_throwedDices].IsThrowed)
            {
                _throwedDices++;
                Invoke("ActivateGameobject", _delayForActivate);
            }
        }

        if (_dices.Count == _throwedDices)
        {
            Invoke("FreezeDices", _delayForFreeze);
            Invoke("CheckSuccesfulThrows", _delayForFreeze);
            Invoke("LoadNextScene", _delayForLoading);
        }
    }

    void CheckSuccesfulThrows()
    {
        if (_diceMan.SuccesfulThrowing < 1 && _diceMan != null)
        {
            Destroy(_diceMan.gameObject);
            _canLoadNextScene = false;
        }
    }

    void LoadNextScene()
    {
        if (_canLoadNextScene)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(0);
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