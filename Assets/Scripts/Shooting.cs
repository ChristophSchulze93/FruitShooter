using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    int ammo = 10;
    float timer = 0;
    public float fireRate; //hertz
    public GameObject arrow;
    public GameObject camera;
    public float speed;
    public Transform projectileSpawnPoint;
    public Animator m_animator;
    public GameObject animationArrow;
    public AudioSource shootSound;

    private void Start()
    {
      GameMode.Instance.ChangeAmmoCount(ammo);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if(GameMode.Instance.ammoCount > 0 && timer > 1 / fireRate)
            {
                timer = 0;
                GameObject arrowInstance = Instantiate(arrow);
                arrowInstance.transform.position = projectileSpawnPoint.position;//camera.transform.position + camera.transform.right;
                RaycastHit hit;
                if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
                {
                    arrowInstance.transform.up = hit.point - arrowInstance.transform.position;
                } else
                {
                    arrowInstance.transform.up = camera.transform.forward;
                }
                arrowInstance.GetComponent<Rigidbody>().velocity = arrowInstance.transform.up * speed;

                m_animator.Play("shootArrow");
                shootSound.Play();
                GameMetrics.shots++;
                StartCoroutine(ToggleArrow());
             //GameMode.Instance.ChangeAmmoCount(-1);
            }
        }
    }

    public IEnumerator ToggleArrow()
    {
        animationArrow.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        animationArrow.SetActive(true);
    }
}
