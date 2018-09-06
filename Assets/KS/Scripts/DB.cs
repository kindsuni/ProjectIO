using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DB : MonoBehaviour {

    string host = "127.0.0.1";
    enum MODE {LOGIN, INSERT, DELETE};
    MODE mode;
    public InputField nameField;
    public InputField passwordField;
    
    string sql;
    string result;
    private void Start()
    {
        
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

    IEnumerator DBR(MODE _mode, string _sql)
    {
        WWWForm form = new WWWForm();        
        form.AddField("mode",string.Format("{0}",(int)_mode));
        form.AddField("sql", _sql);        
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        //WWW www = new WWW(string.Format("http://{0}/testing.php",host),form);        
        WWW www = new WWW("http://127.0.0.1/testing.php", form);        
        yield return www;        
        if (www.isDone)
        {
            result = www.text.Trim();
            if (result =="0")
            {
                Debug.Log(result);
                if(mode == MODE.LOGIN)
                {
                    DBManager.username = nameField.text;
                    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                }
            }
            else
            {
                Debug.Log(result);
            }
        }
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
}
