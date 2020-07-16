using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject block;
    float halfCubeHeight;
    float screenHeightInWorldUnits;
    float screenWidthInWorldUnits;
    int numberOfBlocks;
    public Vector2 secondsBetweenBlockSpawnsMinMax;
    float secondsBetweenSpawns = 1f;
    float nextSpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        halfCubeHeight = transform.localScale.y /2f;
        screenHeightInWorldUnits = Camera.main.orthographicSize;
        screenWidthInWorldUnits = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update() {
        secondsBetweenSpawns = Mathf.Lerp(secondsBetweenBlockSpawnsMinMax.y, secondsBetweenBlockSpawnsMinMax.x, Difficulty.getDifficultyPercent());
        if (Time.time > nextSpawnTime) {
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            //Cube Starting Position
            Vector2 cubeStartPosition = new Vector2(Random.Range(-screenWidthInWorldUnits + halfCubeHeight, screenWidthInWorldUnits-(halfCubeHeight*2)), screenHeightInWorldUnits + (halfCubeHeight*2));
            //Cube Starting Position
            Vector3 cubeStartRotation = new Vector3(0, 0, Random.Range(-20, 20));
            GameObject newBlock = (GameObject)Instantiate(block, cubeStartPosition, Quaternion.Euler(cubeStartRotation));
            float randomCubeSize = Random.Range(0.2f, 2.5f);
            newBlock.transform.localScale = new Vector3(randomCubeSize, randomCubeSize, 0.5f);
            newBlock.transform.parent = transform;
        }
    }

    void createCube(){
        //Cube Starting Position
        Vector2 cubeStartPosition = new Vector2(Random.Range(-screenWidthInWorldUnits + halfCubeHeight, screenWidthInWorldUnits-(halfCubeHeight*2)), screenHeightInWorldUnits + (halfCubeHeight*2));
        //Cube Starting Position
        Vector3 cubeStartRotation = new Vector3(0, 0, Random.Range(-20, 20));
        GameObject newBlock = (GameObject)Instantiate(block, cubeStartPosition, Quaternion.Euler(cubeStartRotation));
        float randomCubeSize = Random.Range(0.2f, 2.5f);
        newBlock.transform.localScale = new Vector3(randomCubeSize, randomCubeSize, 0.5f);
    }
}
