using UnityEngine;
using System.Collections;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {
		this.platformDestructionPoint=GameObject.Find("PlatformDestructionPoint");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < this.platformDestructionPoint.transform.position.x) {
			gameObject.SetActive(false);
		}
	}
}
