using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : GameElement
{
    [SerializeField] private GameObject _stairPrefab;
    [SerializeField] private GameObject _playerPrefab;

    public GameObject StairPrefab => _stairPrefab;
    public GameObject PlayerPrefab => _playerPrefab;
}
