using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pice : MonoBehaviour
{
    public int index;
    public Vector3 startpos;
    public bool followEnable = true;//是否跟著滑鼠
    public bool hasPut;
    private Grid triggerGrid;
    private int currentGrid = -1;
    void Start()
    {
        startpos = transform.position;
    }

    private void OnMouseEnter()
    {
        
    }

    //開始拖移
    private void OnMouseDown()
    {
        if (hasPut == false)
        {
            followEnable = true;
        }
        
    }

    private void OnMouseDrag()
    {
        if (followEnable == false)
        {
            return;
        }
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//滑鼠在3d世界的位置
        mousepos.z = 0;
        transform.position = mousepos;
    }

    private void OnMouseUp()
    {
        if (currentGrid >= 0)
        {
            if (currentGrid==index)
                    {
                        hasPut = true;
                        transform.position = triggerGrid.transform.position;
                        triggerGrid.hasPut = true;
                    }
            else
            {
                transform.position = startpos;
            }
        }
        else
        {
            transform.position = startpos;
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Grid")
        {
            Grid grid=collision.GetComponent<Grid>();
            if (!grid.hasPut)
            {
                triggerGrid = grid;
                currentGrid = int.Parse(collision.name);
                //如果略過放置就打開下面
                //if(int.Parse(collision.name) == index)
                // {
                //     hasPut = true;

                //     collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);//格子下的icon顯示
                //     transform.position = collision.transform.position;//換位
                //     followEnable = false;
                // }
            }
            
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggerGrid!=null&&collision.gameObject==triggerGrid.gameObject)
        {
            triggerGrid = null;
            currentGrid = -1;
        }
    }
}
