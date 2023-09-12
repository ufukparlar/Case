using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : MonoBehaviour
{
    public GameObject objectPrefab; 
    public Transform objectSpawnPoint; 
    public float launchAngle = 45f; //atma a��s�
    public float launchForce = 10f; //atma h�z�
    public float nextThrowTime = 0f;
    public float cooldownTime = 1.0f; //at�� zaman aral���
    private bool canThrow = true; // bekleme s�resinde oldu�unda kullanmak i�in

    void Update()
    {
        // objeye dokunma var m� kontrol�
        if (canThrow && (Input.touchCount > 0 || Input.GetMouseButtonDown(0)))
        {
            //Dokunman�n nerede yap�ld���n� bulma
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickPosition2D = new Vector2(clickPosition.x, clickPosition.y);

            // Dokunma i�lemi manc�n��a m� yap�ld� kontrol�
            if (GetComponent<Collider2D>().OverlapPoint(clickPosition2D))
            {
                
                Vector2 launchDirection = Quaternion.Euler(0, 0, launchAngle) * Vector2.right;

                // f�rlatma noktas�nda nesneyi yaratma
                GameObject newApple = Instantiate(objectPrefab, objectSpawnPoint.position, Quaternion.identity);

                
                Rigidbody2D rb = newApple.GetComponent<Rigidbody2D>();

                // f�rlatma i�i
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





