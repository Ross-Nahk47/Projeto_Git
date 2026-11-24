using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    private float _speed = 5f;

    void Update()
    {
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);

        float direction;
    
        if (leftPressed && rightPressed)
        {
            direction = 0f;
        }
        else if (rightPressed)
        {
            direction = 1f;
        }
        else if (leftPressed)
        {
            direction = -1f;
        }
        else 
        {
            direction = 0f;
        }

        float displacement = _speed * direction * Time.deltaTime;
    }
}