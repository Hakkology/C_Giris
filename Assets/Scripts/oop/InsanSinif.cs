using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsanSinif : MonoBehaviour
{
    public HumanStats stats;
    Insan sakir;
    //public List<Insan> insanList = new List<Insan>();
    public List<Insan> insanList = new();
    void Start()
    {
        sakir = new Insan("Sakir", "Kayadan");
        //sakir.isim = "Sakir";
        //sakir.soyisim = "Kayadan";
        sakir.sacRengi = Color.black;
        //sakir.boy

        //sakir = new();

        //Debug.Log($"ismi: {sakir.isim}, soyismi: {sakir.soyisim}, sacrengi: {sakir.sacRengi.ToString()}");

        sakir.sacRengi = Color.red;

        Insan ahmet = new Insan("Ahmet", "Demir");
        //ahmet.isim = "Ahmet";
        //ahmet.soyisim = "Demir";
        ahmet.sacRengi = Color.blue;

        //ahmet.SetTamIsým("")

        //insanList = new List<Insan>();

        insanList.Add( sakir );
        insanList.Add( ahmet );

        foreach (var insan in insanList)
        {
            Debug.Log($"ismi: {insan.Isim}, soyismi: {insan.soyisim}, sacrengi: {insan.sacRengi.ToString()}");
        }


        var hakan = new Human("Hakan", 35);
        var furkan = new Student("Furkan", 27, "ITÜ");

        furkan.Speak();
        furkan.Study();
        //furkan.sc
        hakan.Speak();

        float damage = stats.CalculatePhysicalDamage();
        //hakan.scho
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
