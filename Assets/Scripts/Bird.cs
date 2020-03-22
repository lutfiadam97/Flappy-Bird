﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class Bird : MonoBehaviour
{
	//Global Variables
	[SerializeField] private float upForce = 100;
	[SerializeField] private bool isDead;
	[SerializeField] private int score;
	[SerializeField] private Text scoreText;
	[SerializeField] private UnityEvent OnJump,OnDead;
	[SerializeField] private UnityEvent OnAddPoint;

	private Rigidbody2D rigidBody2d;
	private Animator animator;

	//init variable
    // Start is called before the first frame update

    void Start()
    {
        //Mendapatkan komponen ketika game baru berjalan
        rigidBody2d = GetComponent<Rigidbody2D>();

        //Mendapatkan komponen animator pada game object
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Melakukan pengecekan jika belum mati dan klik kiri pada mouse
        if (!isDead && Input.GetMouseButtonDown(0))
        {
        	//Burung meloncat
        	Jump();
        }
    }

    //Fungsi untuk menegcek sudah mati apa belum
    public bool IsDead()
    {
    	return isDead;
    }

    //Membuat Burung Mati
    public void Dead()
    {
    	//Pengecekan jka belum mati dan value OnDead tidak sama sekali dengan Null
    	if (!isDead && OnDead !=null)
    	{
    		//Memanggil semua event pada OnDead
    		OnDead.Invoke();
    	}

    	//Mengeset variable Dead menjadi True
    	isDead= true;

    }

    void Jump()
    {
    	//Mengecek rigidbody null atau tidak
    	if (rigidBody2d)
    	{
    		//menghentikan kecepatan burung ketika jatuh
    		rigidBody2d.velocity = Vector2.zero;

    		//Menambahkan gaya ke arah sumbu y agar burung meloncat
    		rigidBody2d.AddForce(new Vector2(0, upForce));
    	}

    	//Pengecekan Null variable
    	if (OnJump != null)
    	{
    		//Mencajalankan semua event OnJump event
    		OnJump.Invoke();
    	}

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    	//Menghentikan Animasi Burung ketika bersentukan dengan object lain
    	animator.enabled = false;
    }

    public void AddScore(int value)
    {
    	//Menambahkan score value
    	score += value;

    	//Pengecekan Null value
    	if(OnAddPoint != null)
    	{
    		//Memanggil semua event pada OnAddPoint
    		OnAddPoint.Invoke();
    	}
    	//Mengubah nilai text pada score text
    	scoreText.text = score.ToString();
    }

}
