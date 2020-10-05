using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWhenHitFence : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.CompareTag("Fence"))
        {
            GameManager.Instance.Die();
        }
    }
}
