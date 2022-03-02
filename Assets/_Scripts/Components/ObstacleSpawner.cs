using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : GameElement
{
   [SerializeField] private Vector2 _spawnDelay = new Vector2(2, 5);
   [SerializeField] private List<GameObject> _obstaclePrefabs;
   [SerializeField] private int _numberObstacles = 10;
   
   private List<GameObject> _allObstacles = new List<GameObject>();

   private PlayerLife _player;
   private Coroutine _spawn;
   

   public void Init(GameObject player)
   {
      _player = player.GetComponentInChildren<PlayerLife>();
      _player.PlayerDied += OnDisableSpawning;
      
      CreateObstacles();
      
      _spawn = StartCoroutine(BeginSpawn());
   }

   private void OnDisable()
   {
      _player.PlayerDied -= OnDisableSpawning;
   }

   private void CreateObstacles()
   {
      for (int i = 0; i < _numberObstacles; i++)
      {
         GameObject obstacleTemplate = _obstaclePrefabs[Random.Range(0, _obstaclePrefabs.Count)];
         GameObject obstacle = Instantiate(obstacleTemplate, transform.position, Quaternion.identity);
         obstacle.transform.SetParent(this.transform);
         
         obstacle.SetActive(false);
         _allObstacles.Add(obstacle);
      }
   }

   private IEnumerator BeginSpawn()
   {
      while (true)
      {
         float delay = Random.Range(_spawnDelay.x, _spawnDelay.y);
         yield return new WaitForSeconds(delay);

         var instance = _allObstacles.FirstOrDefault(p => p.activeSelf == false);
         
         if(instance != null)
            instance.SetActive(true);
      }
   }

   private void OnDisableSpawning()
   {
      StopCoroutine(_spawn);
   }
}
