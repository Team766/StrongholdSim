using UnityEngine;
using System.Collections.Generic;

public class RobotController : MonoBehaviour {
	public Wheel[] leftWheels;
	public Wheel[] rightWheels;
	public float motorScaler;
	
	public Gripper gripper;
	public Launcher launcher;
    public Launcher launcher2;
    public Dictionary<ActuatedDefense, int> actuatedDefenses = new Dictionary<ActuatedDefense, int>();

    public void Actuate()
    {
        foreach (var d in actuatedDefenses)
        {
            if (d.Value > 0)
            {
                d.Key.Actuate(this);
            }
        }
    }
	
	public void SetMotors(float left, float right)
	{
		foreach(var h in leftWheels)
		{
			h.RunJoint(motorScaler * left);
		}
		foreach(var h in rightWheels)
		{
			h.RunJoint(motorScaler * right);
		}
	}
	
	public void SetGripper(bool state)
	{
		if (state)
			gripper.MoveOut();
		else
			gripper.MoveIn();
	}
	
	public float ShootPower
	{
		get
		{
			return launcher.ShootPower;
		}
		set
		{
			launcher.ShootPower = value;
		}
	}
	
	public void Launch()
	{
		launcher.Launch();
	}

    public void Launch2()
	{
		launcher2.Launch();
	}
  
  public int LeftEncoder
  {
    get
    {
      if (leftWheels.Length == 0)
        return 0;
      return leftWheels[0].Encoder;
    }
  }
  
  public int RightEncoder
  {
    get
    {
      if (rightWheels.Length == 0)
        return 0;
      return rightWheels[0].Encoder;
    }
  }
  
  static float Angle360(Vector3 v1, Vector3 v2, Vector3 n)
  {
    //  Acute angle [0,180]
    float angle = Vector3.Angle(v1,v2);

    //  -Acute angle [180,-179]
    float sign = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(v1, v2)));
    return angle * sign;
  }
  
  public float Heading
  {
    get
    {
      return Angle360(Vector3.forward, transform.forward, Vector3.up);
    }
  }
  
  public bool GripperState
  {
    get
    {
      return gripper.state;
    }
  }
  
  public bool BallPresence
  {
    get
    {
      return gripper.payload.Get() != null;
    }
  }
}
