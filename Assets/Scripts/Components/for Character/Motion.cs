using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : CharacterBehaviour
{
    [Header("Fields")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _smoothTime = 0.03f;

    private Vector3 _rawDirection = Vector3.zero;
    private Vector3 _direction = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;

    public float direction { get; private set; }

    private void Update()
    {
        _rawDirection = Vector3.right * direction * _speed * _selected.actualProperties.Dexterity;
        _direction = Vector3.SmoothDamp(_direction, _rawDirection, ref _velocity, _smoothTime);
        transform.Translate(_direction * Time.deltaTime, Space.World);
    }

    public void SetDirection(float direction) => this.direction = direction;
}
