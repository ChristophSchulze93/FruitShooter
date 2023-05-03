using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    [SerializeField]
    private int m_DestroyTimerSec = 15;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", m_DestroyTimerSec);
    }


    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
