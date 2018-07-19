using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// DestroyByBoundary class destroys shells that go to the boundaries of the map
/// </summary>
public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player")
        Destroy(other.gameObject);
    }
}
