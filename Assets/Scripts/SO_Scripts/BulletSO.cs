using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO", menuName = "Asteroid_Fighter/BulletSO", order = 0)]
public class BulletSO : ScriptableObject
{
	public Bullet bulletPrefab;

	public float powerUpTime;

	public int burstSize;
	public float rateOfFire;
	public int shootAngle;

	public float bulletForce;
	public float bulletLifeTime;

	public bool isGlobal;
}