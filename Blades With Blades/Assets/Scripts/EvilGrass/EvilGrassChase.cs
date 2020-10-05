using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilGrassChase : EvilGrass
{
    public float stabDelay, stabSpeed, stabBackZ, stabFrontZ;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Stab());   
    }

    private void Update()
    {
        Vector3 direction = (new Vector3(PlayerMovement.Instance.transform.position.x, transform.position.y, PlayerMovement.Instance.transform.position.z) - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
        transform.LookAt(new Vector3(PlayerMovement.Instance.transform.position.x, transform.position.y, PlayerMovement.Instance.transform.position.z), Vector3.up);
    }

    IEnumerator Stab()
    {
        float curZ = sword.transform.localPosition.z;
        float dir = 1;
        while (true)
        {            
            curZ += stabSpeed * dir * Time.deltaTime;
            if (curZ >= stabFrontZ)
            {
                dir *= -1;
                //sword.transform.localPosition = new Vector3(sword.transform.localPosition.x, sword.transform.localPosition.y, stabFrontZ);
                curZ = stabFrontZ;
            }
            if(curZ <= stabBackZ)
            {
                dir *= -1;
                curZ = stabBackZ;
                //sword.transform.localPosition = new Vector3(sword.transform.localPosition.x, sword.transform.localPosition.y, stabBackZ);
                yield return new WaitForSeconds(stabDelay);
            }
            sword.transform.localPosition = new Vector3(sword.transform.localPosition.x, sword.transform.localPosition.y, curZ);
            yield return null;
        }
    }
}
