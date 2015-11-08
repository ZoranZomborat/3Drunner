using UnityEngine;
using System.Collections;

public class SpikeGenerator : MonoBehaviour {
	
	public ObjectPooler SpikePool;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	private void GenerateSpikes(Vector3 startPosition,int index)
	{		
		GameObject spike = SpikePool.GetPooledObject ();
		spike.transform.position = new Vector3(startPosition.x + index,startPosition.y , startPosition.z);
		spike.SetActive (true);
	}
	
	public void SpawnSpikes(Vector3 startPosition,int numberOfSpikes)
	{
		for (int i=0; i<numberOfSpikes; i++) {
			GenerateSpikes(startPosition,i);
		}
	}
}
