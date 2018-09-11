using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager {

    public static string username;
    public static int coin;
    public static int score;
    public static int maxscore;

    public static bool loggedIn { get { return username != null; } }

    public static void logOut()
    {
        username = null;
    }    
}
