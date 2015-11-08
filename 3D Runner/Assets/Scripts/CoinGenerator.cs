using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {
	
	public float distanceBetweenCoins;
	private float heightOfCoins;
	public float maxHeightOfCoins;
	public float minHeighOfCoins;
	private float numberOfCoins;
	private float firstCoinPosition;
	
	public ObjectPooler coinPool;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void GenerateCoins (Vector3 startPosition,int index)
	{
		heightOfCoins = Random.Range (minHeighOfCoins,maxHeightOfCoins);
		
		GameObject coin = coinPool.GetPooledObject ();
		coin.transform.position = new Vector3(startPosition.x-firstCoinPosition,startPosition.y+heightOfCoins,startPosition.z);
		coin.SetActive (true);
		firstCoinPosition -= 1f;
	}
	
	public void SpawnCoins(Vector3 startPosition)
	{
		numberOfCoins = Random.Range (2,6);
		numberOfCoins = Mathf.Round(numberOfCoins);
		firstCoinPosition = numberOfCoins/2;
		for (int i=0; i<numberOfCoins; i++) 
			GenerateCoins (startPosition,i);
		
	}
	
}
