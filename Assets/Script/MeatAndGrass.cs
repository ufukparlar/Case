using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatAndGrass : MonoBehaviour
{
    //private float timer = 0f;
    
    
    public int skor = 0;
    ShipMovement shp;

    void Start()
    {
        shp = GameObject.FindObjectOfType<ShipMovement>();
    }

    void Update()
    {
        
    }

    
   

    
    void OnBecameInvisible()
    {
        
        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Omnivore_Ship"))
        {
            
            Destroy(gameObject);
            shp.totalScore += shp.totalScore;
        }
        else if (collision.gameObject.CompareTag("Herbivore_Ship")){
            Destroy(gameObject);    
        }
        else if (collision.gameObject.CompareTag("Carnivore_Ship")){
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("CarnivoreCatapult")){
            Destroy(gameObject);
        }
        
        else if (collision.gameObject.CompareTag("HerbivoreCatapult")){
            Destroy(gameObject);
        }

    }
}