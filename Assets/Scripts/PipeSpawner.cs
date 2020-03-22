using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

	//Global variable
	[SerializeField] private Bird bird;
	[SerializeField] private Pipe pipeUp,pipeDown;
	[SerializeField] private float spawnInterval = 1;
	[SerializeField] public float holeSize = 1f;
	[SerializeField] private float maxMinOffset = 1;
	[SerializeField] private Point point;

    //Variable penampung coroutine yang sedang berjalan
    private Coroutine CR_Spawn;

    private void Start()
    {
        //Memulai Spawning
        StartSpawn();
    }

    void StartSpawn()
    {
        //Menjalankan Fungsi Coroutine IeSpawn()
        if (CR_Spawn == null)
        {
        	CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
    	//Menghentikan Coroutine IeSpawn jika sebelumnya sudah dijalankan
    	if (CR_Spawn != null)
    	{
    		StopCoroutine(CR_Spawn);
    	}
    }

    void SpawnPipe()
    {
    	//Menduplikasi game object pipeUp dan menempatkan posisinya sama dengan game object ini tetapi dirotasi 180 derajat
    	Pipe newPipeUp = Instantiate(pipeUp,transform.position,Quaternion.Euler(0,0,180));

    	//Mengaktifkan game object newPipeUp
    	newPipeUp.gameObject.SetActive(true);

    	//menduplikasi game object pipeDown dan menempatkan sama dengan game object
    	Pipe newPipeDown = Instantiate(pipeDown,transform.position,Quaternion.identity);

    	//mengaktifkan game object newPipeUp
    	newPipeDown.gameObject.SetActive(true);

    	//Menempatkan posisi dari pipa yang sudah terbentuk agar memiliki lubang di tengahnya
    	newPipeUp.transform.position += Vector3.up * (holeSize / 2);
    	newPipeDown.transform.position += Vector3.down * (holeSize / 2);

    	//Menempatkan posisi pipa yang telah dibentuk agar posisinya menyesuaikan dengan fungsi sin
    	float y = maxMinOffset * Mathf.Sin(Time.time);
    	newPipeUp.transform.position += Vector3.up * y;
    	newPipeDown.transform.position += Vector3.up * y;

    	Point newPoint = Instantiate(point, transform.position,Quaternion.identity);
    	newPoint.gameObject.SetActive(true);
    	newPoint.SetSize(holeSize);
    	newPoint.transform.position += Vector3.up * y;
    }

    IEnumerator IeSpawn()
    {
    	while (true)
    	{
    		//Jika burung mati maka menghentikan pembuatan Pipa Baru
    		if (bird.IsDead())
    		{
    			StopSpawn();
    		}

    		//Membuat Pipa Baru
    		SpawnPipe();

    		//Menunggu beberapa detik sesuai dengan spawn interval
    		yield return new WaitForSeconds(spawnInterval);
    	}
    }
}
