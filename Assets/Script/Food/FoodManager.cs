using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public int m_nEat;
    public float m_fExp;

    public bool m_bEat = false;

    public void SetFunc(int eat, float exp)
    {
        m_nEat = eat;
        m_fExp = exp;
    }
}
