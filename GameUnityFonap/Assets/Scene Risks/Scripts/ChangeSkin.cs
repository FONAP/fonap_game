using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public GameObject skinsPanel;
    public GameObject player;
    public GameObject initialText;

    public void SetSkinMan()
    {
        PlayerPrefs.SetString("PlayerSelected", "Man");
        ResetPlayerSkin();
    }

    public void SetSkinGirl()
    {
        PlayerPrefs.SetString("PlayerSelected", "Girl");
        ResetPlayerSkin();
    }

    void ResetPlayerSkin()
    {
        skinsPanel.SetActive(false);
        player.GetComponent<PlayerSelect>().ChangePlayerSkin();
        initialText.SetActive(true);
    }
}
