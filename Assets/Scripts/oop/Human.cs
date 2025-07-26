using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human
{
    public string name;
    public int age;

    public Human(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public void Speak()
    {
        Debug.Log(name + " konuþuyor.");
    }
}