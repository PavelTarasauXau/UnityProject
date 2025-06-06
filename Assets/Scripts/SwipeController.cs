using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    private void Update()
    {
        // ���������� ��� ����� � ������ �����
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;

        // ��������� ���������� (���������)
        HandleKeyboardInput();

        // ������������ ��������� ���/�������
        HandleTouchInput();
    }

    private void HandleKeyboardInput()
    {
        // �������� ����� (A ��� ������� �����)
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            swipeLeft = true;
        }

        // �������� ������ (D ��� ������� ������)
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            swipeRight = true;
        }

        // ������ (������ ��� ������� �����)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            swipeUp = true;
        }
    }

    private void HandleTouchInput()
    {
        #region ��-������ (����)
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        // ���������� ���������
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // �������� �� ������������ ����������
        if (swipeDelta.magnitude > 100)
        {
            // ����������� �����������
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            Reset();
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }
}