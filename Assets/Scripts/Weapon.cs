using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public BulletSO bulletSO;

    private UserInput UserInput;

    private bool isShooting;

    private BulletSO deffaultBullet;

    private void Awake()
    {
        UserInput = GetComponent<UserInput>();
        deffaultBullet = bulletSO;
    }

    private void Update()
    {
        if (UserInput.Shoot && isShooting == false)
        {
            StartCoroutine(Shoot(bulletSO.burstSize-1, bulletSO.rateOfFire));
        }
    }

    public IEnumerator Shoot(int burstSize, float rateOfFire)
    {
        isShooting = true;

        if(burstSize >= 2)
        {
            float stepAngleSize = bulletSO.shootAngle / burstSize;

            for (int i = 0; i < burstSize + 1; i++)
            {
                float angle = -transform.eulerAngles.z - bulletSO.shootAngle / 2 + stepAngleSize * i;

                Bullet bullet = Instantiate(bulletSO.bulletPrefab, transform.position, transform.rotation);
                bullet.rigid.AddForce(transform.up + DirFromAngle(angle, bulletSO.isGlobal) * bulletSO.bulletForce, ForceMode2D.Impulse);

                if (rateOfFire > 0)
                {
                    yield return new WaitForSeconds(rateOfFire);
                }

            }
        }
        else
        {
            Bullet bullet = Instantiate(bulletSO.bulletPrefab, transform.position, transform.rotation);
            bullet.rigid.AddForce(transform.up * bulletSO.bulletForce, ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(0.35f);

        isShooting = false;

        if(bulletSO.powerUpTime > 0)
        {
            yield return new WaitForSeconds(bulletSO.powerUpTime);
            bulletSO = deffaultBullet;
        }

    }

    private Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
    }
}