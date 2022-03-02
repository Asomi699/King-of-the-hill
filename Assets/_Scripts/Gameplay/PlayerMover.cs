using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class PlayerMover : GameElement
{
    private bool _readyToJump = true;
    private int _lateralLimit = 3;
    private int _lateralShift = 0;
    private InputHandler _inputHandler;

    public event UnityAction StepTaken;

    public void Init(InputHandler inputHandler)
    {
        _inputHandler = inputHandler;
        
        _inputHandler.SwipeEvent += OnSwipe;
        _inputHandler.TouchEvent += JumpUp;
    }

    private void OnDisable()
    {
        _inputHandler.SwipeEvent -= OnSwipe;
        _inputHandler.TouchEvent -= JumpUp;
    }

    private void OnSwipe(Vector2 direction)
    {
        if(direction == Vector2.right)
            JumpRight();
        else if(direction == Vector2.left)
            JumpLeft();
    }
    
    public void JumpUp()
    {
        if (_readyToJump)
        {
            _readyToJump = false;
            Vector3 nextPosition = transform.position + new Vector3(1, 1, 0);
            
            var sequence = DOTween.Sequence();
            sequence.Append(transform.DOJump(nextPosition, 1.1f, 1, 0.3f, false));
            sequence.OnComplete(JumpComplete); 
        }
    }

    public void JumpLeft()
    {
        if (_readyToJump && _lateralShift < _lateralLimit)
        {
            int direction = 1;
            Shift(direction);
        }
    }

    public void JumpRight()
    {
        if (_readyToJump && _lateralShift > -_lateralLimit)
        {
            int direction = -1;
            Shift(direction);
        }
    }

    private void Shift(int direction)
    {
        _readyToJump = false;
        Vector3 nextPosition = transform.position + new Vector3(0, 0, direction);
        _lateralShift += direction;

        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOJump(nextPosition, 0.5f, 1, 0.3f, false));
        sequence.OnComplete(ShiftComplete);
    }

    private void ShiftComplete()
    {
        _readyToJump = true;
    }

    private void JumpComplete()
    {
        _readyToJump = true;
        StepTaken?.Invoke();
    }
}
