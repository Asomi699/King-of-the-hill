using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]
public class PlayerLife : GameElement
{
   [SerializeField] private ParticleSystem _crashEffect;
   
   private MeshRenderer _meshRenderer;
   private bool _isAlive = true;
   
   public event UnityAction PlayerDied;

   private void Start()
   {
      _meshRenderer = GetComponent<MeshRenderer>();
   }
   
   private void OnTriggerEnter(Collider other)
   {
      if (other.TryGetComponent(out Obstacle obstacle))
      {
         if (_isAlive)
         {
            _isAlive = false;
            _meshRenderer.enabled = false;
            _crashEffect.Play();
            PlayerDied?.Invoke();
         }
      }
   }
}
