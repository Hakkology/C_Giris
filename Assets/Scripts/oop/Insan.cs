

using UnityEngine;

public class Insan 
{
    private float boy;
    private float kilo;

    public Insan(string _isim, string _soyisim)
    {
        Isim = _isim;
        soyisim = _soyisim;
    }

    public string Isim;
    public string soyisim;


    public int yas;
    public bool cinsiyet; // true ise kadýn olsun, false ise erkek

    public Color sacRengi;
    public Color gozRengi;
    public Color tenRengi;

    public void SetTamIsým(string isim, string soyisim)
    {
        this.Isim = isim;
        this.soyisim = soyisim;
    }

    public float GetBoy(float yeniBoy)
    {
        return boy;
    }

    public float GetKilo()
    {
        return kilo;
    }

    //public void 
}
