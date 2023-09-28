using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AfegirNum(int numRebut)
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text += numRebut.ToString();
    }
}
