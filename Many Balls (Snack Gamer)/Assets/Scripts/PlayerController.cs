using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [SerializeField] private float moveSpeed = 6f;
   [SerializeField] private float rotationSpeed = 4f;
   
   [SerializeField] private Rigidbody rb;
   [SerializeField] private Joystick joystick;

   private float horizontal;
   private float vertical;

   private Vector3 moveVector;

   private bool restrictMovement;

   private void Start()
   {
      UpgradeManager.Instance.OnUpgradePanelClose += OnUpgradePanelClose;
   }

   private void OnDestroy()
   {
      UpgradeManager.Instance.OnUpgradePanelClose -= OnUpgradePanelClose;
   }
   
   private void Update()
   {
      if(restrictMovement) return;
      HandleInputs();
      HandleRotation();
   }

   private void FixedUpdate()
   {
      if(restrictMovement) return;
      
      rb.velocity = moveVector * moveSpeed;
   }

   private void HandleInputs()
   {
      horizontal = joystick.Horizontal;
      vertical = joystick.Vertical;

      moveVector = new Vector3(horizontal, 0f, vertical).normalized;
   }

   private void HandleRotation()
   {
      if (moveVector.magnitude != 0f)
      {
         transform.forward = Vector3.Lerp(transform.forward, moveVector, rotationSpeed * Time.deltaTime);
      }
   }

   private void OnUpgradePanelClose()
   {
      restrictMovement = false;
   }
   
      
   public void PlayerUpgradeEnterTrigger(Vector3 otherPosition, Quaternion otherRotation)
   {
      restrictMovement = true;
      rb.velocity = Vector3.zero;
      
      Transform playerT = transform;
      playerT.position = new Vector3(otherPosition.x, playerT.position.y, otherPosition.z);
      playerT.rotation = otherRotation;
   }

   public void IncrementSpeed()
   {
      moveSpeed += 1.2f;
   }

}
