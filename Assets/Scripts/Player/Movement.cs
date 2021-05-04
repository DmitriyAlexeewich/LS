using Assets.Scripts.Player.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;//

public class Movement : MonoBehaviour{

	float Speed;
	float Gravity;
	float JumpHeight;
	int MaxJumps;
	float DashDistance;
	float DashSpeed;

	Transform PlayerTransform;
	CharacterController CharacterControllerComponent;
	Vector3 Velocity;
	int JumpCounter;
	Vector3 DashPosition;

	public void Construct(PlayerMovementStatsModel PlayerMovementStats)
	{
		Speed = PlayerMovementStats.Speed;
		Gravity = PlayerMovementStats.Gravity;
		JumpHeight = PlayerMovementStats.JumpHeight;
		MaxJumps = PlayerMovementStats.MaxJumps;
		DashDistance = PlayerMovementStats.DashDistance;
		DashSpeed = PlayerMovementStats.DashSpeed;

		PlayerTransform = this.gameObject.GetComponent<Transform>();
		CharacterControllerComponent = this.gameObject.GetComponent<CharacterController>();
		JumpCounter = 0;
	}

	public CharacterController GetCharacterController()
	{
		return CharacterControllerComponent;
	}

	public Transform GetPlayerTransform()
	{
		return PlayerTransform;
	}

	void Update(){
		if (CharacterControllerComponent.isGrounded && Velocity.y < 0)
		{
			Velocity.y = -2f;
			JumpCounter = 0;
		}
		if (Input.GetButtonDown("Jump") && (CharacterControllerComponent.isGrounded || JumpCounter < MaxJumps))
		{
			Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
			JumpCounter++;
		}
		Vector3 MoveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		Velocity.y += Gravity * Time.deltaTime;
		if (DashPosition == new Vector3(0f, 0f, 0f))
		{
			CharacterControllerComponent.Move(PlayerTransform.TransformDirection(MoveVector) * Speed * Time.deltaTime);
			CharacterControllerComponent.Move(Velocity * Time.deltaTime);
		}
		Dash(MoveVector);
    }

	void Dash(Vector3 MoveVector) {
		if (DashPosition == new Vector3(0f,0f,0f))
		{
			MoveVector = PlayerTransform.TransformDirection(MoveVector);
			if (Input.GetButtonDown("Dash"))
			{
				RaycastHit Hit;
				if (Physics.Raycast(PlayerTransform.position, MoveVector, out Hit, DashDistance))
				{
					DashPosition = Vector3.MoveTowards(Hit.point, PlayerTransform.position, 1f);
				}
				else {
					DashPosition = PlayerTransform.position + MoveVector * DashDistance;
				}
			}
		}
		else
		{
			PlayerTransform.position = Vector3.Lerp(PlayerTransform.position, DashPosition, Time.deltaTime * DashSpeed);
			if (Mathf.Abs((int)Vector3.Distance(PlayerTransform.position, DashPosition)) < 1)
				DashPosition = new Vector3(0f, 0f, 0f);
		}
	}
}