using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(HeroMovement))]
public class HeroInput : MonoBehaviour
{
    private HeroMovement _heroMovement;

    private void Start()
    {
        _heroMovement = GetComponent<HeroMovement>();
    }

    public void Turn(InputAction.CallbackContext context) 
    {
        Vector2 direction = context.ReadValue<Vector2>();
        _heroMovement.Turn(direction);
    }

}
