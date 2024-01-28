using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    // TODO
    //������� 1. ������� �������� �� ����� � ����� (������������)
    //    ��� ����� �������
    //    �������� ������� �������� ������� �� ����� � ����� ��� ������ ����� �����
    //    � ������� ������� �� 0 �� N.��� ���������� ��������� ����� N ������ ��������
    //    �������� � �������� ����������� �� ����� N �� ����� 0.
    //    ����� ������ ������� ������, �������������� �������� �� Vector3[].

    //    ������ � ������������
    //    ����� ������ ������� ������, �������������� �������� �� Vector3[].
    //      �������� ������ ���������� forward. � �������� true ��� �������� �� �������� ����� �� 0 �� N. � �������� false � �� �������� �������� �� N �� 0.
    //      �������� ��������� ���������� ���� var distance � ����������� ����� Distance ��� ������� �� Vector3[], ����� ������ ��������� �� �������� ������� �� �����. � ���������� ����������� ��������� ���������� � �������� �����������.
    //  ����������� ����� MoveTowards ��� ������� �� Vector3[], ����� ��������� ������ � �����.
    //    ����������� ��������� �++� � ��������� �--�, ����� ��������� �������� ������� �� Vector3[] ��� ��������� ���.

    //    ������� 2. ������� �������� �� �������� �������� (������������)
    //    ��� ����� �������
    //    �������� ������� �� N ��������, ������� ��������� ��� ������ �� ��������: ����� ������ ����,
    //    ���� �� �������� �� �������.��� ������ ��������� �� ���������� ������� ���������� ������
    //    �������� ���������� passDistance, ������ �������� ���� ��������, �� ���������� ��������� ������.
    //    � ��� �� �����. 
    //    ��� �������� ���������� � ��������� �������������� �������� �� Transform.

    //    ������ � ������������
    //    ��������� ������ � ������� ���������� ����� �������:
    //    targetTransform � ��������� transform �������, � �������� ����� ������������.

    //    ������� 3. ������������ ������� (��������������)
    //    ��� ����� �������
    //    �������������� ������� �� ������� �������, ������ �� �� ���������� � ���� ������� �����,
    //    � ���������� �������� ���������� ������� ��� ����� ��������� ������.

    //    ������ � ������������
    //    ��������� ������������ ������ ����� �������
    //    childTransform � ��������� transform ��������� �������,

    //    parentTransform � ��������� transform ������������� �������.

    Vector3[] points = new[] { new Vector3(0, 0,0), new Vector3(5, 0, 0), new Vector3(5, 0, 7), new Vector3(9, 0, 7) };
    bool isForwardMove = true;
    //Transform [] points= new[4]{point1,point2};
    //public Transform point1;
    //public Transform point2;
    //public Transform point3;
    //public Transform point4;
    int pointIndex=1;
    bool moveForward=true;
    float speed;
    Vector3 targetPosition;

    void Start()
    {
        speed = 2f;
        targetPosition = points[pointIndex];
        
    }

    
    void Update()
    {
        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition,speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            if (isForwardMove)
            {
                pointIndex++;
                if (pointIndex >= points.Length)
                {
                    pointIndex = points.Length-1;
                    isForwardMove = false;
                }
            }
            else
            {
                pointIndex--;
                if (pointIndex < 0)
                {
                    pointIndex=0;
                    isForwardMove = true;
                }
            }
            targetPosition = points[pointIndex];

        }
        
    }
}
