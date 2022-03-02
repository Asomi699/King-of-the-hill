using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepCounter : GameElement
{
    private PlayerMover _player;
    private int _counter;
    private GameUI _gameUi;

    public int CurrentStep => _counter;
    public void Init(GameObject player)
    {
        _player = player.GetComponent<PlayerMover>();
        _player.StepTaken += UpdateCountStep;
        _gameUi = Game.Controller.GameUI;
    }

    private void UpdateCountStep()
    {
        _counter++;
        _gameUi.UpdateCounter(_counter);
    }

    private void OnDisable()
    {
        _player.StepTaken -= UpdateCountStep;
    }
}
