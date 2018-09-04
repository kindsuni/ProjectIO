using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public List<Vector3> m_listTrans = new List<Vector3>();
    public List<GameObject> m_listTail = new List<GameObject>();

    public float moveSpeed = 2f;
    public float RotationSpeed = 50f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Boost();
    }

    public void PlayerMove()
    {
        float translation = 1;
        float rotation = Input.GetAxis("Horizontal") * RotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, translation * moveSpeed, 0);
        transform.Rotate(0, 0, -rotation * moveSpeed);
        m_listTrans.Add(transform.position); //플레이어 포지션 리스트에 저장
        //Invoke("TailMove", 3f);
    }

    public void TailMove()
    {
        for (int i = 0; i <= m_listTrans.Count; i++)
        {
            if (m_listTrans[i] != null)
            {
                transform.position = m_listTrans[i];
                m_listTrans.Remove(m_listTrans[i]);
            }
        }
    }

    public void Boost()
    {
        Player cPlayer = GameManager.GetInstance().m_cPlayer;
        if (Input.GetMouseButton(0))
        {
            if (cPlayer.m_fStamina >= 0)
            {
                float translation = 1.5f;
                translation *= Time.deltaTime;
                transform.Translate(0, translation * moveSpeed, 0);
                cPlayer.m_fStamina -= Time.deltaTime;
            }
        }
        else
        {
            cPlayer.m_fStamina += Time.deltaTime;
            if (cPlayer.m_fStamina >= cPlayer.m_fMaxStamina)
                cPlayer.m_fStamina = cPlayer.m_fMaxStamina;
        }
    }
}
