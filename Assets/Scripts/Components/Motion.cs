using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectedCharacter))]
[RequireComponent(typeof(CharacterController))]
public class Motion : MonoBehaviour
{
    [Header("Fields")]
    [SerializeField] private float _smoothTime = 0.03f;

    [Header("Components")]
    [SerializeField] private SelectedCharacter _selectedCharacter;
    [SerializeField] private CharacterController _controller;

    public float directionSmoothed => _dirVector.x;

    private Vector3 _dirVector = Vector3.zero;
    private Vector3 _dirVelocity = Vector3.zero;

    private void Reset()
    {
        _selectedCharacter ??= GetComponent<SelectedCharacter>();
        _controller = GetComponent<CharacterController>() ?? gameObject.AddComponent<CharacterController>();
    }

    private void Update()
    {
        if (directionSmoothed != 0)
            _controller.Move(_dirVector * Time.deltaTime);
    }

    public void SetDirection(float direction)
    {
        Vector3 target = Vector3.right * direction * _selectedCharacter.actualProperties.Dexterity;
        _dirVector = Vector3.SmoothDamp(_dirVector, target, ref _dirVelocity, _smoothTime);
    }
}
