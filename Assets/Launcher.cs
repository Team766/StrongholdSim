using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
	public float ShootPower;
	
	public Gripper gripper;
	
	public float maxForce;
	
	public void Launch()
	{
		if (gripper.holding)
		{
            var projectile = gripper.holding;
            gripper.Drop();
            projectile.transform.position = this.transform.position;
			projectile.AddForce(this.transform.forward * Mathf.Clamp01(ShootPower) * maxForce, ForceMode.Impulse);
		}
	}
}
