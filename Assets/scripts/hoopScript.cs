using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hoopScript : MonoBehaviour {

	public Text myPunkte;
	public Text KiPunkte;
	public ballScript ball;
	public Collider2 collider2;
	ParticleSystem particleSystem;
	private float boolTime = 0;
	private int meinePunkte;
	private int kiPunkte;

	// Use this for initialization
	void Start () {
		meinePunkte = 0;
		kiPunkte = 0;
		particleSystem = GetComponent<ParticleSystem>();
		particleSystem.Stop ();
	}

	// Update is called once per frame
	void Update () {
		if (particleSystem.isPlaying && Time.time - boolTime > 3f )
			particleSystem.Stop ();
		
	}

	void OnTriggerEnter(Collider other) {
		if (collider2.getColliderKont()) {
			if (ball.isSpielerDran ()) {
				meinePunkte++;
				myPunkte.text = "Meine Punkte: " + meinePunkte;
			} else {
				kiPunkte++;
				KiPunkte.text = "Computer Punkte: " + kiPunkte;
			}
			particleSystem.Play ();
			boolTime = Time.time;
			collider2.setColliderKont ();
		}

	}
		
}