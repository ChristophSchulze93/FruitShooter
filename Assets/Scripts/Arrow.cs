using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject fruit;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.GetComponent<FruitScript>())
        {
            fruit = other.gameObject;
            other.gameObject.transform.parent = transform;
            other.gameObject.transform.localPosition = Vector3.zero;
        }
    }

    private void Update()
    {
        if (fruit)
        {
            fruit.transform.localPosition = Vector3.zero;
        }
    }
}
