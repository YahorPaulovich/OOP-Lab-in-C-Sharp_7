using System;
using System.Collections;
using System.Collections.Generic;

namespace Generalizations//Вариант 14
{//№ 8 Обобщения
    class Program
    {/*Задание 
    1. Создайте обобщенный интерфейс с операциями добавить, удалить, просмотреть. 
    2. Возьмите за основу лабораторную № 4 «Перегрузка операций» и сделайте из нее обобщенный тип (класс) CollectionType<T>, 
    в который вложите обобщённую коллекцию. Наследуйте в обобщенном классе интерфейс из п.1. 
    Реализуйте необходимые методы. Добавьте обработку исключений c finally. Наложите какое-либо ограничение на обобщение. 
    3. Проверьте использование обобщения для стандартных типов данных (в качестве стандартных типов использовать целые, вещественные и т.д.). 
    Определить пользовательский класс, который будет использоваться в качестве параметра обобщения. 
    Для пользовательского типа взять класс из лабораторной №5 «Наследование». 

    Дополнительно: Добавьте методы сохранения объекта (объектов) обобщённого типа CollectionType<T> в файл и чтения из него.*/

        /*Краткие теоретические сведения*/
        static void Main(string[] args)
        {
            Queue<string> stringQueue = new Queue<string>();
            Queue<int> intQueue = new Queue<int>();
            Queue<int> intQueue2 = new Queue<int>();

            string[] strmas = { "A", "B", "C", "D", "E", "F" };//char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            foreach (string s in strmas)
            {
                stringQueue.Enqueue(s);
            }
            Console.WriteLine();

            foreach (string stringItem in stringQueue)
            {
                Console.WriteLine(stringItem);
            }
            Console.WriteLine();

            for (int i = 1; i <= 10; i++)
            {
                intQueue.Enqueue(i);
                intQueue2.Enqueue(i+10);
            }
            Console.WriteLine();

            foreach (int intItem in intQueue)
            {
                Console.WriteLine(intItem);
            }
            
            Crocodile<Queue<int>, string> operation =
                new Crocodile<Queue<int>, string>()
                {
                    BodyLength = intQueue,
                    Weight = intQueue2,
                    Name = "GHIJKLM"
                };

            Crocodile<int, string> operation2 =
            new Crocodile<int, string>()
            {
                BodyLength = 1234,
                Weight = 1312313,
                Name = "NOPQRSTU"
            };

            int x = 12;
            int y = 45;
            Swap<int>(ref x, ref y);

            string s1 = "hello";
            string s2 = "bye";
            Swap<string>(ref s1, ref s2);

            Console.WriteLine($"\n x = {x}, y = {y} \n s1 = {s1}, s2 = {s2}");

            Console.ReadKey();
        }
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        public static void CrocoRun<T>(T C1, T C2, int speed) where T : B
        {
        try
        {

        }
        catch { }
        finally { }
        //
        }
    }
    public abstract class A
    {
        public abstract string ToString();
        public abstract void Add();
        public abstract void Delete();
        public abstract void Watch(ref Queue<string> queue);
    }

    #region CollectionType<T>
    //Обощения позволяют решить проблему упаковки/ распаковки - то есть повысить производительность приложения и также позволяют справиться с проблемой безопасности типов.
    public class CollectionType<T> : A
    {
        #region Add(),Delete(),Watch(),ToString()
        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }
        public override void Watch(ref System.Collections.Generic.Queue<string> queue)
        {
            System.Collections.Generic.Queue<string> q = queue;
            Action action = () =>
            {
                Console.WriteLine($"Количество: {q.Count} ");
            };
            action();
        }
        public override string ToString()
        {
            throw new NotImplementedException();
        }     
        #endregion

        public class Node<T>
        {
            public Node(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public Node<T> Next { get; set; }

            public string Name { get; set; }
        }
        public class Queue<T> : IEnumerable<T>
        {
            Owner person;
            Date datecreation;
            public static int Id { get; set; }

            Node<T>[] data;
            Node<T> head; // головной/первый элемент
            Node<T> tail; // последний/хвостовой элемент
            int count;

            public Queue()
            {
                data = new Node<T>[5];

                Id = Id + 1;
                person = new Owner(Id, "Egor Pavlovich", "MITSO");
                datecreation = new Date(DateTime.Now);
            }

            public Queue(T First)
            {
                data = new Node<T>[5];
                if (head != null)
                {
                    head.Data = First;
                }

                Id = Id + 1;
                person = new Owner(Id, "Egor Pavlovich", "MITSO");
                datecreation = new Date(DateTime.Now);
            }

            public Queue(T First, T Last)
            {
                data = new Node<T>[5];
                head.Data = First;
                tail.Data = Last;

                Id = Id + 1;
                person = new Owner(Id, "Egor Pavlovich", "MITSO");
                datecreation = new Date(DateTime.Now);
            }

