using Assets.Scripts.Player.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;//

public class Movement : MonoBehaviour{

	private float _speed;
	private float _gravity;
	private float _jumpHeight;
	private int _maxJumps;
	private float _dashDistance;
	private float _dashSpeed;

	private Transform _playerTransform;
	private CharacterController _characterControllerComponent;
	private Vector3 _velocity;
	private int _jumpCounter;
	private Vector3 _dashPosition;

	public void Construct(PlayerMovementStatsModel PlayerMovementStats)
	{
		_speed = PlayerMovementStats.Speed;
		_gravity = PlayerMovementStats.Gravity;
		_jumpHeight = PlayerMovementStats.JumpHeight;
		_maxJumps = PlayerMovementStats.MaxJumps;
		_dashDistance = PlayerMovementStats.DashDistance;
		_dashSpeed = PlayerMovementStats.DashSpeed;

		_playerTransform = this.gameObject.GetComponent<Transform>();
		_characterControllerComponent = this.gameObject.GetComponent<CharacterController>();
		_jumpCounter = 0;
	}

	public CharacterController GetCharacterController()
	{
		return _characterControllerComponent;
	}

	public Transform GetPlayerTransform()
	{
		return _playerTransform;
	}

	private void Update(){
		if (_characterControllerComponent.isGrounded && _velocity.y < 0)
		{
			_velocity.y = -2f;
			_jumpCounter = 0;
		}
		if (Input.GetButtonDown("Jump") && (_characterControllerComponent.isGrounded || _jumpCounter < _maxJumps))
		{
			_velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
			_jumpCounter++;
		}
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		Vector3 moveVector = new Vector3(x, 0, z);
		if (Mathf.Abs(x) + Mathf.Abs(z) > 1)
			moveVector *= 0.7f;
		_velocity.y += _gravity * Time.deltaTime;
		if (_dashPosition == new Vector3(0f, 0f, 0f))
		{
			_characterControllerComponent.Move(_playerTransform.TransformDirection(moveVector) * _speed * Time.deltaTime);
			_characterControllerComponent.Move(_velocity * Time.deltaTime);
		}
		Dash(moveVector);

	}

	private void Dash(Vector3 moveVector) {
		if (_dashPosition == new Vector3(0f,0f,0f))
		{
			moveVector = _playerTransform.TransformDirection(moveVector);
			if (Input.GetButtonDown("Dash"))
			{
				RaycastHit Hit;
				if (Physics.Raycast(_playerTransform.position, moveVector, out Hit, _dashDistance))
				{
					_dashPosition = Vector3.MoveTowards(Hit.point, _playerTransform.position, 1f);
				}
				else {
					_dashPosition = _playerTransform.position + moveVector * _dashDistance;
				}
			}
		}
		else
		{
			_playerTransform.position = Vector3.Lerp(_playerTransform.position, _dashPosition, Time.deltaTime * _dashSpeed);
			if (Mathf.Abs((int)Vector3.Distance(_playerTransform.position, _dashPosition)) < 1)
				_dashPosition = new Vector3(0f, 0f, 0f);
		}
	}
}