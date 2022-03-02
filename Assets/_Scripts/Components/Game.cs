using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameElement: MonoBehaviour
{
    public Game Game { get { return GameObject.FindObjectOfType<Game>(); }}
}
public class Game : MonoBehaviour
{
    [SerializeField] private Data _data;
    [SerializeField] private Controller _controller;
    public Data Data => _data;
    public Controller Controller => _controller;
    
    
    private void Start()
    {
        var playerPrefab = Data.PlayerPrefab;
        var player = Instantiate(playerPrefab, transform.position, Quaternion.identity);

        var inputHandler = Controller.InputHandler;
        player.GetComponent<PlayerMover>().Init(inputHandler);
        
        inputHandler.Init(player);

        var stairGenerator = Controller.StairGenerator;
        stairGenerator.Init(player);

        CameraWork camera = Controller.Camera;
        camera.Init(player);

        StepCounter stepCounter = Controller.StepCounter;
        stepCounter.Init(player);

        var obstacleSpawner = Controller.ObstacleSpawner;
        obstacleSpawner.Init(player);

        var gameUi = Controller.GameUI;
        gameUi.Init(player);
    }
}
