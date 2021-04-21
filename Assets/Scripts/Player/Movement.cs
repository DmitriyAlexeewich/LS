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

	Transform Player;
	CharacterController PlayerRig;
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
	}

	void Awake()
	{
		Player = this.gameObject.GetComponent<Transform>();
		PlayerRig = this.gameObject.GetComponent<CharacterController>();
		JumpCounter = 0;
	}

	void Update(){
		if (PlayerRig.isGrounded && Velocity.y < 0)
		{
			Velocity.y = -2f;
			JumpCounter = 0;
		}
		if (Input.GetButtonDown("Jump") && (PlayerRig.isGrounded || JumpCounter < MaxJumps))
		{
			Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
			JumpCounter++;
		}
		Vector3 MoveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		Velocity.y += Gravity * Time.deltaTime;
		if (DashPosition == new Vector3(0f, 0f, 0f))
		{
			PlayerRig.Move(Player.TransformDirection(MoveVector) * Speed * Time.deltaTime);
			PlayerRig.Move(Velocity * Time.deltaTime);
		}
		Dash(MoveVector);
    }

	void Dash(Vector3 MoveVector) {
		if (DashPosition == new Vector3(0f,0f,0f))
		{
			MoveVector = Player.TransformDirection(MoveVector);
			if (Input.GetButtonDown("Dash"))
			{
				RaycastHit Hit;
				if (Physics.Raycast(Player.position, MoveVector, out Hit, DashDistance))
				{
					DashPosition = Vector3.MoveTowards(Hit.point, Player.position, 1f);
				}
				else {
					DashPosition = Player.position + MoveVector * DashDistance;
				}
			}
		}
		else
		{
			Player.position = Vector3.Lerp(Player.position, DashPosition, Time.deltaTime * DashSpeed);
			if (Mathf.Abs((int)Vector3.Distance(Player.position, DashPosition)) < 1)
				DashPosition = new Vector3(0f, 0f, 0f);
		}
	}
}