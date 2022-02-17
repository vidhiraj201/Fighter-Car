using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FCar.movement
{
    public class Movement : MonoBehaviour
    {
        private FCar.core.GameManager gm;
        [SerializeField] private Joystick joystick;
        [SerializeField] private BrakeButton brakeButton;
        [SerializeField] private AccelerateButton accelerateButton;
        public Rigidbody motorRB;
        public LayerMask groundMask;

        public float AirDrag = 0.1f;
        public float GroundDrag = 4;

        public float moveSpeed;
        public float backSpeed;
        public float rotationSpeed;

        private bool isGrounded;

        void Start()
        {
            gm = FindObjectOfType<FCar.core.GameManager>();
            motorRB.transform.parent = null;
        }


        void Update()
        {
            
            move();
        }

        float x, z;
        float zA;
        public void move()
        {
            x = joystick.Horizontal;
            z = zA/*joystick.Vertical*/;
            z *= z > 0 ? moveSpeed : backSpeed;

            transform.position = motorRB.transform.position;




            if (zA!=0)
            {
                float yRot = x * rotationSpeed * Time.deltaTime;
                transform.Rotate(0, yRot, 0, Space.World);
            }
            /*else
            {
                float yRot = x * rotationSpeed * joystick.Vertical * Time.deltaTime;
                transform.Rotate(0, yRot, 0, Space.World);
            }*/

            RaycastHit hit;
            isGrounded = Physics.Raycast(transform.position, -transform.up, out hit, 5f, groundMask);

           /* transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;*/

            accelerateAndBrake();

            if (!isGrounded)
                motorRB.drag = AirDrag;
            else
            {
                motorRB.drag = GroundDrag;
            }
        }

        private void FixedUpdate()
        {
            if(isGrounded)
                motorRB.AddForce(transform.forward * z, ForceMode.Acceleration);
            else
            {
                motorRB.AddForce(transform.up * -19.6f);
            }

        }
        
        void accelerateAndBrake()
        {
            if (accelerateButton.isAcceleratorPressed && zA<1)
            {
                zA += Time.deltaTime;
                if (zA > 1)
                    zA = 1;

            }
            if (brakeButton.isBrakePressed && zA>-1)
            {
                zA -= Time.deltaTime;
                if (zA < -1)
                    zA = -1;
            }
            
            if (!accelerateButton.isAcceleratorPressed && !brakeButton.isBrakePressed)
            {
               // zA = Mathf.Lerp(zA, 0, Time.deltaTime);
            }
            if (gm.GameOver)
            {
                if(zA>0)
                    zA -= Time.deltaTime;
                if (zA < 0)
                    zA += Time.deltaTime;
            }

        }
    }
}

