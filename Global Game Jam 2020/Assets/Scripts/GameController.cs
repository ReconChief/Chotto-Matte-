using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class GameController : MonoBehaviour {
	[SerializeField] private int timer;

	public static UnityAction<int> setTimer;

	public int Timer { get => timer; set { timer = Mathf.Clamp(value, 0, 999); if (setTimer != null) { setTimer(timer); }if (timer == 0) { LoadLoseScene(); } } }

	// Start is called before the first frame update
	private void Awake() {
		CindyGate.winner += LoadWinScene;
	}
	void Start() {
		StartCoroutine(TimeBs());
	}

	// Update is called once per frame
	void Update() {

	}
	private IEnumerator TimeBs() {
		YieldInstruction wait = new WaitForSeconds(1);
		while (isActiveAndEnabled) {

			yield return wait;
			Timer--;
		}
	}
	private void LoadWinScene() {
		SceneManager.LoadSceneAsync(2);
	}
	private void LoadLoseScene() {
		SceneManager.LoadSceneAsync(3);
	}
}
