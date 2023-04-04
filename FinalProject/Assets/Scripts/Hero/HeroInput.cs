using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(HeroMovement))]
[RequireComponent(typeof(HeroShooting))]
public class HeroInput : MonoBehaviour
{
    private HeroMovement _heroMovement;
    private HeroShooting _heroShooting;

    private void Start()
    {
        _heroMovement = GetComponent<HeroMovement>();
        _heroShooting = GetComponent<HeroShooting>();
    }

    public void Turn(InputAction.CallbackContext context) 
    {
        // ѕроверка фазы нужна дл€ того, чтобы действие вызывалось только один раз

        if (context.phase == InputActionPhase.Performed)
        {
            Vector2 direction = context.ReadValue<Vector2>();
            _heroMovement.Turn(direction);
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed)
        {
            _heroShooting.Shoot();
        }
    }

}
