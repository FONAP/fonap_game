using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterForm : MonoBehaviour
{
    public string name;
    public int age;
    public string community;
    public bool isAffiliate;

    public void FillForm(string name, int age, string community, bool isAffiliate)
    {
        this.name = name;
        this.age = age;
        this.community = community;
        this.isAffiliate = isAffiliate;
    }
}
