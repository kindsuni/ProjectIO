using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager m_cInstance = null;

    public Player m_cPlayer;
    //public PlayerAttack m_cPlayer;
    public RespawnManager m_cRespawnManager;

    public GUIPlayer m_cGUIPlayer;

    private void Awake()
    {
        m_cInstance = this;
    }
    void Start()
    {
        m_cGUIPlayer.m_sExpValue.value = 0; //처음에 0으로 고정
        m_cGUIPlayer.m_sStaminaValue.value = 1; //처음에 1로 고정

        m_cRespawnManager.SetFruitMake(RespawnManager.m_eFruit.PEANUTS); //땅콩위치 처음생성
        m_cRespawnManager.SetFruitMake(RespawnManager.m_eFruit.GRAPES);
    }

    void Update()
    {
        m_cPlayer.m_txtExp.text = "" + m_cPlayer.m_fExp + " xp ("+ m_cPlayer.m_fMaxExp + " xp Next Animal)"; //경험치바
        m_cPlayer.m_txtStamina.text = "" + (float)m_cPlayer.m_fStamina + " / " + m_cPlayer.m_fMaxStamina; //스테미나
        m_cGUIPlayer.m_sExpValue.value = (1 / m_cPlayer.m_fMaxExp) * m_cPlayer.m_fExp; //경험치 슬라이드바
        m_cGUIPlayer.m_sStaminaValue.value = (1 / m_cPlayer.m_fMaxStamina) * m_cPlayer.m_fStamina; //스테미나 슬라이드바

        m_cRespawnManager.SetFruitChk(RespawnManager.m_eFruit.PEANUTS); //과일생존체크
        m_cRespawnManager.SetFruitChk(RespawnManager.m_eFruit.GRAPES);
        m_cPlayer.LvUp();
    }

    public static GameManager GetInstance()
    {
        return m_cInstance;
    }


    public void OnGUI()
    {
        GUI.Box(new Rect(100, 100, 100, 50), "LV : " + m_cPlayer.m_nLv);
    }
}
