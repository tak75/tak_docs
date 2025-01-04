Recently
========

==================
ReactiveExtensions
==================

* `Hot/Coldの挙動について <https://qiita.com/toRisouP/items/f6088963037bfda658d3>`__

  * Cold Observable

    * 自発的に何もしない受動的なObservable
    * Observerが登録されて（Subscribeされて）初めて仕事を始める
    * ストリームの前後をただつなぐだけ。ストリームを枝分かれさせる機能は無い
 
  * Hot  Observable

    * 自分から値を発行する能動的なObservable
    * 後続のObserverの存在に関係なしにメッセージを発行する
    * 自分より上流のCold Observableを起動し、値の発行を要求する機能を持つ
    * 下流のObserverを全て束ね、まとめて同じ値を発行する（ストリームを枝分かれさせる）

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

* Subjectの種類

  * Subject

   * OnNext()で値を通知
   * 現在値は保持されないし直接取得もできない
   * 値が通知された時のみSubscribe()で取得可能

  * ReplaySubject

   * OnNext()で値を通知
   * 全ての値が保持される
   * Subscrive()登録時にこれまで保持されてきた値を全て通知

  * BehaviorSubject

   * OnNext()で値を通知
   * 現在値は保持されているが、直接取得することはできない？
   * Subscribe()登録時に現在値を通知

* SubjectとReactivePropertyの違い

  * Subject
    
   * 現在値は保持されないし直接取得もできない
   * 値が通知された時のみSubscribe()で取得可能

  * ReactiveProperty
    
   * 現在値を直接取得できる
   * デフォルトmodeでは、
 
     * Subscribe()登録時に現在値を通知（BehaviorSubjectと同じ）
     * 直前と同じ値の場合は通知しない

* IConnectableObservable

  * Pulish()にて、ColdなIObservableをHotに変換する
  * Connect()でストリーム稼働開始

  .. code-block:: csharp

    var subject = new Subject<string>();

    //subjectから生成されたObservableは【Hot】
    var sourceObservable = subject.AsObservable();

    //ストリームに流れてきた文字列を連結するストリーム
    //Scan()は【Cold】
    var stringObservable = sourceObservable
        .Scan((p, c) => p + c)
        .Publish(); //Hot変換オペレータ

    stringObservable.Connect(); //ストリーム稼働開始

    //ストリームに値を流す
    subject.OnNext("A");
    subject.OnNext("B");

    //ストリームに値を流した後にSubscribe
    StringObservable.Subscribe(Console.WriteLine);

    //Subscribe後にストリームに値を流す
    subject.OnNext("C");

    //完了
    subject.OnCompleted();

  .. code-block:: csharp

    // 実行結果
    // ABC

* Subscribe内で例外発生するとSubscribeはDisposeされその後呼ばれなくなる

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

* ReactivePropertyMode

  .. code-block:: csharp

    // Defaultは、RaiseLatestValueOnSubscribe | DistinctUntilChanged
    // Subscribe時イベント発行 : ○
    // 同値上書き時イベント発行 : x
    private ReactivePropertySlim<int> _count1 = new();

    // Subscribe時イベント発行 : x
    // 同値上書き時イベント発行 : ○
    private ReactivePropertySlim<int> _count2 = new(mode:ReactivePropertyMode.None);

    // Subscribe時イベント発行 : ○
    // 同値上書き時イベント発行 : ○
    private ReactivePropertySlim<int> _count3 = new(mode: ReactivePropertyMode.RaiseLatestValueOnSubscribe);

    // Subscribe時イベント発行 : x
    // 同値上書き時イベント発行 : x
    private ReactivePropertySlim<int> _count4 = new(mode: ReactivePropertyMode.DistinctUntilChanged);

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

