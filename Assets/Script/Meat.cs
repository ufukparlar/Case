using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meat : MonoBehaviour
{
    //private float timer = 0f;
    
    public int skor = 0;
    private AudioSource audioSource;
    public GameObject tebriklerPnl;
    Grass grass;
    MeatAndGrass mag;
    ShipMovement shp;


    void Start()
    {
        grass= GameObject.FindObjectOfType<Grass>();//burada yine di�er scriptlerden skor eri�meye �al��t�m fakat olmad�.
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = true;
        mag= GameObject.FindObjectOfType<MeatAndGrass>();
        shp = GameObject.FindObjectOfType<ShipMovement>();

    }


    



    void Update()
    {
       
    }

    

    // Kameradan ��kt��� anda yap�lacak �eyler
    void OnBecameInvisible()
    {
        
        audioSource.enabled = true;
        //PlaySplashSound();


        Destroy(gameObject);
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Belirtilen tagda objeyle �arp���nca
        if (collision.gameObject.CompareTag("Carnivore_Ship"))
        {
            
            
            Destroy(gameObject);
            PlaySplashSound();//ses �alm�yor.
            skor += skor;
            shp.totalScore += shp.totalScore;
            audioSource.enabled = true;
        }
        else if (collision.gameObject.CompareTag("Herbivore_Ship"))
        {
            
            Destroy(gameObject);
            audioSource.enabled = true;
            //audiolar� oynatm�yor burada normalde yanl�� yere att���n� belirten bir ses olmal�.
        }
        else if (collision.gameObject.CompareTag("Omnivore_Ship"))
        {
            
            Destroy(gameObject);
            audioSource.enabled = true;
            //audiolar� oynatm�yor burada normalde yanl�� yere att���n� belirten bir ses olmal�.
        }
        else if (collision.gameObject.CompareTag("OmnivoreCatapult"))
        {
            
            Destroy(gameObject);
            audioSource.enabled = true;
            //audiolar� oynatm�yor burada normalde yanl�� yere att���n� belirten bir ses olmal�.
        }

        else if (collision.gameObject.CompareTag("HerbivoreCatapult"))
        {
            
            Destroy(gameObject);
            audioSource.enabled = true;
            //audiolar� oynatm�yor burada normalde yanl�� yere att���n� belirten bir ses olmal�.
        }
    }
    private void PlaySplashSound()
    {
        if (audioSource != null)
        {
            audioSource.enabled = true;
            audioSource.Play();
        }
    }



}


