Recently
========

==================
ReactiveExtensions
==================

* `Hot/Coldの挙動について <https://qiita.com/toRisouP/items/f6088963037bfda658d3>`__
* イベントとしての使用例
  
  .. code-block:: csharp

    private Subject<System.Reactive.Unit> _OnEventA;
    private Subject<System.Reactive.Unit> _OnEventB;
    private Subject<System.Reactive.Unit> _OnEventC;

    _OnEventA = new Subject<System.Reactive.Unit>().AddTo(_disposables);
    _OnEventA.Subscribe(_ => EventHandlerA1()).AddTo(_disposables);
    _OnEventA.Subscribe(_ => EventHandlerA2()).AddTo(_disposables);
    _OnEventC = _OnEventA.Merge(_OnEventB);
    _OnEventA.OnNext(System.Reactive.Unit.Default); 

* `マウスダウン、マウスアップ、マウスムーブ <https://blog.okazuki.jp/entry/20111124/1322145011>`__

================
ReactiveProperty
================

* AsyncReactiveCommand
  
  .. code-block:: csharp

    public AsyncReactiveCommand ButtonStartCommand { get; }

    ButtonStartCommand = this.RP1
        .ObserveProperty(x => x.Value.RP1_1.Value).ToReactiveProperty().AddTo(_disposables)
        .CombineLatest(this.RP2, this.RP1.ObserveProperty(x => x.Value.RP1_2.Value).ToReactiveProperty().AddTo(_disposables)
                        , (x, y, z) => (!x) && (y) && (z!= null))
        .ObserveOnUIDispatcher().ToAsyncReactiveCommand()
        .WithSubscribe(async () => await ButtonStartActionAsync())
        .AddTo(_disposables);

* `ReactivePropertyを使ってバリデーションエラーを表示する #C# - Qiita <https://qiita.com/takapi_cs/items/7e8438123f3f0bf3aae8>`__

====
Xaml
====

* `Xaml Runの使い方 <https://www.pine4.net/Memo/Article/Archives/429>`__

  * Run要素間に改行が含まれると表示されるテキストの項目間に空白(スペース)が表示されます。
  * <Run>要素のテキストの間でスペースが含まれないようにするには、次のように<Run>要素間に改行が含まれないようにします。

  .. code-block:: XML

    <Run Text="平成"></Run><Run Text="25"></Run>

===
C#
===

* usingステートメント

  * https://qiita.com/4_mio_11/items/145c658078a7fe5f36a7
  * C#8.0からは以下のように、変数宣言時にusingをつけ簡略化すること可能
 
    .. code-block:: csharp

      static void Main(string[] args)
      {
          using var fs = new FileStream("hoge.txt", FileMode.Open, FileAccess.Read, FileShare.None);
          Console.WriteLine(fs.Length);   
      }    

* `record型 <https://qiita.com/shimamura_io/items/80982b11ce41eca03e10>`__

  * C#9.0からの機能
  * 値ベースでインスタンス比較ができる
  * C#10.0からレコード構造体が追加（それまで参照型）
  * レコード構造体は record struct と書く
  * 参照型のレコードは record もしくは、record class と書く
 
* with 式

  * レコード／構造体／匿名型で使用可能
  * 一部の値が異なるコピー（新しいオブジェクト）を生成することができる
  * ただし、浅いコピーなので、参照型メンバは参照アドレスのコピーとなるので要注意
  
    .. code-block:: csharp

      record PersonRecord
      {
          public string Name { get; init; }
          public int Age { get; init; }
      }

      var p1 = new PersonRecord { Name = "Tanaka", Age = 20 };
      var p2 = p1 with {Name = "Suzuki"};
      var p3 = p1 with {};    // p1のコピーが作成される（p1とは別のオブジェクト）

* 読み取り専用コレクション

    .. code-block:: csharp

      ReactiveCollection<DataItem> _dataList;
      object _dataListLock = new();
      public IEnumerable<DataItem> DataList
      {
          get
          {
              lock (_dataListLock)
              {
                  return _dataList.ToList();
              }
          }
      }
      // 下記でもよいが、IReadOnlyList は IEnumerable から派生したインタフェースであるので、
      // より上位であるIEnumerableで使用上問題ないのであれば、IEnumerableを使用した方がよい。
      // ただし、[index]によるアクセスが必要である場合は下記が必要
      public IReadOnlyList<DataItem> DataList
      {
          get
          {
              lock (_dataListLock)
              {
                  return _dataList.ToList().AsReadOnly();
              }
          }
      }

* async/await

  * async メソッドは、最初の await に達すると制御を返す

    .. code-block:: csharp

      var task = AsyncMethod();
      Console.WriteLine("Started");
      task.Wait();
      Console.WriteLine("Completed");
      
      static async Task AsyncMethod()
      {
          await Task.Delay(1000);
          Console.WriteLine("AsyncMethod");
          await Task.Delay(1000);
      }

      // 出力結果
      // Started
      // AsyncMethod
      // Completed

* Task.Yield

  * Yield メソッドは、何の機能も持たず、ただ、待っている他の処理に実行チャンスを与える

    .. code-block:: csharp

      var task = subB();
      for (int i = 0; i < 10; i++)
      {
          Console.Write(i.ToString()+", ");
      }
      await task;
            
      async Task subB()
      {
          int x = 0;
          for (int i = 0; i < int.MaxValue; i++)
          {
              x += Random.Shared.Next();
              if (x % 100 == 0) await Task.Yield();
          }
      }

      // 出力結果
      // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9,

====
LINQ
====

* 

====
全般
====

*  ヘルパークラスとは、スタティックメソッドだけを持っていて、状態を内包しない「構造体」
