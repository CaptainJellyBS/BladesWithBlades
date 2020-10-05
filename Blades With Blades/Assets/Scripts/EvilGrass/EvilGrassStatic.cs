using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilGrassStatic : EvilGrass
{
    // Start is called before the first frame update
    public float angleLimit, swingSpeed;
    
    int dir = 1;
    float angle = 0;

    private void Start()
    {
        transform.rotation = Quaternion.AngleAxis(Random.Range(0, 359), Vector3.up);
    }

    private void Update()
    {
        angle += dir * swingSpeed * Time.deltaTime;
        if(angle >= angleLimit || angle <= -angleLimit)
        {
            angle = Mathf.Clamp(angle, -angleLimit, angleLimit);
            dir *= -1;
        }
        sword.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
}
