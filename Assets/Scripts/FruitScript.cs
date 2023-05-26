using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer m_parachuteMesh;

    private Rigidbody m_Rigidbody;

    private bool m_reachedMaxHeight = false;

    private float m_fallingThreshold = -0.01f;

    public enum FruitType
    {
        Apricot,
        Banana,
        Beetroot,
        Cabbage,
        Chilli,
        Corn,
        Eggplant,
        Pear,
        Pepper
    }

    public FruitType type;

    [SerializeField]
    private int m_DestroyTimerSec = 17;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        Invoke("DestroySelf", m_DestroyTimerSec);
        AddStartForce();
    
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Arrow")
        {
            print("hit arrow");
            GameMode.Instance.HitFruit((int)type);
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if(!m_reachedMaxHeight && m_Rigidbody.velocity.y <= m_fallingThreshold)
        {
            m_reachedMaxHeight = true;
            m_parachuteMesh.enabled = true;
        }
    }

    private void AddStartForce()
    {
        m_Rigidbody.AddForce(Vector3.up*130f, ForceMode.VelocityChange);
    }


}
