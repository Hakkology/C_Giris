using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderModify : MonoBehaviour
{
    public ParticleSystem ps;

    void Start()
    {
        var main = ps.main;
        main.startColor = Color.red;         // Baþlangýç rengini kýrmýzý yap
        main.startSpeed = 8f;                // Baþlangýç hýzýný 8 yap

        ps.Emit(30);                         // 30 partikül oluþtur
    }

    void Update()
    {
        // Space'e basýnca partikül rengini deðiþtir
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var main = ps.main;
            main.startColor = Random.ColorHSV();
        }
    }
}

public class MaterialParamDemo : MonoBehaviour
{
    public Renderer rend; // Objeye atanmýþ MeshRenderer
    private Material mat;

    void Start()
    {
        mat = rend.material; // Kopya materyal
        mat.SetColor("_Color", Color.blue); // "_Color" property’sini deðiþtir
        mat.SetFloat("_Glossiness", 0.7f); // "_Glossiness" property’si (varsa)
    }

    void Update()
    {
        // Mouse sol týkla rengi rastgele deðiþtir
        if (Input.GetMouseButtonDown(0))
        {
            mat.SetColor("_Color", Random.ColorHSV());
        }
    }
}

public class InspectorParamDemo : MonoBehaviour
{
    //[Header("Inspector’dan Anýnda Deðiþtir!")]
    //public Color targetColor = Color.green;
    //public float targetSpeed = 5f;

    //public ParticleSystem ps;
    //private ParticleSystem.MainModule mainModule;

    //void Start()
    //{
    //    mainModule = ps.main;
    //}

    //void Update()
    //{
    //    mainModule.startColor = targetColor;     // Inspector’da rengi deðiþtir, anýnda güncellenir
    //    mainModule.startSpeed = targetSpeed;     // Inspector’da hýz deðiþtir, anýnda güncellenir
    //}

    public ParticleSystem myParticle;

    void Start()
    {
        myParticle.Play(); // Baþlatýr
        myParticle.Stop(); // Durdurur
        myParticle.Emit(10); // 10 partikül üret
        myParticle.Clear(); // Partikülleri temizle

        var main = myParticle.main;
        main.startColor = Color.red;
        main.startSpeed = 5f;
    }


}

public class BezierTest: MonoBehaviour
{
    Vector3 GetCubicBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector3 point = uuu * p0; // (1-t)^3 * P0
        point += 3 * uu * t * p1; // 3*(1-t)^2*t*P1
        point += 3 * u * tt * p2; // 3*(1-t)*t^2*P2
        point += ttt * p3;        // t^3*P3
        return point;
    }

    public LineRenderer line;
    public Transform p0, p1, p2, p3; // Editor'den atanan noktalar

    void Start()
    {
        int segmentCount = 20;
        line.positionCount = segmentCount + 1;
        for (int i = 0; i <= segmentCount; i++)
        {
            float t = i / (float)segmentCount;
            line.SetPosition(i, GetCubicBezierPoint(t, p0.position, p1.position, p2.position, p3.position));
        }
    }
}