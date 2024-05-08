using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.SocialPlatforms.Impl;
public class Player : MonoBehaviour
{
    //Napravite skripte kad se pokupi jedan novcic poveca se score
    //za jedan i novcic se unisti.
   // mora biti 10 novica na sceni i novcic ima svoju skriptu
   // CollectCoin a player svoju i u playeru je score varijabla.

    public int score;

   public void GiveCoin(int coin)
    {
        score += coin;
        Debug.Log(score);
    }
}
