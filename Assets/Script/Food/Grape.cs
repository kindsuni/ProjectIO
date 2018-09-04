using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grape : MonoBehaviour
{
    public FoodManager m_cFoodManager;

    // Use this for initialization
    void Start()
    {
        m_cFoodManager = GetComponent<FoodManager>();
        m_cFoodManager.SetFunc(1, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
