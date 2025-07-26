using UnityEngine;

public class Raycasttest : MonoBehaviour
{
    public float donusHizi = 10.0f; // D�nme h�z�
    public float gorusAcisi = 90f; // G�r�� a��s�
    public float gorusMesafesi = 15f; // G�r�� mesafesi
    public int isinSayisi = 50; // �izilecek ray say�s�
    public LayerMask duvarMaskesi; // Engel maskesi

    private float startingAngle;

    void Update()
    {
        // K�p� yava��a d�nd�r
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
                // �nceki ray�n son noktas� ile �imdiki ray�n son noktas�n� birle�tir
                Debug.DrawLine(previousEndPoint, endPoint, Color.blue);
            }

            previousEndPoint = endPoint;

            // Son ray� ilk ray ile birle�tirerek �emberi tamamla
            // bu k�s�m gerekli de�il
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