using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CursorScript : MonoBehaviour
{
    Vector2 Movement;
    public float Speed;
    private Rigidbody2D RB;
    private bool Lvl1;
    public SaveSystem SS;
    public GameObject[] Buttons;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SS = new SaveSystem();
        PlayerPrefs.SetInt("LvlNumber", 1);
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(Movement.x, Movement.y) * Time.deltaTime * Speed;

        if (PlayerPrefs.GetInt("LvlNumber") == 1)
        {
            Buttons[0].active = true;
            Buttons[1].active = false;
            Buttons[2].active = false;
        }

        if (PlayerPrefs.GetInt("LvlNumber") == 2)
        {
            Buttons[0].active = false;
            Buttons[1].active = true;
            Buttons[2].active = false;
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    public void OnPress(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed && PlayerPrefs.GetInt("LvlNumber") == 1)
        {
            Lvl1 = true;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Lvl1 && collision.gameObject.tag == "Level1")
        {
            SceneManager.LoadScene("Level1");
            PlayerPrefs.SetInt("LvlNumber", 2);
        }
    }
}
