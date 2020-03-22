using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaded : MonoBehaviour
{
    public void LoadScene(string name)
    {
    	//Melakukan pengecekan jika nama tidak null atau kosong
    	if (!string.IsNullOrEmpty(name))
    	{
    		//Membuka scene dengan nama sesuai dengan variable nama
    		SceneManager.LoadScene(name);
    	}
    }
}
