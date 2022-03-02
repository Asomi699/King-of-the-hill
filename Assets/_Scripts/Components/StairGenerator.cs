using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StairGenerator : GameElement
{
    [SerializeField] private GameObject _stairContainer;
    [SerializeField] private int _numberStairs;
    
    private readonly int _firstPosition = -5;
    
    private GameObject _stair;
    private List<GameObject> _allStairs;
    private int _counter;
    private PlayerMover _player;

    public void Init(GameObject player)
    {
        _player = player.GetComponent<PlayerMover>();
        _player.StepTaken += OnMoveStair;
        
        _allStairs = new List<GameObject>();
        
        CreatePoolStairs();
        BuildStairs();
    }

    private void OnDisable()
    {
        _player.StepTaken -= OnMoveStair;
    }

    public void CreatePoolStairs()
    {
        for (int i = 0; i < _numberStairs; i++)
        {
            var stairPrefab = Game.Data.StairPrefab;
            
            GameObject stair = Instantiate(stairPrefab, _stairContainer.transform);
            _allStairs.Add(stair);
        }
    }
    
    public void BuildStairs()
    {
        _counter = _firstPosition;
        
        for (int i = 0; i < _allStairs.Count; i++)
        {
            _allStairs[i].transform.position = new Vector3(_counter, _counter, 0);
            _counter++;
        }
    }

    private void OnMoveStair()
    {
        _allStairs[0].transform.position = new Vector3(_counter, _counter, 0);
        _counter++;

        GameObject element = _allStairs[0];
        _allStairs.RemoveAt(0);
        _allStairs.Add(element);
    }
}