            // индексатор 1
            public Node<T> this[int index]
            {
                get
                {
                    return data[index];
                }
                set
                {
                    data[index] = value;
                }
            }
            // индексатор 2
            public Node<T> this[string name]
            {
                get
                {
                    Node<T> node = null;
                    foreach (var n in data)
                    {
                        if (n?.Name == name)
                        {
                            node = n;
                            break;
                        }
                    }
                    return node;
                }
            }

            public static Queue<double> operator +(Queue<T> first, Queue<T> second)
            {
                return new Queue<double> { doubleValue = first.doubleValue + second.doubleValue };
            }
            public static double operator +(Queue<T> first, double d)
            {
                return first.doubleValue + d;
            }
            public static double operator +(double d, Queue<T> second)
            {
                return d + second.doubleValue;
            }

            public static bool operator >(Queue<T> first, Queue<T> second)
            {
                if (first.intValue > second.intValue)
                    return true;
                else
                    return false;
            }
            public static bool operator <(Queue<T> first, Queue<T> second)
            {
                if (first.intValue < second.intValue)
                    return true;
                else
                    return false;
            }

            public static Queue<T> operator ++(Queue<T> d)
            {
                return new Queue<T> { doubleValue = d.doubleValue + 1, intValue = d.intValue + 1, stringValue = d.stringValue };
            }

            public static implicit operator Queue<T>(double d)//
            {
                return new Queue<T> { doubleValue = d };
            }
            public static explicit operator double(Queue<T> Q) //explicit --- int x = (int)queue1; implicit -- int x = queue1;
            {
                return Q.doubleValue;
            }

            public double doubleValue { get; set; }
            public int intValue { get; set; }
            public T stringValue { get; set; } //Обобщённый тип данных

            // добавление в очередь
            public void Enqueue(T data)
            {
                Node<T> node = new Node<T>(data);
                Node<T> tempNode = tail;
                tail = node;
                if (count == 0)
                    head = tail;
                else
                    tempNode.Next = tail;
                count++;
            }
            // удаление из очереди
            public T Dequeue()
            {
                if (count == 0)
                    throw new InvalidOperationException();
                T output = head.Data;
                head = head.Next;
                count--;
                return output;
            }
            // получаем первый элемент
            public T First
            {
                get
                {
                    if (IsEmpty)
                        throw new InvalidOperationException();
                    return head.Data;
                }
            }
            // получаем последний элемент
            public T Last
            {
                get
                {
                    if (IsEmpty)
                        throw new InvalidOperationException();
                    return tail.Data;
                }
            }
            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }

            public void Clear()
            {
                head = null;
                tail = null;
                count = 0;
            }

            public bool Contains(T data)
            {
                Node<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
                return false;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
          

            public Queue<T> CopySortInDescendingOrder(Queue<T> Queue)
            {/*копирование одной очереди в другую с сортировкой в убывающем порядке;*/
                Queue<T> tempqueue = new Queue<T>();
                if (count == 0)
                    throw new InvalidOperationException();
                while (Queue.Count > 0)
                    tempqueue.Enqueue(Queue.Dequeue());

                //queue2 = new Queue<T>(queue1);
                return tempqueue;
            }
        }
        public class Owner /*Владелец*/
        {            
            public string Name { get; set; }
            public string Organisation { get; set; }

            public Owner(int Id, string Name, string Organisation)
            {
                this.Name = Name;
                this.Organisation = Organisation;
            }
        }
        public class Date /*(Дата создания)*/
        {
            public int year;
            public int month;
            public int day;

            public DateTime birth;          
            string name;

            public int Age(string name, DateTime birth)/*вычисление возраста*/
            {
                this.birth = birth;              
                this.name = name;

                year =  DateTime.Now.Year;
                int age = year - this.birth.Year;
                return age;
            }
            public Date(DateTime dateTime)
            {
                year = DateTime.Now.Year;
                month = DateTime.Now.Month;
                day = DateTime.Now.Day;
                
                DateTime date = new DateTime(year, month, day); // год - месяц - день//Console.WriteLine(DateTime.Now);
                Console.WriteLine(date);
            }
        }
    }
    #endregion  
    #region пользовательский тип
    public class Crocodile<U, V>
    where U : new()
    where V : class
        //Крокодил
    {       
        public U BodyLength { get; set; }
        public U Weight { get; set; }
        public V Name { get; set; }       

        public Crocodile(U bodyLength, U weight, V name)
        {         
            BodyLength = bodyLength;
            Weight = weight;
            Name = name;
        }

    public Crocodile()
    {
    }

    public override string ToString()
        {
            return string.Format("Рептилия: {0} \t Длина тела = {1}; Вес = {2}.", Name, BodyLength, Weight);
        }
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            Crocodile<U, V> temp = (Crocodile<U, V>)obj;
            return base.Equals(temp);
            //return Name == temp.Name &&
            //BodyLength == temp.BodyLength &&
            //Weight == temp.Weight;           
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();         
        }
    }
    #endregion
    public class B
    {
        public B()
        {

        }
    }

    }
