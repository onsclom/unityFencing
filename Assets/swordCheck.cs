using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordCheck : MonoBehaviour
{
    public GameObject enemy;
    public ParticleSystem particleSys;
    public gameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == enemy)
        {
            gm.collision(transform.parent.gameObject);
            
            particleSys.gameObject.transform.position = other.transform.position;
            var main = particleSys.main;
            main.startColor = other.gameObject.GetComponent<SpriteRenderer>().color;

            particleSys.Play();
            Destroy(other.transform.parent.gameObject);

            

            /*Time.timeScale = .2f;
            Time.fixedDeltaTime = Time.timeScale * .2f;*/
            //Destroy(other.transform.parent.gameObject);
        }
    }
}
