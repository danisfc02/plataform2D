using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public float salto = 5f;
    public LayerMask capaSuelo;
    public int saltosmaximos;




    /// //////////////////////////////////////////////////////////////////

    RaycastHit2D hit;
    public Vector3 V3;
    public LayerMask plataforma;
    public float distance;

    

    Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider;
    private int saltosrestantes;



    /// ////////////////////////

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position + V3, Vector2.up * -1 * distance);
    }

    private void Start()
    {
        saltosrestantes = saltosmaximos;
    }
    void Update()
    {
        ProcesarSalto();
        Detector_Plataformas();
    }

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    bool EstaEnSuelo()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    
    /// //////////////
    /// 
    
    public void Detector_Plataformas()
    {
        if (CheckCollision)
        {
            transform.parent = hit.collider.transform;
        }
        else
        {
            transform.parent = null;
        }
    }
    
    bool CheckCollision
    {
        get
        {
            hit = Physics2D.Raycast(transform.position + V3, transform.up * -1, distance, plataforma);
            return hit.collider != null;   
        }
    }

   
    /// 
   
    void ProcesarSalto()
    {
        if (EstaEnSuelo())
        {
            saltosrestantes = saltosmaximos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && saltosrestantes > 0)
        {
            saltosrestantes--;
            rigidbody2d.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
        }
    }


    void FixedUpdate()
    { 


        if (Input.GetKey(KeyCode.LeftArrow))
            rigidbody2d.velocity = new Vector2(speed * -1, rigidbody2d.velocity.y);
            
           
        if (Input.GetKey(KeyCode.RightArrow))
            rigidbody2d.velocity = new Vector2(speed, rigidbody2d.velocity.y);
            
    }
}
