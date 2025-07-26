using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMudur
{
    void CalisaniKov();
}

public class Ogrement : Student
{
    public Ogrement(string name, int age, string schoolName) : base(name, age, schoolName)
    {

    }

    //public void CalisaniKov()
    //{
    //    throw new System.NotImplementedException();
    //}

    public override void Study()
    {
        Debug.Log(name + " þu anda " + schoolName + " okulunda ders veriyor.");
    }
}
