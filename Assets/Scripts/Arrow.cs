using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    GameObject fruit;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 10);
        StartCoroutine(SelfDestroy(1));
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject parachute = other.transform.root.gameObject;
        if (parachute.GetComponent<FruitScript>())
        {
            GameObject.Find("GameMode").GetComponent<GameMode>().HitFruit((int)parachute.GetComponent<FruitScript>().type);
            parachute.GetComponent<Rigidbody>().drag = 0;
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

    private IEnumerator SelfDestroy(int lifeSpan)
    {
        yield return new WaitForSeconds(lifeSpan);
        GameMode.Instance.ChangeAmmoCount(-1);
        Destroy(gameObject);
    }
}
