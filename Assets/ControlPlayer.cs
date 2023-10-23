using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ControlPlayer : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    //vector stores 2 values, x & y
    Vector2 movementInput;
    Rigidbody2D rigidBod;
    // Start is called before the first frame update
    void Start()
    {
        rigidBod = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        bool success = true;
        if(movementInput != Vector2.zero)
        {
            success = TryMove(movementInput);
        }
        if(!success)
        {
            success = TryMove(new Vector2(movementInput.x,0));
            if(!success)
            {
                success = TryMove(new Vector2(0,movementInput.y));
            }
        }
    }

    public bool TryMove(Vector2 direction)
    {
        //count is the number of collisions
        int count = rigidBod.Cast(
                direction,
                movementFilter,
                castCollisions,
                moveSpeed*Time.fixedDeltaTime + collisionOffset
            );
            //if no collisions, player can move
            if(count == 0){
                rigidBod.MovePosition(rigidBod.position+direction*moveSpeed*Time.fixedDeltaTime);
                return true;
            }
            else    
                return false;
    }
    void OnMove(InputValue movementVal)
    {
        movementInput = movementVal.Get<Vector2>();

    }
}
