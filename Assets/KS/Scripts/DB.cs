using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DB : MonoBehaviour {

    string host = "127.0.0.1";
    enum MODE {LOGIN, INSERT, DELETE, SAVE};
    MODE mode;
    public Text username;
    public InputField nameField;
    public InputField passwordField;
    public GameObject startFields;
    public GameObject inputFields;
    public Button stRegistButton;
    public Button stLoginButton;
    public Button stPlayButton;
    public Button registButton;
    public Button loginButton;
    
    
    string sql;
    string result;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (DBManager.loggedIn && username != null)
        {
            username.text = "Player : " + DBManager.username;
        }
        if(stRegistButton != null)
        {
            stRegistButton.interactable = !DBManager.loggedIn;
            stLoginButton.interactable = !DBManager.loggedIn;
            stPlayButton.interactable = DBManager.loggedIn;
            Enter();
        }        
    }
    void Enter()
    {
        if (registButton.gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Register();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                Login();
            }
        }

    }
    public void OnInputRegistField()
    {
        startFields.SetActive(false);
        inputFields.SetActive(true);
        registButton.gameObject.SetActive(true);
        loginButton.gameObject.SetActive(false);
        nameField.ActivateInputField();
    }
    public void OnInputLoginField()
    {
        startFields.SetActive(false);
        inputFields.SetActive(true);
        registButton.gameObject.SetActive(false);
        loginButton.gameObject.SetActive(true);
        nameField.ActivateInputField();        
    }
    public void CancleButton()
    {
        nameField.text = "";
        passwordField.text = "";
        startFields.SetActive(true);
        inputFields.SetActive(false);
    }
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void Register()
    {
        mode = MODE.INSERT;
        sql = SelectQuery("players", string.Format("username = '{0}'", nameField.text));
        StartCoroutine(DBR(mode,sql));        
    }
    public void Delete()
    {
        mode = MODE.DELETE;
        sql = SelectQuery("players", string.Format("username = '{0}'", nameField.text));
        StartCoroutine(DBR(mode,sql));        
        //Debug.Log(result);
    }

    public void Login()
    {
        mode = MODE.LOGIN;
        sql = SelectQuery("players", string.Format("username = '{0}'",nameField.text));
        StartCoroutine(DBR(mode, sql));
       //Debug.Log(result);
    }
    public void Save()
    {
        if(DBManager.maxscore < DBManager.score)
        {
            mode = MODE.SAVE;
            sql = SelectQuery("players", string.Format("username = '{0}'",DBManager.username));
            StartCoroutine(SaveData(mode, sql));
        }
        return;
       //Debug.Log(result);
    }

    IEnumerator DBR(MODE _mode, string _sql)
    {
        WWWForm form = new WWWForm();        
        form.AddField("mode",string.Format("{0}",(int)_mode));
        form.AddField("sql", _sql);        
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        form.AddField("score", DBManager.score);
        //WWW www = new WWW(string.Format("http://{0}/testing.php",host),form);        
        WWW www = new WWW("http://192.168.0.33/testing.php", form);        
        yield return www;        
        if (www.isDone)
        {
            result = www.text.Trim();
            switch (mode)
            {
                case MODE.LOGIN:
                    {
                        if (result[0] == '0')
                        {
                            DBManager.username = nameField.text;
                            DBManager.maxscore = int.Parse(result.Split('\t')[1]);
                            startFields.SetActive(true);
                            inputFields.SetActive(false);
                            nameField.text = "";
                            passwordField.text = "";
                        }
                    }
                    break;                
                default:
                    {
                        if (result == "0")
                        {
                            //Debug.Log(result);
                            startFields.SetActive(true);
                            inputFields.SetActive(false);
                            nameField.text = "";
                            passwordField.text = "";
                        }
                        else
                        {
                            Debug.Log(result);
                        }
                    }
                    break;
                
            }            //Debug.Log(www.text.Split('\t')[1]);
            //Debug.Log(result);                        
        }
    }

    IEnumerator SaveData(MODE _mode, string _sql)
    {
        WWWForm form = new WWWForm();
        form.AddField("mode", string.Format("{0}", (int)_mode));
        form.AddField("sql", _sql);
        form.AddField("name", DBManager.username);
        form.AddField("password", "0");
        form.AddField("score", DBManager.score);
        //WWW www = new WWW(string.Format("http://{0}/testing.php",host),form);        
        WWW www = new WWW("http://127.0.0.1/testing.php", form);
        yield return www;
    }
    string SelectQuery(string table, string where)
    {
        //SELECT* FROM players WHERE username = '".$username."'";
        return string.Format("SELECT * FROM {0} WHERE {1}", table, where);
    }
    string InsertQuery(string table, string culums)
    {
        //SELECT* FROM players WHERE username = '".$username."'";
        return string.Format("INSERT INTO {0}({1})", table, culums);
    }
    string DeleteCulum(string table, string culums)
    {
        return string.Format("DELETE * FROM {0} WHERE {1}", table, culums);
    }
    public void VertifyInputs()
    {
        if (registButton.gameObject.activeInHierarchy)
        {
            registButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 4);
        }
        else
        {
            loginButton.interactable = (nameField.text.Length >= 4 && passwordField.text.Length >= 4);
        }
    }
}
