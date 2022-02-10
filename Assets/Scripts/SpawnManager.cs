using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject cactusPrefab;
    public float cactusCount;
    public GameObject birdPrefab;
    public float birdCount;
    private float max = 980;
    private float min = 970;
    private Cactus[] cactusList;
    private Bird[] birdList;
    private bool accounted = false;

    public GameOverScreen GameOverScreen;
    int score = 0;
    float testTimer = 30;
    public ScoreText ScoreText;

    public DinoController DinoController;

    public void GameOver(){
        GameOverScreen.Setup(score);
        ScoreText.End();
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; i++){
            Instantiate(cactusPrefab, GenerateSpawn(min, max,0), cactusPrefab.transform.rotation);
            Instantiate(birdPrefab, GenerateSpawn(min, max,8.5f), birdPrefab.transform.rotation);
            min -= 20;
            max -= 20;
        }
        
    }

    private Vector3 GenerateSpawn(float min, float max, float y){
        return new Vector3(Random.Range(min,max), y, 500);
    }
    // Update is called once per frame
    void Update()
    {
        testTimer -= Time.deltaTime;

        ScoreText.Setup(score);

        cactusList = FindObjectsOfType<Cactus>();
        cactusCount = cactusList.Length;
        birdList = FindObjectsOfType<Bird>();
        birdCount = birdList.Length;
        float[] arr = null;
        float[] brr = null;

        if(cactusCount >= 6){
            arr = new float[] {cactusList[0].transform.position.x, cactusList[1].transform.position.x, 
                cactusList[2].transform.position.x, cactusList[3].transform.position.x, cactusList[4].transform.position.x, cactusList[5].transform.position.x};
        }

        if(birdCount >= 6){
            brr = new float[] {birdList[0].transform.position.x, birdList[1].transform.position.x, 
                birdList[2].transform.position.x, birdList[3].transform.position.x, birdList[4].transform.position.x, birdList[5].transform.position.x};
        }
        

        if(cactusCount >= 6 && arr.Max() > 992 && !accounted){
            score++;
            accounted = true;
        }
        
        if (DinoController.over){
            GameOver();
            for(int i = 0; i < cactusCount; i++){
                Destroy(cactusList[i]);
            }
            for(int i = 0; i < birdCount; i++){
                Destroy(birdList[i]);
            }
        }
        
        else if(cactusCount < 6 || birdCount < 6){
            if (cactusCount < 6){
                float[] arr2 = {cactusList[0].transform.position.x, cactusList[1].transform.position.x, 
                cactusList[2].transform.position.x, cactusList[3].transform.position.x, cactusList[4].transform.position.x};
                max = arr2.Min();
                accounted = false;
                Instantiate(cactusPrefab, GenerateSpawn(max-40, max-20, 0), cactusPrefab.transform.rotation);
            }
            if (birdCount < 6){
                float[] brr2 = {birdList[0].transform.position.x, birdList[1].transform.position.x, 
                birdList[2].transform.position.x, birdList[3].transform.position.x, birdList[4].transform.position.x};
                max = brr2.Min();
                Instantiate(birdPrefab, GenerateSpawn(max-40, max-20,8.5f), birdPrefab.transform.rotation);
            }
            
        }
    }
}
