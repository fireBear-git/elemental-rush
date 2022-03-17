using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectedCharacter))]
[RequireComponent(typeof(CharacterController))]
public class Motion : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _smoothTime = 0.03f;

    [Header("Components")]
    [SerializeField] private SelectedCharacter _selectedCharacter;
    [SerializeField] private CharacterController _controller;

    private Vector3 _rawDirection = Vector3.zero;
    private Vector3 _direction = Vector3.zero;
    private Vector3 _velocity = Vector3.zero;

    public float direction { get; private set; }

    private void Reset()
    {
        _selectedCharacter ??= GetComponent<SelectedCharacter>();
        _controller = GetComponent<CharacterController>() ?? gameObject.AddComponent<CharacterController>();
    }

    private void Update()
    {
        _rawDirection = Vector3.right * direction * _speed * _selectedCharacter.actualProperties.Dexterity;
        _direction = Vector3.SmoothDamp(_direction, _rawDirection, ref _velocity, _smoothTime);
        _controller.SimpleMove(_direction);
    }

    public void SetDirection(float direction) => this.direction = direction;
}
