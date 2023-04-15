using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;
using System.Collections;

public class LenguageSystem : MonoBehaviour
{
    private bool active = false;


    public void ChangeLocale(int localID)
    {
        if(active == true)
            return;

        StartCoroutine(SetLocale(localID));
    }

    IEnumerator SetLocale (int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active= false;
    }
}
