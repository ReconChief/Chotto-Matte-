using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ThugsAI : MonoBehaviour {
	private EnemyAiStates state;
	public enum EnemyAiStates {
		Idle, Attacking, Chasing
	}
	private NavMeshAgent nav;
	private bool attacking;
	private bool hit;
	private bool dead;
	private bool walking;

	public EnemyAiStates State { get => state; set => state = value; }

	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
	private void StateSwitch() {

		
			if (State != EnemyAiStates.Chasing && !dead) {
				walking = false;
				nav.SetDestination(transform.position);
			}
			if (State != EnemyAiStates.Attacking) {
				attacking = false;

			}
			if (Distance < 1f && !dead && !hit) {

				State = EnemyAiStates.Attacking;

			}

			if (Distance > 1.1f && Distance < 6f && !dead && !hit) {
			// nav.enabled = true;
				//Debug.Log("fuk");
				State = EnemyAiStates.Chasing;
			}

			//if (hit) { State = EnemyAiStates.Hit; }
			//if (dead) { State = EnemyAiStates.Dead; }
		


	}
	private void States() {
		switch (State) {
			case EnemyAiStates.Idle:
				Idle();
				break;
			case EnemyAiStates.Attacking:
				attacking = true;
				break;
			case EnemyAiStates.Chasing:
				Chasing();
				break;

		}
	}
	private float Distance => Vector3.Distance(transform.position,Player.GetPlayer().transform.position);
	private void Chasing() {
		walking = true;
		if (Distance > 6 && !dead) {
			//State = EnemyAiStates.ReturnToSpawn;
		}
		nav.SetDestination(Player.GetPlayer().transform.position);
	}
	private void Idle() {
		walking = false;
	}
}
