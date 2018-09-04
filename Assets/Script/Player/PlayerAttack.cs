using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player" )
        {
            
        }

        //if (col.gameObject.tag == "Player")
        //{
        //    if (m_nEat > cFoodManager.m_nEat) //먹을 수 있다면.
        //    {
        //        m_fExp += cFoodManager.m_fExp;
        //        cFoodManager.m_bEat = true;
        //        m_txtSeeExp.text = "+" + cFoodManager.m_fExp + "Exp";
        //        m_txtSeeExp.gameObject.SetActive(true);
        //        Invoke("ExpInvoke", 1.3f);
        //    }
        //    //Invoke("PeanutPespawn", 5);
        //}
    }

}
