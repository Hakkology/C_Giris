using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : Human
{
    public string schoolName;

    public Student(string name, int age, string schoolName) : base(name, age)
    {
        this.schoolName = schoolName;
    }

    // Öðrenciye özel metot
    public virtual void Study()
    {
        Debug.Log(name + " þu anda " + schoolName + " okulunda ders çalýþýyor.");
    }
}
