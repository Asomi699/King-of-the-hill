using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : GameElement
{
    [SerializeField] private CameraWork _camera;
    [SerializeField] private GameUI _gameUI;
    [SerializeField] private StepCounter _stepCounter;
    [SerializeField] private ObstacleSpawner _spawner;
    [SerializeField] private StairGenerator _stairGenerator;
    [SerializeField] private InputHandler _inputHandler;
    
    public CameraWork Camera => _camera;
    public GameUI GameUI => _gameUI;
    public StepCounter StepCounter => _stepCounter;
    public ObstacleSpawner ObstacleSpawner => _spawner;
    public StairGenerator StairGenerator => _stairGenerator;
    public InputHandler InputHandler => _inputHandler;
}
