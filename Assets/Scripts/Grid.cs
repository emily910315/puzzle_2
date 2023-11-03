using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public bool hasPut;
    public void OnPutRight()
    {
        hasPut = true;
        GridManager.instance.OnPutRight(this);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
