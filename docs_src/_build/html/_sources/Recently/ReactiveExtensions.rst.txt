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
