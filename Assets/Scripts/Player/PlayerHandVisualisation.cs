using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandVisualisation : MonoBehaviour
{

    private Animator _handAnimator;
    private CharacterController _playerRig;

    private float _horizontalAnimatorFloat = 0;
    private float _verticalAnimatorFloat = 0;
    private IEnumerator _switchWeaponCoroutine = null;

    public void Construct(CharacterController characterControllerComponent)
    {
        _playerRig = characterControllerComponent;
        _handAnimator = this.gameObject.GetComponent<Animator>();
    }

    public void StartSwitchWeapon(PlayerWeapon previousWeapon, PlayerWeapon currentWeapon)
    {
        if (_switchWeaponCoroutine != null)
            StopCoroutine(_switchWeaponCoroutine);
        previousWeapon.enabled = false;
        currentWeapon.enabled = true;
        _switchWeaponCoroutine = SwitchWeapon(previousWeapon, currentWeapon);
        StartCoroutine(_switchWeaponCoroutine);
    }

    private IEnumerator SwitchWeapon(PlayerWeapon previousWeapon, PlayerWeapon currentWeapon)
    {
        yield return null;
        _handAnimator.Play("HideWeapon");
        while(_handAnimator.GetCurrentAnimatorStateInfo(0).IsName("HideWeapon"))
            yield return null;
        previousWeapon.HideWeapon();
        currentWeapon.ShowWeapon();
        yield return null;
        _switchWeaponCoroutine = null;
    }

    private void Update()
    {
        _horizontalAnimatorFloat = Input.GetAxis("Horizontal");
        _verticalAnimatorFloat = Input.GetAxis("Vertical");
        if ((Input.GetButtonDown("Dash")) && (_switchWeaponCoroutine == null))
        {
            if (_verticalAnimatorFloat > 0)
                _handAnimator.Play("DashForward");
            else if (_verticalAnimatorFloat < 0)
                _handAnimator.Play("DashBackward");
            if (_horizontalAnimatorFloat > 0)
                _handAnimator.Play("DashRight");
            else if (_horizontalAnimatorFloat < 0)
                _handAnimator.Play("DashLeft");
        }
        if (!_playerRig.isGrounded)
        {
            _horizontalAnimatorFloat = 0;
            _verticalAnimatorFloat = 0;
        }
        _handAnimator.SetFloat("Horizontal", _horizontalAnimatorFloat);
        _handAnimator.SetFloat("Vertical", _verticalAnimatorFloat);
    }
}
