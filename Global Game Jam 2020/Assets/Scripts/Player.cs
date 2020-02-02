using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using UnityEngine.AI;
public class Player : MonoBehaviour {
	private Vector3 displacement;
	private int animations;
	private bool inputSealed;
	private int items;
	[SerializeField] private int health;
	private GameObject spawn;
	private NavMeshAgent nav;
	private Animator anim;
	private static Player instance;
	[SerializeField] private float moveSpeed;
	[SerializeField] private CinemachineVirtualCamera mainCam;
	[SerializeField] private GameObject hitBox;
	public static UnityAction<int> setItemCounter;
	public static UnityAction<int> setHealth;
	public static UnityAction ded;
	private bool hit;
	private bool dead;
	private bool attack;
	private int cmdInput;

	public int Animations { get => animations; set { animations = value; anim.SetInteger("Animations", animations); } }

	public int Items { get => items; set { items = value; if (setItemCounter != null) { setItemCounter(items); } } }

	public int Health { get => health; set { health = Mathf.Clamp(value, 0, 10); Debug.Log(health); if (health == 0) { Dead = true; if (setHealth != null) { setHealth(health); } } } }

	public bool Hit { get => hit; set { hit = value; anim.SetBool("Hit", hit); } }

	public bool Dead { get => dead; set { dead = value; anim.SetBool("Dead", dead);if (ded != null) ded(); } }

	public int CmdInput { get => cmdInput; set { cmdInput = value; anim.SetInteger("CmdInput", cmdInput); } }

	public GameObject HitBox { get => hitBox; set => hitBox = value; }
	public bool Attack { get => attack; set { attack = value; anim.SetBool("Attack", attack); } }

	// Start is called before the first frame update
	public static Player GetPlayer() => instance;
	private void Awake() {
		if (instance != null && instance != this) {
			Destroy(gameObject);
		} else {
			instance = this;
		}
		StoreDoors.goInStore += GoIntoStore;
		EnemyHitBox.hit += OnHit;
		anim = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent>();
	}
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if (!inputSealed) {
			GetInput();

		}

	}
	private void GoIntoStore(Vector3 location, GameObject nextLocation, GameObject item, CinemachineVirtualCamera cam) {
		inputSealed = true;
		nav.enabled = false;
		cam.m_Priority = 12;
		//mainCam.m_LookAt = nextLocation.transform;
		//mainCam.m_Follow = null;
		transform.LookAt(location);
		transform.position = location;//Vector3.MoveTowards(transform.position,loAC)
		Items++;
		StartCoroutine(WaitTilBought(nextLocation, cam));
	}
	private void GetInput() {
		Movement();
		Attacking();
		
	}
	private IEnumerator WaitTilBought(GameObject nextLocation, CinemachineVirtualCamera cam) {
		YieldInstruction wait = new WaitForSeconds(3);
		yield return wait;
		Animations = 10;
		transform.LookAt(nextLocation.transform);
		mainCam.m_LookAt = gameObject.transform;
		mainCam.m_Follow = gameObject.transform;
		transform.position = nextLocation.transform.position;
		StartCoroutine(WaitToSwitch(cam));
	}
	private IEnumerator WaitToSwitch(CinemachineVirtualCamera cam) {
		YieldInstruction wait = new WaitForSeconds(2);
		yield return wait;
		Animations = 0;
		inputSealed = false;
		nav.enabled = true;
		cam.m_Priority = 0;
	}
	private void Movement() {
		float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
		float y = Input.GetAxisRaw("Vertical") * Time.deltaTime;
		displacement = Vector3.Normalize(new Vector3(x, 0, y));
		if (ThreeDCamera.IsActive) {
			displacement = mainCam.GetComponent<ThreeDCamera>().XZOrientation.TransformDirection(displacement);
		}

		MoveIt(x, y);
	}
	private void MoveIt(float x, float y) {
		if (x != 0 || y != 0) {
			Animations = 1;
			Attack = false;
			Move(moveSpeed);
		} else {
			Animations = 0;
		}
	}
	public void Move(float speed) {
		transform.position += displacement * speed * Time.deltaTime;
		if (Vector3.SqrMagnitude(displacement) > 0.01f) {
			transform.forward = displacement;
		}
	}
	private void OnHit() {
		Health--;
		Hit = true;
	}
	private void KO() {
		StartCoroutine(WaitToRespawn());
	}
	private IEnumerator WaitToRespawn() {
		YieldInstruction wait = new WaitForSeconds(3);
		yield return wait;
		transform.position = spawn.transform.position;
	}
	private void Attacking() {

		if (Input.GetButtonDown("Square")) {

			if (Attack == true) {
				CmdInput = 1;
			} else {
				Attack = true;

			}
		}
	}

}
