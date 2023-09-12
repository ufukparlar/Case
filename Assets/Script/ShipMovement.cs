using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.ShaderData;

public class ShipMovement : MonoBehaviour
{
    public Transform startPoint; // Geminin çýkýþ noktasý
    public Transform endPoint;   // Geminin varýþ noktasý
    public GameObject[] shipPrefabs; // Üretilecek olan gemi prefablarý
    public float movementSpeed = 5.0f; // Geminin hýzý
    public float timeBetweenShips = 2.0f; // gemilerin üretilme aralýðý
    public GameObject basaramadinPnl;
    public GameObject tebriklerPnl;

    private GameObject currentShip;
    private int shipIndex = 0;
    private float timer = 0.0f;
    private int shipsMoved = 0;
    private int maxShipsToMove = 3; 
    private bool canSpawnNewShip = true; 
    Grass grass;
    MeatAndGrass mag;
    Meat meat;
    public int totalScore = 0;

    void Start()
    {
        SpawnShip();
    }

    void Update()
    {
        MoveShip();
        CheckReplacement();
        if (totalScore == 3)
        {
            tebriklerPnl.SetActive(true);//Burada baþta diðer scriptte denediðim iþlemi tekrar denedim fakat scriptlerden skorlarý alamadým ve paneli oluþturamadým.
        }
        
    }

    void SpawnShip()
    {
        if (canSpawnNewShip)
        {
            
            currentShip = Instantiate(shipPrefabs[shipIndex], startPoint.position, Quaternion.identity);
        }
    }

    void MoveShip()
    {
        if (currentShip != null)
        {
            // Geminin hareketi
            currentShip.transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);

            // Geminin varýþ kontrolü
            if (currentShip.transform.position.x >= endPoint.position.x)
            {
                
                Destroy(currentShip);

                
                shipsMoved++;

                if (shipsMoved >= maxShipsToMove)
                {
                    //burada tekrar panelleri denedim fakat yine sonuç alamadým
                    /*if (meat.skor + grass.skor + mag.skor == 3)
                    {

                        tebriklerPnl.SetActive(true);
                    }
                    else
                    {
                        basaramadinPnl.SetActive(true);
                    }*/

                    
                    canSpawnNewShip = false;
                }
                else
                {
                    
                    timer = 0.0f;

                    
                    SpawnNextShip();
                }
            }
        }
    }

    void CheckReplacement()
    {
       
        timer += Time.deltaTime;

        
        if (timer >= timeBetweenShips && currentShip == null && canSpawnNewShip)
        {
            SpawnNextShip();
        }
    }

    void SpawnNextShip()
    {
        
        shipIndex = (shipIndex + 1) % shipPrefabs.Length;

        
        SpawnShip();
    }
}