using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour
{
    public Vector2 speedMinMax;
    float speed;
    float screenHeightInWorldUnits;
    float halfCubeHeight;

    // Start is called before the first frame update
    void Start()
    {
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.getDifficultyPercent()); 
        halfCubeHeight = transform.localScale.y /2f;
        screenHeightInWorldUnits = Camera.main.orthographicSize;
        print(Difficulty.getDifficultyPercent());
    }

    // Update is called once per frame
    void Update()
    {
        // Vector2 cubeFallDirection = new Vector2(transform.rotation)
        //transform.rotation
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -screenHeightInWorldUnits-halfCubeHeight) {
            Destroy(gameObject);
        }
    }
}
