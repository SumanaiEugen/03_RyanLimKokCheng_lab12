using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject PlayerGO;
    Vector3 posoffset = new Vector3(0f,2f,-4f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerGO.transform.position + posoffset, 0.1f);
    }
}
