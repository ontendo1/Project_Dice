using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBehaviour : MonoBehaviour
{
    [SerializeField] float _additionalForce;

    [SerializeField] bool _isHead;
    [SerializeField] bool _isTrunk;
    [SerializeField] bool _isArm;
    [SerializeField] bool _isLeg;

    public bool IsHead
    {
        get { return _isHead; }
    }
    public bool IsTrunk
    {
        get { return _isTrunk; }
    }
    public bool IsArm
    {
        get { return _isArm; }
    }
    public bool IsLeg
    {
        get { return _isLeg; }
    }

    [Header("Instance oluşturma")]
    Camera _cam;
    Rigidbody _rb;
    OnderinScriptiGeleneKadar _haha;
    List<Transform> _diceNumbers;

    [Header("Zar atma")]
    Vector3 _startPoint;
    Vector3 _endPoint;
    Vector3 _direction;
    float _distance;
    Vector3 _force;
    Vector3 _gap;

    [Header("Gelen sayıyı bulma")]
    int _winnerNumber;
    public int WinnerNumber
    {
        get { return _winnerNumber; }
    }
    bool _isHit;

    bool _isThrowed;

    void Awake()
    {
        //getting component etc.
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody>();
        _haha = FindObjectOfType<OnderinScriptiGeleneKadar>();

        //getting childs
        _diceNumbers = new List<Transform>();
        foreach (Transform child in gameObject.transform)
        {
            _diceNumbers.Add(child);
        }
    }

    private void Update()
    {
        //hepsininki isthrowed ise ve birleşmeyen varsa birbirlerine yaklaşma olayı başlayabilir.
        //ayrıca isthrowed diğer scenede de dokunulamasın diye işe yarıyor.
    }

    void OnMouseDown()
    {
        if (_isThrowed)
        {
            return;
        }

        //Donduruyor, mouse ile zar arası farkı hesaplıyor, ilk tıklanan yeri alıyor
        _rb.isKinematic = true;
        _gap = Input.mousePosition - _cam.WorldToScreenPoint(transform.position);
        _startPoint = _cam.ScreenToWorldPoint(Input.mousePosition - _gap);
    }

    void OnMouseDrag()
    {
        if (_isThrowed)
        {
            return;
        }
        _endPoint = _cam.ScreenToWorldPoint(Input.mousePosition - _gap);
        Debug.DrawLine(_startPoint, _endPoint);
    }


    void OnMouseUp()
    {
        if (_isThrowed)
        {
            return;
        }
        RollTheDice();
    }

    void OnCollisionEnter(Collision other)
    {
        //Herhangi bir yere çarpınca donduruyor ve gelen sayıyı alıyor.
        if (other.gameObject.CompareTag("BottomEdge") || other.gameObject.CompareTag("Dice"))
        {
            _isHit = true;
            _rb.isKinematic = true;
            GetWinnerNumber();
        }

        if (other.gameObject.CompareTag("BottomEdge") || other.gameObject.CompareTag("DestroyerLine"))
        {
            //Herhangi bir yere çarpınca atılmış sayılacak. isHit yoksa eğer default 1 gelcek.
            //Dice a çarpınca atılmış sayılmayacak ki zaten tek tek attırırım gibi.!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            _rb.isKinematic = true;
            transform.parent.GetComponent<OnderinScriptiGeleneKadar>().ThrowedDices.Add(this);

            Debug.Log("atıldı");
            //aşağı çarpanı da destroylayacaktım ama bottomedgee çarpanın olmaması lazım. Ayırmalı olacak!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }

    void RollTheDice()
    {
        //Dondurmayı kaldırıyor, force ve torque hesaplayıp fırlatıyor.
        _rb.isKinematic = false;

        _distance = Vector3.Distance(_startPoint, _endPoint);
        _direction = (_startPoint - _endPoint).normalized;
        Vector3 force = _distance * _direction * _additionalForce;

        _rb.AddForce(force, ForceMode.Impulse);
        _rb.AddTorque(GetRandomRotation(), ForceMode.Impulse);

        //fırlatıldı
        _isThrowed = true;
    }

    void GetWinnerNumber()
    {
        if (_isHit)
        {
            float _lowestZ = 0;
            foreach (Transform child in _diceNumbers)
            {
                if (child.position.z <= _lowestZ)
                {
                    _lowestZ = child.position.z;
                    _winnerNumber = _diceNumbers.IndexOf(child) + 1;

                    Debug.Log(_lowestZ);
                    Debug.Log(name + " " + _winnerNumber);
                }
            }
            _isHit = false;
        }
    }

    Vector3 GetRandomRotation()
    {
        return new Vector3(Random.Range(0, 360f), Random.Range(0, 360f), Random.Range(0, 360f));
    }
}
