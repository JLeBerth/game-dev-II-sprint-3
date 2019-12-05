using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotateDoor : MonoBehaviour
{
    //door to rotate
    public GameObject dooraxis;

    //degree to rotate to
    public int degree;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dooraxis.transform.rotation = Quaternion.Euler(dooraxis.transform.rotation.x, degree, dooraxis.transform.rotation.z);
    }
}
