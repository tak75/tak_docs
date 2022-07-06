=====
LINQ
=====

引用元
======

* C#プログラミング 新スタイルによる実践的コーディング（川俣晶）
* C#プログラムの効率的な書き方 LINQ to Objectsマニアックス（川俣晶）

用語
====

.. glossary::

  LINQ

    Language Integrated Query の略。統合言語クエリ。
    文字列で記述されたクエリでは、その誤りは実行時に初めてエラーとして検出されるが、
    言語に統合されたクエリでは、エラーをコンパイル時に検出できるメリットがある。
    LINQは、元々.NET Framework 3.5 のクラスライブラリでサポートされたクラスライブラリである。
    そして、C#3.0で言語に統合された。
    C#4.0では、Parallel LINQ が導入され、マルチコアでの並列分散処理が容易に書けるようになった。

  LINQ To Objects

    .NET Framework のオブジェクトに対して問合せを行う技術。

IEnumerable -> List 変換
========================

  .. code-block:: csharp

    var list = enumerableCollection.ToList();

2次元 -> 1次元 変更
===================

  .. code-block:: csharp

    list1dm = list2dm
      .SelectMany(x => x)
      .OrderBy(x => x.Index)  // OrderByは必要に応じて、かつIndexなどで順番を管理していれば
      .ToList();

辞書型
======

* 辞書型コレクションの値を重複なく取り出し昇順に並び替えリスト化

  .. code-block:: csharp
   
    var groupList = this.SampleDict
      .Select(x => x.Value)
      .Distinct()
      .OrderBy(x => x);       // 昇順に並び替える

* 2次元辞書のデータを全て列挙

  .. code-block:: csharp
   
    public Dictionary<Sensor, Dictionary<int, double>> Data { get; set; }
    this.Data.Values.SelectMany(x => x.Values).Where(x => x.Flag).ToList();

インデックスリストの取得
========================

  .. code-block:: csharp

    // グループチェックされているインデックスリスト
    var indexes = this.GroupIsCheckedCollection
      // 以下は.Select((Value, Index) => new { Value, Index }) でもOK
      .Select((v, i) => new { Value = v, Index = i }) 
      .Where(x => x.Value == true)
      .Select(x => x.Index);

その他参考例
============

  .. code-block:: csharp

    // COMリストの数だけ、接続確認等の処理に使用するデバイスリストを作成する
    // tempDeviceは、タプル内要素に付けた名前
    var comList = MakeComList()
      .Select(comNo => (comNo, tempDevice:new DeviceCommunication(1)))
      .ToList();

    // 接続失敗したCOM番号について、各リストから削除する
    taskList.Where(task => task.Result.result == false)
      .Select(task => comList.Remove
      (
        comList.FirstOrDefault(com => com.comNo == task.Result.comNo)
      ));