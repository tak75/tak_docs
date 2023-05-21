=====
yield
=====

引用元
======

* C#プログラミング 新スタイルによる実践的コーディング（川俣晶）

yield return 例
===============

  .. code-block:: csharp

    class Program
    {
        static void Main(string[] args)
        {
            var range = new Range(1, 10); // ①
            foreach (int i in range)      // ②
            {
                Console.WriteLine(i);
            }
        }
    }

    class Range
    {
        private int from, to;
        public IEnumerator<int> GetEnumerator()   // クラス内に1つ書いておくと、列挙されるみたい
        {
            for (int i = from; i <= to; i++)
            {
                yield return i;   // ←これが実行されるのは②のタイミング
            }
        }
        public Range(int from, int to) 
        {
            this.from = from;
            this.to = to;
        }
    }
