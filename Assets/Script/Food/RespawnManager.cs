using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public enum m_eFruit { NONE, PEANUTS, GRAPES, MUSHROOM }
    public int m_nPeanutMax;
    public int m_nGrapeMax;

    public List<Transform> listTrPeanuts; //땅콩위치리스트
    public List<GameObject> listObjPeanuts; //땅콩오브젝트리스트
    public List<Transform> listTrGrapes;
    public List<GameObject> listObjGrapes;

    public Transform m_tDummy;

    public void SetRespawnPoint(int posIdx, GameObject target, m_eFruit eKind)
    {
        if (eKind == m_eFruit.PEANUTS)
        {
            Vector3 pos = listTrPeanuts[posIdx].position;
            target.transform.position = new Vector3(pos.x, pos.y, pos.z);//땅콩이생성되는포인트
        }
        else if (eKind == m_eFruit.GRAPES)
        {
            Vector3 pos = listTrGrapes[posIdx].position;
            target.transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
    }

    //--//

    public void SetFruitMake(m_eFruit eKind)
    {
        if (eKind == m_eFruit.PEANUTS)
        {
            for (int i = 0; i < m_nPeanutMax; i++)
            {
                GameObject cObj_Peanut = Instantiate(Resources.Load("Prefab/Peanuts") as GameObject);
                SetRespawnPoint(i, cObj_Peanut, m_eFruit.PEANUTS);
                cObj_Peanut.transform.parent = this.transform;
                listObjPeanuts.Add(cObj_Peanut);
            }
        }

        else if (eKind == m_eFruit.GRAPES)
        {
            for (int i = 0; i < m_nGrapeMax; i++)
            {
                GameObject cObj_Grape = Instantiate(Resources.Load("Prefab/Grapes") as GameObject);
                SetRespawnPoint(i, cObj_Grape, m_eFruit.GRAPES);
                cObj_Grape.transform.parent = this.transform;
                listObjGrapes.Add(cObj_Grape);
            }
        }
    }

    //--//

    public void SetFruitChk(m_eFruit eKind)
    {
        if(eKind == m_eFruit.PEANUTS)
        { 
            for (int i = 0; i < listObjPeanuts.Count; i++)
            {
                FoodManager cFoodManager = listObjPeanuts[i].GetComponent<FoodManager>();

                if (cFoodManager.m_bEat)
                {
                    listObjPeanuts[i].SetActive(false);
                    listObjPeanuts[i].transform.position = m_tDummy.position;
                    SetRespawnPoint(i, listObjPeanuts[i], m_eFruit.PEANUTS);
                    StartCoroutine("PeanutRespawn", i);
                    cFoodManager.m_bEat = false;
                }
            }
        }
        else if(eKind == m_eFruit.GRAPES)
        {
            for (int i = 0; i < listObjGrapes.Count; i++)
            {
                FoodManager cFoodManager = listObjGrapes[i].GetComponent<FoodManager>();

                if (cFoodManager.m_bEat)
                {
                    listObjGrapes[i].SetActive(false);
                    listObjGrapes[i].transform.position = m_tDummy.position;
                    SetRespawnPoint(i, listObjGrapes[i], m_eFruit.GRAPES);
                    StartCoroutine("GrapeRspawn", i);
                    cFoodManager.m_bEat = false;
                }
            }
        }
    }

    //--//
    IEnumerator PeanutRespawn(int i)
    {
        yield return new WaitForSeconds(5);

        listObjPeanuts[i].gameObject.SetActive(true);
    }
    IEnumerator GrapeRspawn(int i)
    {
        yield return new WaitForSeconds(7);

        listObjGrapes[i].gameObject.SetActive(true);
    }

}
