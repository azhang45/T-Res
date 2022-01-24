using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject cactusPrefab;
    public float cactusCount;
    private float max = 980;
    private float min = 970;
    private Cactus[] cactusList;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 6; i++){
            Instantiate(cactusPrefab, GenerateSpawn(min, max), cactusPrefab.transform.rotation);
            min -= 15;
            max -= 15;
        }
        
    }

    private Vector3 GenerateSpawn(float min, float max){
        return new Vector3(Random.Range(min,max), 0, 500);
    }
    // Update is called once per frame
    void Update()
    {
        cactusList = FindObjectsOfType<Cactus>();
        cactusCount = cactusList.Length;
        if(cactusCount < 6){
            max = cactusList[(int)cactusCount-1].transform.position.x;
            Instantiate(cactusPrefab, GenerateSpawn(min, max-20), cactusPrefab.transform.rotation);
        }
    }
}
