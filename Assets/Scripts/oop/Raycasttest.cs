using UnityEngine;

public class Raycasttest : MonoBehaviour
{
    public float donusHizi = 10.0f; // Dönme hýzý
    public float gorusAcisi = 90f; // Görüþ açýsý
    public float gorusMesafesi = 15f; // Görüþ mesafesi
    public int isinSayisi = 50; // Çizilecek ray sayýsý
    public LayerMask duvarMaskesi; // Engel maskesi

    private float startingAngle;

    void Update()
    {
        // Küpü yavaþça döndür
        transform.Rotate(Vector3.up * donusHizi * Time.deltaTime);

        DrawFOVCircle();
    }

    void DrawFOVCircle()
    {
        float angleStep = gorusAcisi / isinSayisi;
        Vector3 previousEndPoint = Vector3.zero;

        for (int i = 0; i <= isinSayisi; i++)
        {
            float angle = transform.eulerAngles.y - gorusAcisi / 2 + angleStep * i;
            Vector3 dir = Quaternion.Euler(0, angle, 0) * Vector3.forward;
            RaycastHit hit;

            Vector3 endPoint;
            if (Physics.Raycast(transform.position, dir, out hit, gorusMesafesi, duvarMaskesi))
            {
                endPoint = transform.position + dir * hit.distance;
                Debug.DrawRay(transform.position, dir * hit.distance, Color.green);
            }
            else
            {
                endPoint = transform.position + dir * gorusMesafesi;
                Debug.DrawRay(transform.position, dir * gorusMesafesi, Color.red);
            }

            if (i > 0)
            {
                // Önceki rayýn son noktasý ile þimdiki rayýn son noktasýný birleþtir
                Debug.DrawLine(previousEndPoint, endPoint, Color.blue);
            }

            previousEndPoint = endPoint;

            // Son rayý ilk ray ile birleþtirerek çemberi tamamla
            // bu kýsým gerekli deðil
            if (i == isinSayisi)
            {
                float firstAngle = transform.eulerAngles.y - gorusAcisi / 2;
                Vector3 firstDir = Quaternion.Euler(0, firstAngle, 0) * Vector3.forward;
                Vector3 firstEndPoint = transform.position + firstDir * gorusMesafesi;
                Debug.DrawLine(endPoint, firstEndPoint, Color.blue);
            }
        }
    }
}