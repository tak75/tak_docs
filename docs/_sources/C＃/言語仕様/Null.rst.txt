====
Null
====

引用元
======

* C#プログラミング 新スタイルによる実践的コーディング（川俣晶）

null許容型
==========

* null許容型は、実行速度が低下し（100倍近く低下）、メモリ使用量も増加するため、使用については要注意
* 以下のように、null を含む演算は null となる

  .. code-block:: csharp

    int? a = null, b = 123;
    Console.WriteLine((a + b) == null);   // この結果はTrueとなる

* null許容型を使用する場合は、以下のようにキャストではなく、Nullable<T>構造体メンバを使用する方がよい

  .. code-block:: csharp

    int? a = 123;
    if(a != null) m((int)a);    // △ : キャストを使った書き方
    if(a.HasValue) m(a.Value);  // ◎ : Nullable<T>構造体メンバを使った書き方

null合体演算子（??演算子）
==========================

* ??演算子は、1つ目が null でない場合はそれを採用し、null の場合は2つ目を評価して採用する機能を持つ
* 以下の例では、a が null の場合は DateTime.Now が採用される

  .. code-block:: csharp

    private static void dump(DateTime? a)
    {
      Console.WriteLine(a ?? DateTime.Now);
    }

null条件演算子（?）、null合体演算子（??）
=========================================

  .. code-block:: csharp

    var result3 = n?.ToString() ?? null;            // [1]
    var result3 = n.HasValue ? n.ToString() : null; // [2]

* [1][2]は同意である
* [2]の三項演算子を使用した場合は、n.HasValue の評価時には n!=null でも、n.ToString() の処理までに n=null となる可能性があり、その場合は例外をスローする
* [1]のnull条件演算子を使用した場合では、スレッドセーフとなっている

Null条件演算子?.および?[]
=========================

* C# 6.0からの仕様
* Null 条件付き演算子は、そのオペランドが null 以外と評価された場合にのみ、オペランドにメンバー アクセス操作 (?.) または要素アクセス操作 (?[]) を適用し、それ以外の場合は、null を返す

  .. code-block:: csharp
    
    double SumNumbers(List<double[]> setsOfNumbers, int indexOfSetToSum)
    {
        return setsOfNumbers?[indexOfSetToSum]?.Sum() ?? double.NaN;
    }

    var sum1 = SumNumbers(null, 0);
    Console.WriteLine(sum1);  // 出力:NaN

    var numberSets = new List<double[]>
    {
        new[] { 1.0, 2.0, 3.0 },
        null
    };

    var sum2 = SumNumbers(numberSets, 0);
    Console.WriteLine(sum2);  // 出力:6

    var sum3 = SumNumbers(numberSets, 1);
    Console.WriteLine(sum3);  // 出力:NaN