* ObserveOn

  * イベント元に関わらず、専用スレッドでSubscribe処理が実行される（非同期処理）
  * イベント発行後の最後？に処理される
  
    .. code-block:: csharp

      // 内部のイベント処理用のスケジューラを専用に持たせる
      // ThreadPoolは利用しないことを明確にする
      var scheduler = new EventLoopScheduler(a => new Thread(a) { Name = "{_aaa}", IsBackground = true });

      _ = _device.OnHogeEventFired
          .ObserveOn(scheduler)
          .Subscribe(arg =>
          {
          }

* イベントの書き方の王道

    .. code-block:: csharp

      public abstract class HogeBase : IDisposable
      {
        protected Subject<HogeEvent> _onHogeEventFired { get; } = new();
        public IObservable<HogeEvent> OnHogeEventFired => _onHogeEventFired;
        public virtual void Dispose() => _onHogeEventFired.Dispose();
      }

      // イベント引数を持たせるよりも、イベントとして分けた方が拡張性が高い
      // ・各イベントに引数を持たすことができる
      // ・イベントでフィルタリングできる
      public abstract class HogeEvent();
      public class Hoge1Event() : HogeEvent;
      public class Hoge2Event() : HogeEvent;

* イベントが発行されるまで待機する方法

    .. code-block:: csharp

      public async Task WeighZero()
      {
        using var cts = new CancellationTokenSource();
        using var _ = _device.WeighZero().Subscribe(_ => cts.Cancel());
        try
        {
            await Task.Delay(Timeout.InfiniteTimeSpan, cts.Token);
        }
        catch (TaskCanceledException) { }
      }

* lock ステートメントはあくまで「スレッド間」を排他するものであり、同じスレッドの再帰的な動きには効果がない

* `ifの条件部分で変数定義する <https://zenn.dev/trs_game/articles/5c4a52d87f69c2>`__
 
    .. code-block:: csharp

      if (inventory.GetItem(id) is var item && item != null)
      {
          DoFuga(item);
      }

* `プロパティのパターンマッチング <https://qiita.com/emoacht/items/dc1c40769dc6cdc1ef44>`__
 
    .. code-block:: csharp

      if (p is { X: 10, Y: 10 })
      if (p is { X: 10, Y: > 0 })
      
      // 下記2つは同じ意味
      if (p is { X: 10, Y: _ })
      if (p is { X: 10 })

      // 下記2つは同じ意味
      if (p is { })
      if (p is not null)

* `スプレッド(spread)演算子 <https://ufcpp.net/study/csharp/datatype/collection-expression/>`__

    .. code-block:: csharp

      // コレクション式中では、.. を使うことで「別のコレクションの中身の展開」ができる
      int[] array1 = [1, 2, 3];
      int[] array2 = [4, 5, 6];

      // 0, 1, 2, 3, 4, 5, 6, 7
      int[] combined = [0, ..array1, ..array2, 7];

* `async/awaitのキャンセル処理まとめ <https://qiita.com/toRisouP/items/60673e4a39319e69fbc0>`__

* Moq

    .. code-block:: csharp

      public void XXXTest()
      {
        var productMock = new Mock<IProduct>();
        productMock.Setup(x => x.GetData()).Returns("AAA");
        Assert.AreEqual("AAA", ModuleB.GetValue(productMock.Object));
      }


* Unity（DIコンテナ）→非推奨になっている

    .. code-block:: csharp

      var vm = DI.Resolve<Form1ViewModel>();

      internal class Form1ViewModel()
      {
        private IProduct _product;
        internal Form1ViewModel(IProduct product)
        {
          _product = product;
        }
      }

      internal static class DI
      {
        private static IUnityContainer _container = new UnityContainer();

        static DI()
        {
          // 型の登録
          _container.RegisterType<IProduct, Product>();
        }

        internal static T Resolve<T>()
        {
          return _container.Resolve<T>();
        }
      }

* Microsoft.Extensions.DependencyInjection（DIコンテナ）→推奨

    .. code-block:: csharp

      var vm = DI.GetService<Form1ViewModel>();

      internal class Form1ViewModel()
      {
        private IProduct _product;
        internal Form1ViewModel(IProduct product)
        {
          _product = product;
        }
      }

      internal static class DI
      {
        private static ServiceCollection _container = new ServiceCollection();
        private static ServiceProvider _serviceProvider;

        static DI()
        {
          _container.AddSingleton<Form1ViewModel>();
        
          // 型の登録
          _container.AddTransient<IProduct, Product>();

          _serviceProvider = _container.BuildServiceProvider();
        }

        internal static T GetService<T>()
        {
          // GetRrequiredServiceは例外
          // GetServicesはNullが返る
          return _serviceProvider.GetRequiredService<T>();
        }
      }

* Observerパターン

  * 以下のように呼ばれることもある

    * Subject/Observer パターン
    * Pulish/Subscribe パターン

* eventキーワードの意味

    .. code-block:: csharp

      public static class WarningTimer
      {
        public static Action<bool> WarningAction1;

        // eventを付けることでカプセル化され直接代入できなくなる
        // +=/-=でしか設定できなくなる
        public static event Action<bool> WarningAction2;
      }


      public static class Form
      {
        public Form()
        {
          WarningTimer.WarningAction1 = Func;   // ← OK
          WarningTimer.WarningAction2 = Func;   // ← コンパイルエラー
          WarningTimer.WarningAction2 += Func;  // ← OK
        }
      }

* event追加時のチェック方法

    .. code-block:: csharp

      private static Action<bool> _warningAction;

      public static void Add(Action<bool> action)
      {
        if(_warningAction == null)
        {
          return;
        }

        // 既に登録されている場合は何もしない
        if(_warningAction.GetInvocationList().Contains(action))
        {
          return;
        }
        _warningAction += action;
      }

* AutoResetEventについて

  * Set()するとシグナル状態となる
  * シグナル状態ではWaitOne()を実行してもスルーされ、スレッドは止まらない（次のWaitOne()で止まる）
  * なので、ある判定の結果WaitOne()されることとなったが、WaitOne()のコードを実行される前にSet()が実行された場合でも、スレッドは停止されない

* PadLeft
  
  * string型数字文字列において、指定した文字数になるように左側から特定の文字で埋めることができる

    .. code-block:: csharp

  		var originalString = "123";
  		var paddedString = originalString.PadLeft(5, '0');
  		Console.WriteLine(paddedString); // 出力: "00123"

====
LINQ
====

* 

====
全般
====

*  ヘルパークラスとは、スタティックメソッドだけを持っていて、状態を内包しない「構造体」

* `モック・スタブ・ドライバ の違い <https://www.qbook.jp/column/1864.html>`__

  * スタブ ⊃ モック（モックはスタブの一種）
  * ドライバは「呼び出す側（上位モジュール）」、スタブは「呼び出される側（下位モジュール）」を代替
  * モックとスタブでは利用の目的が違う。スタブは「上位モジュールを動かすため」に使われる一方、モックは「上位モジュールの出力を検証するため」に使われる

* 完全コンストラクタパターン

  * クラスが保持するプロパティを全てコンストラクタで設定する
  * プロパティはgetのみで書き換え不可であり、クラスインスタンス生成後書き換えられていないことが保証される