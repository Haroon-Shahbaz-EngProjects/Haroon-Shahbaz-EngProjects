using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MealGen : MonoBehaviour
{

    public ObjectPooler MealPool;

    public float distanceBetweenCoins;
    // Start is called before the first frame update
    public void SpwanCoins(Vector3 startPosition)
    {
        GameObject meal1 = MealPool.GetPooledObject();
        meal1.transform.position = startPosition;
        meal1.SetActive(true);

        GameObject meal2 = MealPool.GetPooledObject();
        meal2.transform.position = new Vector3(startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
        meal2.SetActive(true);

        GameObject meal3 = MealPool.GetPooledObject();
        meal3.transform.position = new Vector3(startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
        meal3.SetActive(true);

    }
}

