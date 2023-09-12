using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public GameObject objectPrefab; 
    public Transform objectSpawnPoint; 
    public float launchAngle = 45f; //atma açýsý
    public float launchForce = 10f; //atma hýzý
    public float nextThrowTime = 0f;
    public float cooldownTime = 1.0f; //atýþ zaman aralýðý
    private bool canThrow = true; // bekleme süresinde olduðunda kullanmak için

    void Update()
    {
        // objeye dokunma var mý kontrolü
        if (canThrow && (Input.touchCount > 0 || Input.GetMouseButtonDown(0)))
        {
            //Dokunmanýn nerede yapýldýðýný bulma
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickPosition2D = new Vector2(clickPosition.x, clickPosition.y);

            // Dokunma iþlemi mancýnýða mý yapýldý kontrolü
            if (GetComponent<Collider2D>().OverlapPoint(clickPosition2D))
            {
                
                Vector2 launchDirection = Quaternion.Euler(0, 0, launchAngle) * Vector2.right;

                // fýrlatma noktasýnda nesneyi yaratma
                GameObject newApple = Instantiate(objectPrefab, objectSpawnPoint.position, Quaternion.identity);

                
                Rigidbody2D rb = newApple.GetComponent<Rigidbody2D>();

                // fýrlatma iþi
                rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);

                
                canThrow = false;

                
                nextThrowTime = Time.time + cooldownTime;

                
                StartCoroutine(EnableThrowingAfterCooldown());
            }
        }
    }

    IEnumerator EnableThrowingAfterCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        canThrow = true;
    }
}





