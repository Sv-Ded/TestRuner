using SplineMesh;
using System;
using UnityEngine;

public class SplineFolower : MonoBehaviour
{
    [SerializeField] private Spline _spline;
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private float _moveBorders;

    private float _speed;
    private float _splineRate;
    private float _input;
    private float _startMousePosition;
    private bool _gameIsBegin = false;

    public event Action MouseMoved;

    private void Awake()
    {
        _speed = _startSpeed;
    }

    private void Start()
    {
        transform.position = _spline.GetSample(_splineRate).location;
        SetStartCursorPosition();
    }

    private void Update()
    {
        _input = (Input.mousePosition.x - _startMousePosition) * _mouseSensitivity;
        _input = Mathf.Clamp(_input, -_moveBorders, _moveBorders);

        if (_gameIsBegin)
        {
            _splineRate += _speed * Time.deltaTime;

            if (_splineRate <= _spline.nodes.Count - 1)
            {
                SetPlace();
            }
        }

        if (_input < -0.1 || _input > 0.1 && _gameIsBegin == false)
        {
            MouseMoved?.Invoke();
            _gameIsBegin = true;
            _speed = _startSpeed;
        }
    }

    public void StopMoving()
    {
        _speed = 0;
        
        _gameIsBegin = false;
    }

    public void Restart()
    {
        _splineRate = 0;
        transform.position = _spline.GetSample(_splineRate).location;
    }

    private void SetPlace()
    {
        CurveSample sample = _spline.GetSample(_splineRate);

        transform.localPosition = sample.location + transform.right * _input;
        transform.localRotation = sample.Rotation;
    }

    private void SetStartCursorPosition()
    {
        Cursor.lockState = CursorLockMode.Locked;

        _startMousePosition = Input.mousePosition.x;

        Cursor.lockState = CursorLockMode.None;
    }
}
