using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    int ammo = 999;
    float timer = 0;
    public float fireRate; //hertz
    public GameObject arrow;
    public GameObject camera;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if(ammo > 0 && timer > 1 / fireRate)
            {
                --ammo;
                timer = 0;
                GameObject arrowInstance = Instantiate(arrow);
                arrowInstance.transform.position = camera.transform.position + camera.transform.right;
                RaycastHit hit;
                if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
                {
                    arrowInstance.transform.up = hit.point - arrowInstance.transform.position;
                } else
                {
                    arrowInstance.transform.up = camera.transform.forward;
                }
                arrowInstance.GetComponent<Rigidbody>().velocity = arrowInstance.transform.up * speed;
            }
        }
    }
}
