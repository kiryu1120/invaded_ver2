using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    private bool isCooldown = false;
    public float cooldownTimer = 5f;

    void Start()
    {
        shield.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && !isCooldown)
        {
            // シフトが押されている場合、オブジェクトをアクティブにする
            shield.SetActive(true);
            StartCoroutine(ShieldDisappear());
        }
    }

    IEnumerator ShieldDisappear()
    {
        yield return new WaitForSeconds(2.7f);
        shield.SetActive(false);
        StartCoroutine(ShieldCooldown());
    }

    IEnumerator ShieldCooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTimer);
        isCooldown = false;
    }
}
