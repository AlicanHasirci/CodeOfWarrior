using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private static class Trigger {
		public const string Attack = "Attack";
		public const string Damage = "Damage";
	}
	
	private Animator _animator;

	private void Awake() {
		_animator = GetComponent<Animator>();
	}
	
	public void Attack() {
		_animator.SetTrigger(Trigger.Attack);
	}
	
	public void Damage() {
		_animator.SetTrigger(Trigger.Damage);
	}
}
