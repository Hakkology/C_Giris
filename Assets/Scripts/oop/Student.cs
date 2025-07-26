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

    // ��renciye �zel metot
    public virtual void Study()
    {
        Debug.Log(name + " �u anda " + schoolName + " okulunda ders �al���yor.");
    }
}
