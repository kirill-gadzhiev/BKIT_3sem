using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_07
{
    class Program
    {
        public class Worker
        {
            public int id;
            public string full_name;
            public int branch_id;

            public Worker(int id, string full_name, int branch_id)
            {
                this.id = id;
                this.full_name = full_name;
                this.branch_id = branch_id;
            }

            public override string ToString()
            {
                return "(id=" + this.id.ToString() + "; full_name=" + this.full_name + "; branch_id=" + this.branch_id + ")";
            }
        }

        public class Branch
        {
            public int id;
            public string name;

            public Branch(int id, string name)
            {
                this.id = id;
                this.name = name;
            }

            public override string ToString()
            {
                return "(id=" + this.id.ToString() + "; name=" + this.name + ")";
            }
        }

        public class BranchWorkers
        {
            public int id;
            public int branch_id;
            public int worker_id;

            public BranchWorkers(int id, int worker_id, int branch_id)
            {
                this.id = id;
                this.worker_id = worker_id;
                this.branch_id = branch_id;
            }

            public override string ToString()
            {
                return "(worker_id=" + this.worker_id + "; branch_id=" + this.branch_id + ")";
            }
        }
        /// <summary>
        /// Класс данных
        /// </summary>
        public class Data
        {
            /// <summary>
            /// Ключ
            /// </summary>
            public int id;

            /// <summary>
            /// Для группировки
            /// </summary>
            public string grp;

            /// <summary>
            /// Значение
            /// </summary>
            public string value;

            /// <summary>
            /// Конструктор
            /// </summary>
            public Data(int i, string g, string v)
            {
                this.id = i;
                this.grp = g;
                this.value = v;
            }

            /// <summary>
            /// Приведение к строке
            /// </summary>
            public override string ToString()
            {
                return "(id=" + this.id.ToString() + "; grp=" + this.grp + "; value=" + this.value + ")";
            }
        }

        /// <summary>
        /// Класс для сравнения данных
        /// </summary>
        public class DataEqualityComparer : IEqualityComparer<Data>
        {

            public bool Equals(Data x, Data y)
            {
                bool Result = false;
                if (x.id == y.id && x.grp == y.grp && x.value == y.value) Result = true;
                return Result;
            }

            public int GetHashCode(Data obj)
            {
                return obj.id;
            }
        }

        public class WorkerEqualityComparer : IEqualityComparer<Worker>
        {

            public bool Equals(Worker x, Worker y)
            {
                bool Result = false;
                if (x.id == y.id && x.full_name == y.full_name && x.branch_id == y.branch_id) Result = true;
                return Result;
            }

            public int GetHashCode(Worker obj)
            {
                return obj.id;
            }
        }

        public class BranchEqualityComparer : IEqualityComparer<Branch>
        {

            public bool Equals(Branch x, Branch y)
            {
                bool Result = false;
                if (x.id == y.id && x.name == y.name) Result = true;
                return Result;
            }

            public int GetHashCode(Branch obj)
            {
                return obj.id;
            }
        }

        public class BranchWorkersEqualityComparer : IEqualityComparer<BranchWorkers>
        {

            public bool Equals(BranchWorkers x, BranchWorkers y)
            {
                bool Result = false;
                if (x.branch_id == y.branch_id && x.worker_id == y.worker_id) Result = true;
                return Result;
            }

            public int GetHashCode(BranchWorkers obj)
            {
                return obj.id;
            }
        }

        /// <summary>
        /// Связь между списками
        /// </summary>
        public class DataLink
        {
            public int d1;
            public int d2;

            public DataLink(int i1, int i2)
            {
                this.d1 = i1;
                this.d2 = i2;
            }
        }

        static List<Worker> w1 = new List<Worker>()
        {
            new Worker(1, "Иванов Николай Владимирович", 1),
            new Worker(2, "Николаев Владимир Иванович", 2),
            new Worker(3, "Савельев Дмитрий Павлович", 1),
            new Worker(4, "Петров Алексей Юрьевич", 2),
            new Worker(5, "Жириновский Владимир Валерьевич", 3),
            new Worker(6, "Укупник Борис Аркадьевич", 3),
            new Worker(7, "Алимов Николай Владимирович", 4),
            new Worker(8, "Аксенов Владимир Николаевич", 4),
            new Worker(9, "Ананьев Евгений Генадьевич", 1) 
        };

        static List<Branch> b1 = new List<Branch>()
        {
            new Branch(1, "Отдел кадров"),
            new Branch(2, "Фронт-енд"),
            new Branch(3, "Бэк-енд"),
            new Branch(4, "Менеджеры"),
            new Branch(5, "Охрана"), 
            new Branch(6, "Бухгалтерия")
        };

        static List<BranchWorkers> bw1 = new List<BranchWorkers>()
        {
            new BranchWorkers(1, 1, 1),
            new BranchWorkers(1, 1, 2),
            new BranchWorkers(1, 2, 3),
            new BranchWorkers(1, 4, 1),
            new BranchWorkers(1, 5, 1),
            new BranchWorkers(1, 6, 2),
            new BranchWorkers(1, 4, 6)
        };

        //Пример данных
        static List<Data> d1 = new List<Data>()
            {
                new Data(1, "group1", "11"),
                new Data(2, "group1", "12"),
                new Data(3, "group2", "13"),
                new Data(5, "group2", "15")
            };

        static List<Data> d2 = new List<Data>()
            {
                new Data(1, "group2", "21"),
                new Data(2, "group3", "221"),
                new Data(2, "group3", "222"),
                new Data(4, "group3", "24")
            };

        static List<Data> d1_for_distinct = new List<Data>()
            {
                new Data(1, "group1", "11"),
                new Data(1, "group1", "11"),
                new Data(1, "group1", "11"),
                new Data(2, "group1", "12"),
                new Data(2, "group1", "12")
            };

        static List<DataLink> lnk = new List<DataLink>()
        {
            new DataLink(1,1),
            new DataLink(1,2),
            new DataLink(1,4),
            new DataLink(2,1),
            new DataLink(2,2),
            new DataLink(2,4),
            new DataLink(5,1),
            new DataLink(5,2)
        };

        static void Main(string[] args)
        {

            Console.WriteLine("Все сотрудники:");
            var q1w = from x in w1 select x;
            foreach (var x in q1w) Console.WriteLine(x);

            Console.WriteLine("\nВсе отделы:");
            var q1b = from x in b1 select x;
            foreach (var x in q1b) Console.WriteLine(x);

            Console.WriteLine("\nСотрудники в отделе:");
            var q4bw = from x in b1
                       from y in w1
                     where x.id == y.branch_id
                     select y.id + " " + y.full_name + " " + x.name;
            foreach (var x in q4bw) Console.WriteLine(x);

            Console.WriteLine("\nСотрудники на букву И:");
            var w_with_N = from x in w1
                           where x.full_name[0] == 'И'
                           select x;
            foreach (var x in w_with_N) Console.WriteLine(x);

            Console.WriteLine("\nОтдел со всеми сотрудниками на букву А:");
            var w_all_A = from x in b1
                       from y in w1
                       where x.id == y.branch_id && y.full_name[0] == 'А'
                           select y.id + " " + y.full_name + " " + x.name;
            foreach (var x in w_all_A) Console.WriteLine(x);

            Console.WriteLine("\nСотрудники в отделах М-M");
            var MM = from x in b1
                       from y in w1
                       from z in bw1
                       where x.id == z.branch_id && z.worker_id == y.id
                       select y.id + " " + y.full_name + " " + x.name;
            foreach (var x in MM) Console.WriteLine(x);

            Console.ReadLine();
        }

    }
}
