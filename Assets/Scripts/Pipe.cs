using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

	//Global variable
	[SerializeField] private Bird bird;
	[SerializeField] private float speed = 1;
	
    // Dipanggil setiap frame
    private void Update()
    {
        //Melakukan pengecekan jika burung belum mati
        if (!bird.IsDead())
        {
        	//Membuat pipa bergerak kesebelah kiri dengan kecepatan tertentu
        	transform.Translate(Vector3.left * speed * Time.deltaTime,Space.World);
        }
    }

    //Membuat Burung mati ketika bersentuhan dan menjatuhkan ke ground jika mengenai di atas collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
    	Bird bird = collision.gameObject.GetComponent<Bird>();

    	//Pengecekan Null value
    	if (bird)
    	{
    		//Mendapatkan komponen collider pada game object
    		Collider2D collider = GetComponent<Collider2D>();

    		//Melakukan penegcekan Null variable atau tidak
    		if (collider)
    		{
    			//Menonaktifkan collider
    			collider.enabled = false;
    		}
    		//Burung Mati
    		bird.Dead();
    	}
    }
}
