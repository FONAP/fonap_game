using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Register : MonoBehaviour
{
    private string URL = "http://localhost:3000/register";

    public RegisterForm registerForm;
    
    public InputField inputName;
    public InputField inputAge;
    public InputField inputCommunity;
    public Toggle toggleIsAffiliate;

    public void Submit()
    {
        StartCoroutine(SubmitForm());
    }

    IEnumerator SubmitForm()
    {
        WWWForm form = GenerateForm(inputName.text, int.Parse(inputAge.text), inputCommunity.text, toggleIsAffiliate.isOn);

        UnityWebRequest data = UnityWebRequest.Post(URL, form);
        yield return data.SendWebRequest();

        if (data.isNetworkError)
        {
            Debug.Log(data.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
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
