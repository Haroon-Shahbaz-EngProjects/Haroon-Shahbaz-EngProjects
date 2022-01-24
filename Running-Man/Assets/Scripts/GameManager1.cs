using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager theScoreManager;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        theScoreManager = FindObjectOfType<ScoreManager>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
       
        theScoreManager.ScoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

       
    }

    public void RestarttGameFromDeath()
    {
        StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.ScoreIncreasing = true;
    }

     public IEnumerator RestartGameCo()
     {

       theScoreManager.ScoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);

         yield return new WaitForSeconds(1.5f);
         FindObjectOfType<SoundEffects>().LevelMusic();
         platformList = FindObjectsOfType<PlatformDestroyer>();
         for (int i = 0; i < platformList.Length; i++)
         {
             platformList[i].gameObject.SetActive(false);
         }

         thePlayer.transform.position = playerStartPoint;
         platformGenerator.position = platformStartPoint;
         thePlayer.gameObject.SetActive(true);

         theScoreManager.scoreCount = 0;
         theScoreManager.ScoreIncreasing = true;

     }
}
