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