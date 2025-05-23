using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrows;
    public Animator animator;
    public float shootInterval;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer>shootInterval){
            animator.SetBool("isShoot",true);
            CreateArrow();
            timer = 0;
        }
        else{
            animator.SetBool("isShoot",false);
        }
    }
    private void CreateArrow(){
        Instantiate(arrows, new Vector3(transform.position.x, transform.position.y,0), transform.rotation);
    }
}
