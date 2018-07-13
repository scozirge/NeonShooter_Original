﻿using UnityEngine;
using System.Collections;

public partial class Player
{
    public static bool IsRigister { get; private set; }
    /// <summary>
    /// 設定語言
    /// </summary>
    public static void SetLanguage(Language _language)
    {
        UseLanguage = _language;
    }
    public static void SignUpGetData(string[] _data)
    {
        AC = _data[0];
        ACPass = _data[1];
        Name = _data[2];
        /*
        BestScore = int.Parse(_data[3]);
        Kills = int.Parse(_data[4]);
        Shot = int.Parse(_data[5]);
        CriticalHit = int.Parse(_data[6]);
        Death = int.Parse(_data[7]);
        CriticalCombo = int.Parse(_data[8]);
        */
        PlayerPrefs.SetString("AC", AC);
        PlayerPrefs.SetString("ACPass", ACPass);
        PlayerPrefs.SetString("Name", Name);
        IsRigister = true;
    }
    public static void SignInGetData(string[] _data)
    {
        /*
        Name = _data[0];
        BestScore = int.Parse(_data[1]);
        Kills = int.Parse(_data[2]);
        Shot = int.Parse(_data[3]);
        CriticalHit = int.Parse(_data[4]);
        Death = int.Parse(_data[5]);
        CriticalCombo = int.Parse(_data[6]);
        */
        IsRigister = true;
    }
    public static void NoACFB_CallBack(string[] _data)
    {
        AC = _data[0];
        ACPass = _data[1];
        Name = _data[2];
        PlayerPrefs.SetString("AC", AC);
        PlayerPrefs.SetString("ACPass", ACPass);
        PlayerPrefs.SetString("Name", Name);
        IsRigister = true;
    }
    public static void ChangeACFB_CallBack(string[] _data)
    {
        AC = _data[0];
        ACPass = _data[1];
        Name = _data[2];
        BestScore = int.Parse(_data[3]);
        Kills = int.Parse(_data[4]);
        Shot = int.Parse(_data[5]);
        CriticalHit = int.Parse(_data[6]);
        Death = int.Parse(_data[7]);
        CriticalCombo = int.Parse(_data[8]);
        PlayerPrefs.SetString("AC", AC);
        PlayerPrefs.SetString("ACPass", ACPass);
        PlayerPrefs.SetString("Name", Name);
        PlayerPrefs.SetInt("BestScore", BestScore);
        PlayerPrefs.SetInt("Kills", Kills);
        PlayerPrefs.SetInt("Shot", Shot);
        PlayerPrefs.SetInt("CriticalHit", CriticalHit);
        PlayerPrefs.SetInt("Death", Death);
        PlayerPrefs.SetInt("CriticalCombo", CriticalCombo);
        IsRigister = true;
    }
    public static void UpdateACFB_CallBack()
    {
        IsRigister = true;
    }
    public static void BlindingFB_CallBack()
    {
        IsRigister = true;
    }
}
