using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWork : GameElement
{
   [SerializeField] private float _speed;
   [SerializeField] private Vector3 _offset;
   
   private PlayerMover _player;
   private int _position;
   private Vector3 _newPosition;
   

   public void Init(GameObject player)
   {
      _player = player.GetComponent<PlayerMover>();
      _player.StepTaken += OnCameraPositionUpdate;
      _newPosition = transform.position;
   }

   private void OnDisable()
   {
      _player.StepTaken -= OnCameraPositionUpdate;
   }

   private void Update()
   {
      transform.position = Vector3.Lerp(transform.position, _newPosition, _speed * Time.deltaTime);
   }

   private void OnCameraPositionUpdate()
   {
      _position++;
      _newPosition = new Vector3(_position, _position, 0) + _offset;
   }
}
