using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject cactusPrefab;
    public float cactusCount;
    private float max = 980;
    private float min = 970;
    private Cactus[] cactusList;
    private bool accounted = false;

    public GameOverScreen GameOverScreen;
    int score = 0;
    float testTimer = 30;
    public ScoreText ScoreText;

    public void GameOver(){
        GameOverScreen.Setup(score);
        ScoreText.End();
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; i++){
            Instantiate(cactusPrefab, GenerateSpawn(min, max), cactusPrefab.transform.rotation);
            min -= 20;
            max -= 20;
        }
        
    }

    private Vector3 GenerateSpawn(float min, float max){
        return new Vector3(Random.Range(min,max), 0, 500);
    }
    // Update is called once per frame
    void Update()
    {
        testTimer -= Time.deltaTime;

        ScoreText.Setup(score);

        cactusList = FindObjectsOfType<Cactus>();
        cactusCount = cactusList.Length;
        float[] arr = null;

        if(cactusCount >= 6){
            arr = new float[] {cactusList[0].transform.position.x, cactusList[1].transform.position.x, 
                cactusList[2].transform.position.x, cactusList[3].transform.position.x, cactusList[4].transform.position.x, cactusList[5].transform.position.x};
        }
        

        if(cactusCount >= 6 && arr.Max() > 992 && !accounted){
            score++;
            accounted = true;
        }
        
        if (testTimer <= 0){
            GameOver();
            for(int i = 0; i < cactusCount; i++){
                Destroy(cactusList[i]);
            }
        }
        
        else if(cactusCount < 6){
            float[] arr2 = {cactusList[0].transform.position.x, cactusList[1].transform.position.x, 
                cactusList[2].transform.position.x, cactusList[3].transform.position.x, cactusList[4].transform.position.x};
            max = arr2.Min();
            accounted = false;
            Instantiate(cactusPrefab, GenerateSpawn(max-40, max-20), cactusPrefab.transform.rotation);
        }
    }
}
