using UnityEngine;
using Entities;
using System.Collections;

public class PlatformGeneration : MonoBehaviour {
	
	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBeetween;
	private float distanceBetweenMin=2;
	private float distanceBetweenMax=4;
	
	public float[] platformWidths;
	private int platformSelector;
	
	private float minHeight;
	private float maxHeight;
	private float heightChange;
	public GameObject maxHeightPoint;
	public float maxHeightChange;
	
	public ObjectPooler[] theObjectPools;
	private CoinGenerator theCoinGenerator;
	private SpikeGenerator theSpikeGenerator;
	
	public float CoinTreshold;
	public float SpikeTreshold;
	
	// Use this for initialization
	void Start () {
		minHeight = transform.position.y;
		heightChange= transform.position.y;
		maxHeight = maxHeightPoint.transform.position.y;
		maxHeightChange = 2.5f;
		
		platformWidths = new float[theObjectPools.Length];
		for (int i=0; i<theObjectPools.Length; i++) {
			platformWidths[i]=theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}
		
		theCoinGenerator = FindObjectOfType<CoinGenerator> ();
		theSpikeGenerator = FindObjectOfType<SpikeGenerator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (this.transform.position.x < generationPoint.position.x) {
			distanceBeetween=Random.Range(distanceBetweenMin,distanceBetweenMax);
			
			platformSelector=Random.Range(0,theObjectPools.Length);
			heightChange=transform.position.y+Random.Range(maxHeightChange,-maxHeightChange);
			if(heightChange<minHeight||heightChange>maxHeight)
				heightChange=transform.position.y;
			
			transform.position = new Vector3 (transform.position.x + distanceBeetween + platformWidths[platformSelector]/2
			                                  ,heightChange, transform.position.z);
			
			
			GameObject newPlatform=theObjectPools[platformSelector].GetPooledObject();
			
			
			if(Random.Range(0f,100f)<=CoinTreshold){
				theCoinGenerator.SpawnCoins(new Vector3(transform.position.x,transform.position.y+1f,transform.position.z));
			}
			
			if(Random.Range(0f,100f)<=SpikeTreshold){
				int numberOfSpikes=(int)Mathf.Round(Random.Range(1f,Mathf.Min(platformWidths[platformSelector]-4,3)));
				var delay=Mathf.Round(Random.Range(-1.9f,1.9f));
				theSpikeGenerator.SpawnSpikes(new Vector3(transform.position.x+delay,transform.position.y+0.5f,transform.position.z),numberOfSpikes);
			}
			
			newPlatform.transform.position=this.transform.position;
			newPlatform.transform.rotation=this.transform.rotation;
			newPlatform.SetActive(true);
			
			transform.position = new Vector3 (transform.position.x  + platformWidths[platformSelector]/2
			                                  , transform.position.y, transform.position.z);
		} 
	}
}
