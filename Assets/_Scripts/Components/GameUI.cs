using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : GameElement
{
    [SerializeField] private TMP_Text _counter;
    [SerializeField] private GameObject _endGamePanel;
    
    private PlayerLife _player;
    
    public void Init(GameObject player)
    {
        _player = player.GetComponentInChildren<PlayerLife>();
        _player.PlayerDied += OnShowEndGamePanel;
    }

    private void OnDisable()
    {
        _player.PlayerDied -= OnShowEndGamePanel;
    }

    public void UpdateCounter(int number)
    {
        _counter.text = number.ToString();
    }

    private void OnShowEndGamePanel()
    {
        _endGamePanel.SetActive(true);
    }

}
