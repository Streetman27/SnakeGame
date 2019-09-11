using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delete", PlayerController.points);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
