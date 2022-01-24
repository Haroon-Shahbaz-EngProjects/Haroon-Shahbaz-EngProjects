using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{


    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;


    public ObjectPooler[] theObjectPools;


    private float minHeight;
    private Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    //public CoinGenerator theCoinGenerator;

    public ObjectPooler coinPool;

    public float distanceBetweenCoins;

    public float randomCoinThreshold;

    public float randomSpikeThreshold;
    public ObjectPooler spikePool;



    // Start is called before the first frame update
    void Start()
    {
        // platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x; 

        platformWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        //theCoinGenerator = FindObjectOfType<CoinGenerator>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);


            platformSelector = Random.Range(0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }


            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            //Instantiate(thePlatforms[platformSelector], transform.position, transform.rotation);

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            if(Random.Range(0f, 100f) < randomCoinThreshold)
            {
                SpawnCoins(new Vector3(newPlatform.transform.position.x, newPlatform.transform.position.y + 1.25f, newPlatform.transform.position.z));
            }

            if (Random.Range(0f, 100f) < randomSpikeThreshold)
            {
                GameObject newSpike = spikePool.GetPooledObject();

                float spikeXPosition = Random.Range(-platformWidths[platformSelector] / 2 +1f, platformWidths[platformSelector] / 2 - 1f);

                Vector3 spikePosition = new Vector3(spikeXPosition, 0.5f, 0f);

                newSpike.transform.position = transform.position + spikePosition;
                newSpike.transform.rotation = transform.rotation;
                newSpike.SetActive(true);
            }

                transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
        }
    }

    public void SpawnCoins(Vector3 startPosition)
    {

        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = startPosition;
        coin1.SetActive(true);

    }

}
