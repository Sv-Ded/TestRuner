using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : SimpleAnimation
{
    private Transform[] _doors;
    private int _direction = 90;

    private void Awake()
    {
        _doors = GetComponentsInChildren<Transform>();
    }

    public override void Animate()
    {
        for (int i = 1; i<_doors.Length; i++)
        {
            _doors[i].DORotate(Vector3.up *_direction, Duration).SetEase(EaseType);
            _direction = -_direction;
        }
    }
}
