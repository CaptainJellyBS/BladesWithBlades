using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilGrassCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("MowerBlade"))
        {
            GameManager.Instance.Score += transform.parent.GetComponent<EvilGrass>().scoreOnKill;
            Destroy(transform.parent.gameObject);
        }
    }
}
