using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMap : MonoBehaviour
{

    public static MainMap instance;

    [SerializeField] private GameObject miniMap;
    [SerializeField] private GameObject mainMap;

    public bool IsLargeMapOpen {  get; private set; }   
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            if (!IsLargeMapOpen)
            {
                MapOpen();
            }

            else
            {
                MapClose();
            }
        }
    }

    private void MapOpen()
    {

    }

    private void MapClose()
    {

    }
}
