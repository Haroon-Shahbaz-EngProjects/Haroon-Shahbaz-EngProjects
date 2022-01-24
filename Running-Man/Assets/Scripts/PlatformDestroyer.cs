using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{

    public GameObject PlatformDestrctionPoint;

    // Start is called before the first frame update
    void Start()
    {
        PlatformDestrctionPoint = GameObject.Find("PlatformDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < PlatformDestrctionPoint.transform.position.x)
        {
            // Destroy(gameObject);

            gameObject.SetActive(false);
        }
    }

}
