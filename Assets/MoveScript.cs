using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    // TODO
    //Задание 1. Система движения от точки к точке (обязательное)
    //    Что нужно сделать
    //    Создайте систему движения объекта от точки к точке для любого числа точек
    //    с помощью массива от 0 до N.При достижении последней точки N объект начинает
    //    движение в обратном направлении от точки N до точки 0.
    //    Чтобы задать позиции точкам, воспользуйтесь массивом из Vector3[].

    //    Советы и рекомендации
    //    Чтобы задать позиции точкам, воспользуйтесь массивом из Vector3[].
    //      Создайте булеву переменную forward. В значении true она отвечает за движение вперёд от 0 до N. В значении false — за обратное движение от N до 0.
    //      Создайте локальную переменную типа var distance и используйте метод Distance для массива из Vector3[], чтобы узнать дистанцию от главного объекта до точки. В дальнейшем используйте локальную переменную в условной конструкции.
    //  Используйте метод MoveTowards для массива из Vector3[], чтобы направить объект к точке.
    //    Используйте инкремент «++» и декремент «--», чтобы прибавить значение массива из Vector3[] или уменьшить его.

    //    Задание 2. Система движения по принципу эстафеты (обязательное)
    //    Что нужно сделать
    //    Создайте систему из N объектов, которые двигаются как бегуны на эстафете: бежит только один,
    //    пока не добегает до другого.Как только дистанция до следующего «бегуна» становится меньше
    //    значения переменной passDistance, объект перестаёт быть «бегуном», им становится следующий объект.
    //    И так по кругу. 
    //    Для хранения информации о «бегунах» воспользуйтесь массивом из Transform.

    //    Советы и рекомендации
    //    Повернуть бегуна в сторону следующего можно методом:
    //    targetTransform — компонент transform объекта, к которому нужно развернуться.

    //    Задание 3. Визуализация бегунов (дополнительное)
    //    Что нужно сделать
    //    Визуализируйте бегунов из второго задания, собрав их из примитивов в виде фигурок людей,
    //    и реализуйте передачу эстафетной палочки при смене активного бегуна.

    //    Советы и рекомендации
    //    Назначить родительский объект можно методом
    //    childTransform — компонент transform дочернего объекта,

    //    parentTransform — компонент transform родительского объекта.

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
