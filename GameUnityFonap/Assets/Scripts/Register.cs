using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using SimpleJSON;

public class Register : MonoBehaviour
{
    private string URL = "http://localhost:3000/register";
    
    public InputField inputName;
    public InputField inputAge;
    public InputField inputCommunity;
    public Toggle toggleIsAffiliate;
    public Button submitButton;
    public GameObject messageBox;

    public void Submit()
    {
        submitButton.interactable = false;
        StartCoroutine(SubmitForm());
    }

    public void CloseModal()
    {
        messageBox.SetActive(false);
        submitButton.interactable = true;
    }

    IEnumerator SubmitForm()
    {
        WWWForm form = GenerateForm(inputName.text, int.Parse(inputAge.text), inputCommunity.text, toggleIsAffiliate.isOn);

        UnityWebRequest unityWebRequest = UnityWebRequest.Post(URL, form);
        yield return unityWebRequest.SendWebRequest();

        if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
        {
            Debug.Log(unityWebRequest.error);
            submitButton.interactable = true;
            yield break;
        }

        JSONNode data = JSON.Parse(unityWebRequest.downloadHandler.text);
        PlayerPrefs.SetInt("user_id", data["data"][0]);

        if (int.Parse(inputAge.text) > 0 && int.Parse(inputAge.text) <= 8)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else if (int.Parse(inputAge.text) > 8 && int.Parse(inputAge.text) <= 17)
        {
            messageBox.SetActive(true);
        }
        else if (int.Parse(inputAge.text) > 17)
        {
            messageBox.SetActive(true);
        }
    }

    WWWForm GenerateForm(string name, int age, string community, bool is_affiliate)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("age", age);
        form.AddField("community", community);
        form.AddField("is_affiliate", is_affiliate? 1: 0);

        return form;
    }
}
