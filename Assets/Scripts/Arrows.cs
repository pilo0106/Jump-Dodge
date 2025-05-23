using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows : MonoBehaviour
{
    public float speed;
    public float distance;
    private float startPos_x;
    private float startPos_y;
    private float nowPos_x;
    private float nowPos_y;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        startPos_x = transform.position.x;
        startPos_y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        nowPos_x = transform.position.x;
        nowPos_y = transform.position.y;
        transform.Translate(Vector3.left*Time.deltaTime*speed);
        if(Mathf.Pow(Mathf.Abs(startPos_x) - Mathf.Abs(nowPos_x), 2) + Mathf.Pow(Mathf.Abs(startPos_y) - Mathf.Abs(nowPos_y), 2) >= distance){
            Destroy(this.gameObject);
        };
    }        
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(this.gameObject);
    }
}
