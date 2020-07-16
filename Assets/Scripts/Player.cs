using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public event System.Action OnPlayerDeath;
    float speed = 7f;
    float start = -9.5f;
    float end = 9.5f;
    float screenHaldWidthInWorldUnits;

    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerSize = transform.localScale.x /2f;
        screenHaldWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerSize;
    }

    // Update is called once per frame
    void Update()
    {
         Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
         Vector2 playerDirection = input.normalized;
         Vector2 velocity = playerDirection * speed;
         transform.Translate(velocity * Time.deltaTime);
         if (transform.position.x < -screenHaldWidthInWorldUnits) {
             transform.position = new Vector2(screenHaldWidthInWorldUnits, transform.position.y);
         };
         if (transform.position.x > screenHaldWidthInWorldUnits) {
             transform.position = new Vector2(-screenHaldWidthInWorldUnits, transform.position.y);
         };
    }

    private void OnTriggerEnter(Collider triggerCollider) {
        print(triggerCollider.tag);
        if (OnPlayerDeath != null) {
            OnPlayerDeath();
        }
        Destroy(gameObject);
    }

}
