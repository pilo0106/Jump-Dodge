using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform Target;

    private void Awake()
    {
        Target=GameObject.FindGameObjectWithTag("Player").transform;
    }

    void LateUpdate()
    {
        Vector3 cameraPos=transform.position;
        cameraPos.x=Mathf.Max(cameraPos.x, Target.position.x);
        transform.position=cameraPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
