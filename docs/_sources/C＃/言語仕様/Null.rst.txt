====
Null
====

引用元
======

* 

null合体演算子（??演算子）
==========================

??演算子は、1つ目がnullでない場合はそれを採用し、nullの場合は2つ目を評価して採用する機能を持つ。
以下の例では、aがnullの場合はDateTime.Nowが採用される。

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

[1][2]は同意である。
[2]の三項演算子を使用した場合は、n.HasValueの評価時にはn!=nullでも、
n.ToString()の処理までにn=nullとなる可能性があり、その場合は例外をスローする。
[1]のnull条件演算子を使用した場合では、スレッドセーフとなっている

null許容型使用時の留意点
========================

以下のように、nullを含む演算はnullとなる点に留意すること。

  .. code-block:: csharp

    int? a = null, b = 123;
    Console.WriteLine((a + b) == null);   // この結果はTrueとなる

null許容型を使用する場合は、以下のようにキャストではなく、Nullable<T>構造体メンバを使用する方がよい。

  .. code-block:: csharp

    int? a = 123;
    if(a != null) m((int)a);    // △ : キャストを使った書き方
    if(a.HasValue) m(a.Value);  // ◎ : Nullable<T>構造体メンバを使った書き方
