using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public List<Grid> allgrids;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //位置正確
    public void OnPutRight(Grid g)
    {
        allgrids.Remove(g);
        if (allgrids.Count == 0)
        {
            Debug.Log("finsh!");
        }
    }
}
