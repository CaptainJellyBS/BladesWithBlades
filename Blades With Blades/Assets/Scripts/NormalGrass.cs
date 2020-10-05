using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGrass : MonoBehaviour
{
    public float growSpeed;
    public float minScale, maxScale;
    public float secondsUntilGrow;
    IEnumerator grow;

    // Start is called before the first frame update
    void Start()
    {
        grow = Grow();
        StartCoroutine(grow);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MowerBlade") || other.gameObject.CompareTag("Sword"))
        {
            StopCoroutine(grow);

            transform.localScale = new Vector3(transform.localScale.x, minScale, transform.localScale.z);
            grow = Grow();
            StartCoroutine(grow);
        }
    }

    IEnumerator Grow()
    {
        yield return new WaitForSeconds(secondsUntilGrow);
        float siz = transform.localScale.y;
        while (siz < maxScale)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + growSpeed, transform.localScale.z);
            siz = transform.localScale.y;
            yield return null;
        }

    }
}
