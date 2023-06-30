using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VariantManager : MonoBehaviour
{
    public bool variantB = false;

    public static VariantManager Instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            //Instance = new VariantManager();
            //DontDestroyOnLoad(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }

    public void ChangeVariant()
    {
        variantB = !variantB;
    }
}
