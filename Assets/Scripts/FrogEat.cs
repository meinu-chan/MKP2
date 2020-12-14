using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogEat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Fly")){
            Destroy(other.gameObject);
        }
    }
}
