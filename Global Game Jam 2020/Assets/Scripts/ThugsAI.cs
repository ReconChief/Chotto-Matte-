using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ThugsAI : MonoBehaviour {
	private EnemyAiStates state;
	public enum EnemyAiStates {
		Idle, Attacking, Chasing,Hit,Dead
	}
	private NavMeshAgent nav;
	private Animator anim;
	private bool attacking;
	private bool hit;
	private bool dead;
	private bool walking;
	private bool attack;
	[SerializeField]private GameObject hitBox;
	public EnemyAiStates State { get => state; set { state = value;States(); } }

	private float Distance => Vector3.Distance(transform.position, Player.GetPlayer().transform.position);

	public bool Attacking { get => attacking; set { attacking = value;anim.SetBool("Attacking",attacking); } }
	public bool Hit { get => hit; set { hit = value; anim.SetBool("Hit", hit); } }
	public bool Dead { get => dead; set { dead = value;anim.SetBool("Dead",dead);if (dead) Debug.Log("ded"); } }
	public bool Attack { get => attack; set { attack = value;anim.SetBool("Attack",attack); } }

	private Coroutine attackCoroutine;
	private float attackDelay;

	// Start is called before the first frame update
	private void Awake() {
		anim = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent>();
	}
	private void OnEnable() {
		EnemyHitBoxBehavior[] behaviours = anim.GetBehaviours<EnemyHitBoxBehavior>();
		for (int i = 0; i < behaviours.Length; i++)
			behaviours[i].HitBox = hitBox;
	}
	void Start() {
		StartCoroutine(AttackingCoroutine());
	}

	// Update is called once per frame
	void Update() {
		StateSwitch();
	}
	private void StateSwitch() {

		
			if (State != EnemyAiStates.Chasing && !Dead) {
				walking = false;
				nav.SetDestination(transform.position);
			}
			if (State != EnemyAiStates.Attacking) {
				Attacking = false;

			}
			if (Distance < 1f && !Dead && !Hit) {

				State = EnemyAiStates.Attacking;

			}

			if (Distance > 1.1f && Distance < 6f && !Dead && !Hit) {
			// nav.enabled = true;
				//Debug.Log("fuk");
				State = EnemyAiStates.Chasing;
			}

			if (hit) { State = EnemyAiStates.Hit; }
			if (dead) { State = EnemyAiStates.Dead; }
		


	}
	private void States() {
		switch (State) {
			case EnemyAiStates.Idle:
				Idle();
				break;
			case EnemyAiStates.Attacking:
				Attacking = true;
				break;
			case EnemyAiStates.Chasing:
				Chasing();
				break;

		}
	}
	

	private void Chasing() {
		walking = true;
		if (Distance > 6 && !Dead) {
			//State = EnemyAiStates.ReturnToSpawn;
		}
		nav.SetDestination(Player.GetPlayer().transform.position);
	}
	private void Idle() {
		walking = false;
	}
	private void AttackMode() {

		Attack = true;
		attackCoroutine = StartCoroutine(AttackCoroutine());
		//hitBox.SetActive(true);
	}
	private IEnumerator AttackCoroutine() {
		YieldInstruction wait = new WaitForSeconds(0.2f);
		yield return wait;
		//transform.LookAt( Player.GetPlayer().transform.position);
		Attack = false;
		//hitBox.SetActive(false);

	}
	private IEnumerator AttackingCoroutine() {

		while (isActiveAndEnabled) {
			YieldInstruction wait = new WaitForSeconds(attackDelay);
			yield return wait;
			if (attacking) {
				AttackMode();

			}
		}
	}
}
