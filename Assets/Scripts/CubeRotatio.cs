using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotatio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject cube;


    [SerializeField] Vector3 RotatingValue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            cube.transform.Rotate(RotatingValue * Time.deltaTime);
            
    }
}
