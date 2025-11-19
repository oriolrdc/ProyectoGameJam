using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    //Components
    private CharacterController _controller;
    //Camera
    private Transform _mainCamera;
    private InputAction _lookAction;
    private Vector2 _lookInput;
    float xRotation;
    [SerializeField] private float _cameraSens = 10;
    [SerializeField] private Transform _lookAtCamera;
    //Movement
    private InputAction _moveAction;
    private Vector2 _moveInputs;
    private float _movementSpeed = 5;
    //Jump;
    private InputAction _jumpAction;
    [SerializeField] private float _jumpHeight = 2;
    //GorundSensor
    [SerializeField] private Transform _sensorPosition;
    [SerializeField] private float _sensorRadius = 0.5f;
    [SerializeField] private LayerMask _groundLayer;
    //Gravity
    private Vector3 _playerGravity;
    private float _gravity = -9.81f;
    //Interact
    private InputAction _interactAction;
    float interactRange = 2;
    [SerializeField] private LayerMask _InteractLayer;
    //Jenga
    [SerializeField] private bool _taken = false;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _moveAction = InputSystem.actions["Move"];
        _lookAction = InputSystem.actions["Look"];
        _jumpAction = InputSystem.actions["Jump"];
        _interactAction = InputSystem.actions["Interact"];
        _mainCamera = Camera.main.transform;
    }

    void Start()
    {
        _taken = false;
        GameManager.Instance._playerInputs.FindActionMap("Player").Disable();
        GameManager.Instance._playerInputs.FindActionMap("UI").Disable();
    }

    void Update()
    {
        _moveInputs = _moveAction.ReadValue<Vector2>();
        _lookInput = _lookAction.ReadValue<Vector2>();

        if(GameManager.Instance._TimelineCompleted)
        {
            Movement();
        }

        if(_jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
        }

        Gravity();

        if(_interactAction.WasPressedThisFrame())
        {
            Interact();
        }
    }

    void Movement()
    {
        Vector3 direction = new Vector3(_moveInputs.x, 0, _moveInputs.y);
        float mouseX = _lookInput.x * _cameraSens * Time.deltaTime;
        float mouseY = _lookInput.y * _cameraSens * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.Rotate(Vector3.up, mouseX);
        _lookAtCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);

        if(direction != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _mainCamera.eulerAngles.y;
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _controller.Move(moveDirection * _movementSpeed * Time.deltaTime);
        }
    }

    void Jump()
    {
        _playerGravity.y = Mathf.Sqrt(_jumpHeight * -2 * _gravity);
        _controller.Move(_playerGravity * Time.deltaTime);
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(_sensorPosition.position, _sensorRadius, _groundLayer);
    }

    void Gravity()
    {
        if(!IsGrounded())
        {
            _playerGravity.y += _gravity * Time.deltaTime; 
        }
        else if(IsGrounded() && _playerGravity.y < 0)
        {
            _playerGravity.y = _gravity;
        }
        _controller.Move(_playerGravity * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_sensorPosition.position, _sensorRadius);
    }

    void Interact()
    {
        Collider [] interactableObjects = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in interactableObjects)
        {
            if(collider.gameObject.tag == "Interactable")
            {
                InteractableObject script = collider.GetComponent<InteractableObject>();
                script.Interact();
            }
            
            if(collider.gameObject.tag == "JengaActive" && _taken == false)
            {
                Jenga script = collider.GetComponent<Jenga>();
                script.ToggleJenga(false);
                _taken = true;
            }
            else if(collider.gameObject.tag == "JengaInActive" && _taken == true)
            {
                Jenga script = collider.GetComponent<Jenga>();
                script.ToggleJenga(true);
            }
        }
    }

    /*public bool CanInteract()
    {
        return Physics.CheckSphere(transform.position, interactRange, _InteractLayer);
    }*/
}
