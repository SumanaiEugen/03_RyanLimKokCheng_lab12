using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject coinCollected;
    bool touchenemy = false;
    float coincount = 0f;
    private float totalcoin;
    
    // Start is called before the first frame update
    void Start()
    {
        totalcoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (coincount == totalcoin)
        {
            SceneManager.LoadScene("WinScene");
        }
        if (transform.position.y < -5 || touchenemy == true)
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            
                coincount++;
                coinCollected.GetComponent<Text>().text = "Coin Collected: " + coincount;
                Debug.Log(" 1 ");
                Destroy(other.gameObject);
            
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            touchenemy = true;
        }
    }
}
