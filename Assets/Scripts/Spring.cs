using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

[System.Serializable]
public class Spring
{
	[SerializeField]
	protected float value = 0f;

	[SerializeField]
	protected float springForce = 1;

	[SerializeField]
	protected float springDampening = 0.8f;

	[SerializeField]
	private float springVelocity = 0f;

	[SerializeField]
	private float springTarget = 0f;

	public void Start()
	{

	}

	public void Update(float deltaTime)
	{
		float acceleration = springVelocity;
		float delta = springTarget - value;

		springVelocity += deltaTime * delta;
		springVelocity = Mathf.MoveTowards(springVelocity, 0, springDampening * Time.deltaTime);

		value += deltaTime * springVelocity;
	}

	public void SetTarget(float target)
	{
		springTarget = target;
	}

	public float GetValue()
	{
		return value;
	}
}
