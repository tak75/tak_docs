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
