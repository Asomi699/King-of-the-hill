using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class Obstacle : GameElement
{
    [SerializeField] private int _distanceToPlayer = 8;
    [SerializeField] private int _maxSteps = 10;
    
    private float _localOffset = -0.2f;
    private Vector3 _nextPosition;
    private int _pathCovered;
    
    private readonly Vector3 _positionOfNextStep = new Vector3(1, 1, 0);
    private readonly int _startPositionOffest = 3;
    
    
    private void OnEnable()
    {
        ResetPosition();
        StartCoroutine(DoStep());
    }
    
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    
    private void ResetPosition()
    {
        _pathCovered = 0;
        int position = Game.Controller.StepCounter.CurrentStep + _distanceToPlayer;
        int positionInWidth = Random.Range(-_startPositionOffest,_startPositionOffest);
        _nextPosition = new Vector3(position  + _localOffset, position, positionInWidth);
        transform.position = _nextPosition;
    }
    
    private void CalculateNextPosition()
    {
        if (_pathCovered == _maxSteps)
        {
            ReturnToPool();
            return;
        }
        
        _pathCovered++;
        _nextPosition -= _positionOfNextStep;
        StartCoroutine(DoStep());
    }
    
    IEnumerator DoStep()
    {
        yield return null;
        var sequence = DOTween.Sequence();
            sequence.Append(transform.DOJump(_nextPosition, 2.5f, 1, 0.6f, false));
            sequence.Append(transform.DOShakeScale(0.3f, 
                new Vector3(0.1f, 0.1f, 0.1f), 25, 60, true));
            sequence.AppendInterval(0.5f);
            sequence.OnComplete(CalculateNextPosition);
    }
    
    private void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
