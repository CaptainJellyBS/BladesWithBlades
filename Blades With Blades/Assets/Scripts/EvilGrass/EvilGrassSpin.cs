using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilGrassSpin : EvilGrass
{
    // Start is called before the first frame update
    public float spinSpeed;
    

    private void Start()
    {
        transform.rotation = Quaternion.AngleAxis(Random.Range(0, 359), Vector3.up);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed*Time.deltaTime);
    }
}
