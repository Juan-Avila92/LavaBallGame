using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;


public class CoinController : MonoBehaviour {
    
    public GameObject Coin;
    
    
	// Use this for initialization
	void Start () {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("Coin");
            Coin.SetActive(false);
            
           
        }
    }


    // Update is called once per frame
    void Update () {
		
	}
}
