using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caterpillar : MonoBehaviour
{
    public Transform hedef;
    public Transform omuz;
    public List<Transform> parcaciklar;

    public float hiz = 5;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 v = hedef.position - omuz.position;

        Vector3 yatay = new Vector3(v.x, 0f, v.z).normalized;
        float toplamYaw = Mathf.Atan2(yatay.x, yatay.z) * Mathf.Rad2Deg;

        float mesafeYatay = new Vector3(v.x, 0f, v.z).magnitude;
        float toplamPitch = -Mathf.Atan2(v.y, mesafeYatay) * Mathf.Rad2Deg;

        int n = parcaciklar.Count;

        omuz.localRotation = Quaternion.identity;

        for (int i = 0; i < n; i++)
        {
            float oran = (i + 1f) / n;
            float yaw = toplamYaw * oran;
            float pitch = toplamPitch * oran;

            // Sadece Yaw ve Pitch, Roll = 0
            Quaternion hedefRot = Quaternion.Euler(pitch, yaw, 0f);

            // Yumuþakça uygula
            parcaciklar[i].localRotation = Quaternion.Slerp(parcaciklar[i].localRotation, hedefRot, Time.deltaTime * hiz);
        }
    }
}
