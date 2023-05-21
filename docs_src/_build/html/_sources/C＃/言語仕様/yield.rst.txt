=====
yield
=====

引用元
======

* C#プログラミング 新スタイルによる実践的コーディング（川俣晶）

説明
====

* 「yield retrun 文」と「yield break 文」を含むブロックは「反復子ブロック」であり、すぐには実行されず、その代わりに列挙子オブジェクトが生成される
* 反復子ブロックを途中で抜けるには、「yield break 文」を使用する
* 特定の型を返す GetEnumerator という名前の public なメソッドは、それだけで列挙可能とみなされる
* 「yield retrun 文」は、try～catch 構文の中で使用できない。
  ただし、「yield break 文」は使用できるし、「yield retrun 文」もtry～finally 構文の中では使用できる

yield return 例1
================

  .. code-block:: csharp

    class Range
    {
        private int from, to;
        public IEnumerator<int> GetEnumerator()   // public な GetEnumerator という名のメソッドは、それだけで列挙可能とみなされる
        {
            for (int i = from; i <= to; i++)
            {
                yield return i;   // ←これが実行されるのは[2]のタイミング
            }
        }
        public Range(int from, int to) 
        {
            this.from = from;
            this.to = to;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var range = new Range(1, 10); // [1]
            foreach (int i in range)      // [2]
            {
                Console.Write(i);
            }
        }
    }

yield return 例2
================

  .. code-block:: csharp

    class Sample
    {
        public IEnumerator<int> GetEnumerator() 
        {
            yield return 1;   // [1]  
            yield return 2;   // [2]
            yield return 3;   // [3]
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in new Sample())
            {
                Console.Write(i); // [4]
            }
            // 出力:123
            // [1],[4],[2],[4],[3],[4]の順で実行される
        }
    }

1クラスに複数の列挙機能を付ける
===============================

  .. code-block:: csharp

    class Sample
    {
        private int[] array = { 1, 2, 3 };

        public IEnumerator<int> GetEnumerator() 
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
        public IEnumerable<int> GetReverseOrder()   // ←IEnumerable型であることに注意
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                yield return array[i];
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            foreach (int i in new Sample())
            {
                Console.Write(i);
            }
            // 出力:123

            foreach (int i in new Sample().GetReverseOrder())
            {
                Console.Write(i);
            }
            // 出力:321
        }
    }

クラスではなくメソッド定義で列挙オブジェクトを作成してもよい
============================================================

  .. code-block:: csharp

    class Program
    {
        private static IEnumerable<int> GetCounter(int from, int to)
        {
            for(int i = from; i <= to; i++) yield return i;
        }

        static void Main(string[] args)
        {
            foreach (int i in GetCounter(1,3))
            {
                Console.Write(i);
            }
            // 出力:123
        }
    }

