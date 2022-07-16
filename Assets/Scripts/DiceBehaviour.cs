using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBehaviour : MonoBehaviour
{
    [SerializeField] float _pushForce;
    
    Camera _cam;
    Rigidbody _rb;

    Vector3 _startPoint;
    Vector3 _endPoint;
    Vector3 _direction;
    float _distance;
    Vector3 _force;
    Vector3 _gap;

    void Awake()
    {
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        _rb.isKinematic = true;
        _gap = Input.mousePosition - _cam.WorldToScreenPoint(transform.position);
        _startPoint = _cam.ScreenToWorldPoint(Input.mousePosition - _gap);
    }

    void OnMouseDrag()
    {
        _endPoint = _cam.ScreenToWorldPoint(Input.mousePosition - _gap);
        _distance = Vector3.Distance(_startPoint, _endPoint);
        _direction = (_startPoint - _endPoint).normalized;

        _force = _distance * _direction * _pushForce;

        Debug.DrawLine(_startPoint, _endPoint);
    }

    void OnMouseUp()
    {
        _rb.isKinematic = false;
        _rb.AddForce(_force, ForceMode.Impulse);

        Vector3 vb = new Vector3(GetRandomRotation(), GetRandomRotation(), GetRandomRotation());
        _rb.AddTorque(vb, ForceMode.Impulse);
    }

    float GetRandomRotation()
    {
        return Random.Range(0, 360f);
    }
}
