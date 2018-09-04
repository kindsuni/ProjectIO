using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peanut : MonoBehaviour
{
    public FoodManager m_cFoodManager;
    // Use this for initialization
    void Start()
    {
        m_cFoodManager = GetComponent<FoodManager>();
        m_cFoodManager.SetFunc(0,2);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
