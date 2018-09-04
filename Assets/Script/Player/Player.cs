using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text m_txtExp;
    public Text m_txtStamina;
    public Text m_txtSeeExp;
    public Text m_txtLvUp;

    public int m_nLv=1;
    public int m_nHp;
    public int m_nEat=1;
    public float m_fExp;
    public float m_fStamina;

    public int m_nMaxLv;
    public int m_nMaxHp;
    public float m_fMaxExp;
    public float m_fMaxStamina;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LvUp()
    {
        if(m_fExp >= m_fMaxExp)
        {
            m_nLv++;
            m_fExp = 0;
            m_nEat += 1;
            m_fMaxExp += 15;
            m_nEat += 1;
            m_fStamina = m_fMaxStamina += 0.2f;
            m_txtLvUp.gameObject.SetActive(true);

            Invoke("LvUpInvoke", 3);
        }
    }

    public void LvUpInvoke()
    {
        m_txtLvUp.gameObject.SetActive(false);
    }

    public void ExpInvoke()
    {
        m_txtSeeExp.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        GameObject cFood = col.gameObject;
        FoodManager cFoodManager = cFood.GetComponent<FoodManager>();

        //m_listPeanutRespawn.Add(cFoodManager.gameObject);

        if (col.gameObject.tag == "Food")
        {
            if (m_nEat > cFoodManager.m_nEat) //먹을 수 있다면.
            {
                m_fExp += cFoodManager.m_fExp;
                cFoodManager.m_bEat = true;
                m_txtSeeExp.text = "+" + cFoodManager.m_fExp +"Exp";
                m_txtSeeExp.gameObject.SetActive(true);
                Invoke("ExpInvoke", 1.3f);
            }
            //Invoke("PeanutPespawn", 5);
        }
    }
    //--//

}
