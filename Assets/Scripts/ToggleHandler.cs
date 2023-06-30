using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHandler : MonoBehaviour
{
    public VariantManager VariantManager;
    Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        VariantManager = FindObjectOfType<VariantManager>();
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);

        toggle.isOn = VariantManager.variantB;
    }

    private void OnToggleValueChanged(bool newValue)
    {
        print("is called on toggle");
        VariantManager.variantB = newValue;
    }

    
}
