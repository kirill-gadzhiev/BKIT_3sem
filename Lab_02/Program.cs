using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Lab_02
{


    interface IPrint
    {
        void Print();
    }

    public class SimpleListItem<T>
    {
        public T data { get; set; }

        public SimpleListItem<T> next { get; set; }
        ///конструктор
        public SimpleListItem(T param)
        {
            this.data = param;
        }
    }

    public class SimpleList<T> : IEnumerable<T>
    where T : IComparable
    {
        protected SimpleListItem<T> first = null;
        protected SimpleListItem<T> last = null;
        public int Count
        {
            get { return _count; }
            protected set { _count = value; }
        }
        int _count;
        public void Add(T element)
        {
            SimpleListItem<T> newItem = new SimpleListItem<T>(element); this.Count++;
            //Добавление первого элемента
            if (last == null)
            {
                this.first = newItem;
                this.last = newItem;
            }
            //Добавление следующих элементов
            else
            {
                //Присоединение элемента к цепочке
                this.last.next = newItem;
                //Просоединенный элемент считается последним
                this.last = newItem;
            }

        }
        public SimpleListItem<T> GetItem(int number)
        {
            if ((number < 0) || (number >= this.Count))
            {
                throw new Exception("Выход за границу индекса");
            }
            SimpleListItem<T> current = this.first;
            int i = 0;
            //Пропускаем нужное количество элементов
            while (i < number)
            {
                //Переход к следующему элементу
                current = current.next;
                //Увеличение счетчика
                i++;
            }
            return current;
        }

        public T Get(int number)
        {
            return GetItem(number).data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            SimpleListItem<T> current = this.first;
            //Перебор элементов
            while (current != null)
            {
                //Возврат текущего значения
                yield return current.data; //Переход к следующему элементу current = current.next;
            }
        }

        //Реализация обощенного IEnumerator<T> требует реализации необобщенного интерфейса
        //Данный метод добавляется автоматически при реализации интерфейса

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Sort()
        {
            Sort(0, this.Count - 1);
        }

        private void Sort(int low, int high)
        {
            int i = low;
            int j = high;
            T x = Get((low + high) / 2);
            do
            {
                while (Get(i).CompareTo(x) < 0) ++i;
                while (Get(j).CompareTo(x) > 0) --j;
                if (i <= j)
                {
                    Swap(i, j);
                    i++; j--;
                }
            } while (i <= j);
            if (low < j) Sort(low, j);
            if (i < high) Sort(i, high);

        }

        private void Swap(int i, int j)
        {
            SimpleListItem<T> ci = GetItem(i);
            SimpleListItem<T> cj = GetItem(j);
            T temp = ci.data;
            ci.data = cj.data;
            cj.data = temp;
        }
    }
    class Matrix<G>
    {
        //тут должен быть словарь из образца
        Dictionary<string, G> MyMatrix = new Dictionary<string, G>();
        int maxX, maxY, maxZ;//максимальные значения по xyz
        G nullElement;//пустой элемент
        public Matrix(int maxX, int maxY, int maxZ, G nullElement)//конструктор
        {
            this.maxX = maxX;
            this.maxY = maxY;
            this.maxZ = maxZ;
            this.nullElement = nullElement;
        }

        public G this[int x, int y, int z]//индексация
        {
            get
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                if (this.MyMatrix.ContainsKey(key))
                {
                    return this.MyMatrix[key];
                }
                else
                {
                    return this.nullElement;
                }
            }
            set
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z); this.MyMatrix.Add(key, value);
            }
        }

        public override string ToString()//переопределение метода ToString()
        {
            StringBuilder str = new StringBuilder();
            for (int k = 0; k < maxZ; k++)
            {
                str.Append("z = " + k + "\n");
                for (int j = 0; j < maxY; j++)
                {
                    str.Append("[");
                    for (int i = 0; i < maxZ; i++)
                    {
                        if (i > 0) str.Append(" ");
                        str.Append(this[i, j, k].ToString());
                    }
                    str.Append("]");
                }
                str.Append("\n");
            }
            return str.ToString();
        }

        void CheckBounds(int x, int y, int z)
        {
            if (x < 0 || x >= this.maxX) throw new Exception("x=" + x + " выходит за границы");
            if (y < 0 || y >= this.maxY) throw new Exception("y=" + y + " выходит за границы");
            if (z < 0 || z >= this.maxZ) throw new Exception("z=" + z + " выходит за границы");
        }

        string DictKey(int x, int y, int z)//формирование ключа для словаря
        {
            return x.ToString() + "_" + y.ToString() + "_" + z.ToString();
        }
    }
    abstract class Figure : IComparable
    {
        string type;//тип фигуры
        public void Print()//печать хар-к фигуры
        {
            Console.WriteLine(ToString() + '\n');
        }
        public abstract double Area();//площадь фигуры
        int IComparable.CompareTo(object SomeFigure)
        {
            Figure tmp = (Figure)SomeFigure;
            //if (this == null || tmp == null) return;
            if (this.Area() > tmp.Area()) return 1;
            if (this.Area() < tmp.Area()) return -1;
            else return 0;
        }
        //public abstract void Print();
    }

    class Rect : Figure
    {
        protected double width, length;//свойства прямоугольника
        string type;//тип фигуры
        public override double Area()//метод подсчета площади
        {
            return width * length;
        }
        public override string ToString()//переопределенный метод вывода свойств в строку
        {
            return string.Format("{0}:\nWidth: {1}\nLength: {2}\nArea: {3}", type, width, length, Area());
        }
        /*public void Print()//печать хар-к прямоугольника
        {
            Console.WriteLine(ToString());
        }*/
        public Rect(double width, double length)//конструктор
        {
            this.width = width;
            this.length = length;
            type = "Rectangle";
        }
    }

    class Square : Rect
    {
        string type;//тип
        public override string ToString()//переопределенный метод вывода свойств в строку
        {
            return string.Format("{0}:\nWidth: {1}\nArea: {2}", type, width, Area());
        }
        public Square(double width) : base(width, width)//конструктор
        {
            type = "Square";
        }
    }

    class Circle : Figure
    {
        string type;//тип
        double radius;//радиус
        public override string ToString()//переопределенный метод вывода свойств в строку
        {
            return string.Format("{0}:\nRadius: {1}\nArea: {2}", type, radius, Area());
        }
        public override double Area()//метод подсчета площади
        {
            return Math.PI * Math.Pow(radius, 2);
        }
        /*public void Print()//печать хар-к круга
        {
            Console.WriteLine(ToString());
        }*/
        public Circle(double radius)//конструктор
        {
            this.radius = radius;
            type = "Circle";
        }
    }

    class SimpleStack<T> : SimpleList<T> where T : IComparable
    {
        
        public void Push(T element)
        {
            //Добавление в конец списка уже реализовано 
            Add(element);
        }

       
        public T Pop()
        {
            //default(T) - значение для типа T по умолчанию
            T Result = default(T);
            //Если стек пуст, возвращается значение по умолчанию для типа
            if (this.Count == 0) return Result;
            //Если элемент единственный
            if (this.Count == 1)
            {
                //то из него читаются данные
                Result = this.first.data;
                //обнуляются указатели начала и конца списка
                this.first = null;
                this.last = null;
            }
            //В списке более одного элемента
            else
            {
                //Поиск предпоследнего элемента
                SimpleListItem<T> newLast = this.GetItem(this.Count - 2);
                //Чтение значения из последнего элемента
                Result = newLast.next.data;
                //предпоследний элемент считается последним
                this.last = newLast;
                //последний элемент удаляется из списка
                newLast.next = null;
            }
            //Уменьшение количества элементов в списке
            this.Count--;
            //Возврат результата            
            return Result;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            double x = 10.0;
            double y = 20.0;
            double r = 15.0;
            double a = 25.0;

            Rect One = new Rect(x, y);
            Circle Two = new Circle(r);
            Square Three = new Square(a);

            Console.WriteLine("Одномерный массив");
            Figure[] MyArr = new Figure[3];
            MyArr[0] = One;
            MyArr[1] = Two;
            MyArr[2] = Three;
            foreach (Figure element in MyArr)
            {
                element.Print();
            }

            Console.WriteLine("Коллекция ArrayList");
            ArrayList AListTest = new ArrayList();
            AListTest.Add(One);
            AListTest.Add(Two);
            AListTest.Add(Three);
            foreach (Figure element in AListTest)
            {
                element.Print();
            }

            Console.WriteLine("Коллекция List<Figure>");
            List<Figure> ListTest = new List<Figure>();
            ListTest.Add(One);
            ListTest.Add(Two);
            ListTest.Add(Three);
            foreach (Figure element in ListTest)
            {
                element.Print();
            }

            Matrix<int> M = new Matrix<int>(5, 5, 5, 0);
            M[0, 0, 0] = 32;
            M[2, 2, 2] = 53;
            Console.WriteLine(M.ToString());

            SimpleStack<Figure> MyStack = new SimpleStack<Figure>();
            MyStack.Push(One);
            MyStack.Push(Two); 
            MyStack.Push(Three);
            Console.WriteLine(MyStack.Pop());
            Console.WriteLine(MyStack.Pop());

            Console.WriteLine(MyStack.Pop());

        }
    }
}