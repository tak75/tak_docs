================
ReactiveProperty
================

注意事項
========

* メモリリーク
  
  自身が値を保持するだけの ReactiveProperty の場合は Dispose する必要は無いが、
  Subscribe 等で値の変更を監視しているような場合は Dispose しないとメモリリークする可能性がある。
  ようは、デリゲートを登録している場合ってことか？

* ReactiveCommandの引数

  ReactiveCommandの引数とCommandParameterにバインドする値の型が異なる場合は、コマンドが実行されない
  例 : 引数をstringにし、バインドをintにすると、コマンドは実行されない

UserControl（Navigation用）
===========================

--------
追加方法
--------

Viewsフォルダにて、追加→新しい項目→Prism→WPF→Prism UserControl(WPF)

----
雛形
----

  .. code-block:: csharp

    public class xxxViewModel : BindableBase, IDestructible, INavigationAware, IRegionMemberLifetime
    {
        #region メンバー変数 ----------------------------------------------------------------------------
        private IRegionManager _regionManager;
        private IEventAggregator _eventAggregator;
        private IRegionNavigationJournal _journal;
        private CompositeDisposable _disposables = new CompositeDisposable();
        #endregion

        #region プロパティ ------------------------------------------------------------------------------
        /// <summary>
        /// View が 非 Active になった際に View を保持するか否か（true:保持する、false:破棄する）
        /// </summary>
        public bool KeepAlive => false;
        #endregion

        #region コマンド --------------------------------------------------------------------------------
        /// <summary>
        /// BackボタンのCommand
        /// </summary>
        public ReactiveCommand ButtonBackCommand { get; }
        #endregion

        #region コンストラクタ --------------------------------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="eventAggregator"></param>
        public xxxViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this._regionManager = regionManager;
            this._eventAggregator = eventAggregator;

            // ■プロパティ初期化

            // ■プロパティの初期値設定

            // ■プロパティ変更時の処理

            // ■コマンド初期化
                
            // ■イベント送信処理
  
            // ■イベント受信処理
        }
        #endregion
        
        #region ボタンアクション ------------------------------------------------------------------------
        /// <summary>
        /// Backボタンアクション
        /// </summary>
        private void ButtonBackAction()
        {
            // 元の画面に戻る
            this._journal.GoBack();
        }
        #endregion

        #region インタフェース実装 ----------------------------------------------------------------------
        /// <summary>
        /// Viewを破棄する
        /// </summary>
        public void Destroy() => this._disposables.Dispose();

        // ナビゲーションが移る前にコールされる。
        // trueを返すと、このインスタンスが使いまわされる。
        // falseを返すと、別のインスタンスが作成される。
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        // ナビゲーションが他に移る時にコールされる。
        // 終了処理があればここに記述する
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        // ナビゲーションが移ってきた時にコールされる。
        // パラメータを受取りたい場合は、ここで navigationContext より取得できる
        // 本処理はコンストラクタ実行後に実行される処理である
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this._journal = navigationContext.NavigationService.Journal;

            // コール元から渡されたパラメータより、オブジェクトを受取る
            var obj = navigationContext.Parameters["obj"] as TestClass;
            if (obj != null)
            {
                this._obj= obj;
            }
            else
            {
                // 元の画面に戻る
                this._journal.GoBack();
            }

            // パラメータを渡して画面XXXを表示
            var param = new NavigationParameters();
            param.Add("obj", this._obj);
            this._regionManager.RequestNavigate("XXXRegion", nameof(XXX), param);
        }
        #endregion
    }


プロパティ初期化
================

  .. code-block:: csharp

    this.Value = new ReactivePropertySlim<Assay>(new Value())
        .AddTo(this._disposables);
        
    // 姓と名の変更を購読して、フルネームにする
    NameRorps = Observable
        .CombineLatest(NameRp, NameRps, (x, y) => $"{x}={y}")
        .ToReadOnlyReactivePropertySlim();

    // オブジェクトのプロパティ（ReactiveProperty型）からReactivePropertyを生成する方法
    // オブジェクトの参照先が変わる場合は、オブジェクトもReactiveProperty型である必要がある
    this.ProjectStatus = this.Project
        .ObserveProperty(x => x.Value.StatusRP.Value)
        .ToReadOnlyReactivePropertySlim()
        .AddTo(this._disposables);

    this.Assay = dataContext.Assay
        .ToReactivePropertySlimAsSynchronized(x => x.Value)
        .AddTo(this._disposables);

    this.MotFileName = this.MeasurementUnitSelected
        .ObserveProperty(x => x.Value.MotFilePath.Value)
        .Select(x => Path.GetFileName(x))
        .ToReadOnlyReactivePropertySlim()
        .AddTo(this._disposables);


プロパティ変更時の処理
======================

  .. code-block:: csharp

    this.PropertyX
        .Subscribe(x =>
        {
            this._eventAggregator.GetEvent<NotifyXXXEvent>().Publish(x);
        });
        

    // コレクション内の特定のプロパティが変化した場合
    // 監視するプロパティが ReactiveProperty の場合に ObserveElementObservableProperty() が使用可
    this.PrepareInfoCollection
        .ObserveElementObservableProperty(x => x.StateName) 
        .Subscribe(x => 
        {
            // 全てのプレートIDが、キャリブレーションA用プレートセット状態である場合にStartボタンを活性化させる
            var count1 = this.PrepareInfoCollection.Count();
            var count2 = this.PrepareInfoCollection.Where(x => x.StateName.Value == StateNames.CalibA_PlateSet).Select(x => x).Count();
            this.CanStart.Value = (count1 == count2) ? true : false;
        });
        
    // グラフ情報変更時の処理（置き換え時）
    this.WellIsCheckedCollection
        .ObserveReplaceChanged()
        .Subscribe(_ => GraphInfoChanged());	// 引数は変化した値であり、インデックス情報は取得できない？
        
    // エラーログコレクション変更時の処理（追加時）
    this.ErrorLogCollection
        .ObserveAddChanged()
        .Subscribe(_ => this._errorLogCollectionChanged?.Invoke());

    //リアルタイムフィルタリング
    TemplateList.ObserveElementProperty(x => x.Remarks.Value).Subscribe(_ => FilterdList.Refresh());
    TemplateList.ObserveAddChanged().Subscribe(_ => FilterdList.Refresh());
    TemplateList.ObserveAddChanged().Subscribe(_ => FilterdList.Refresh());


コマンド初期化
==============

  .. code-block:: csharp

    // 基本
    this.BackCommand = new ReactiveCommand()
        .WithSubscribe(() => BackAction())
        .AddTo(this._disposables);
        
    // ファイル名が入力されたらボタンを活性化
    this.OKCommand = this.FileName
        .Select(x => !(string.IsNullOrEmpty(x)))    // 空欄の場合はボタン非活性
        .ToReactiveCommand()
        .WithSubscribe(() => OKAction())
        .AddTo(this._disposables);
        
    // アッセイがnullでなく、プロジェクト名が空欄でない場合にボタンを活性化
    this.StartCommand = this.Assay
        .CombineLatest(this.ProjectName, (x,y) => (x != null) && !string.IsNullOrEmpty(y))
        .ToReactiveCommand()
        .WithSubscribe(() => ButtonStartActionAsync())
        .AddTo(this._disposables);

    // プロジェクトがIdle状態の場合のみボタンを活性化
    // this.ProjectStatus を Model.GetInstance().CurrentProject.Value.StatusRP に置き換えることは不可
    // この書き方では、CurrentProjectの参照先が変わった場合に古いインスタンスのStatusRPを参照し続けることとなる
    this.LoadTemplateCommand = Model.GetInstance().CurrentProject
        .CombineLatest(this.ProjectStatus, (x, y) => y == ProjectStatuses.Idle)
        .ToReactiveCommand()
        .WithSubscribe(() => ButtonLoadTemplateAction())
        .AddTo(this._disposables);
        
    this.UpdateFWCommand = this.MeasurementUnitSelected
        .ObserveProperty(x => x.Value.UpdatingFW.Value)			// ←これ重要
                                                                // （x => x.Value.UpdatingFW　だとダメ）
        .Select(x => !x)
        .ToReactiveCommand()
        .WithSubscribe(async () => {})
        .AddTo(this._disposables);

イベント送信処理
================

  .. code-block:: csharp

    this._eventAggregator.GetEvent<NotifyXXXEvent>().Publish(x);

イベント受信処理
================

  .. code-block:: csharp

    this._eventAggregator.GetEvent<NotifyXXXEvent>()
        .Subscribe(x =>
        {
        });

イベント定義
============

  .. code-block:: csharp

    // Power Off を通知
    public class NotifyPowerOffEvent : PubSubEvent
    {
    }

    // 数値を通知
    public class NotifyNumberEvent : PubSubEvent<int>
    {
    }

ReactiveCollectionの追加/削除処理をUIスレッド上で行う方法
==========================================================

AddOnScheduler()、RemoveOnScheduler()を使用する。
これにより、ReactiveCollectionをBinding設定にしていても、例外が発生しなくなる。
それでも発生する場合は、Binding先のVMに以下を記述する。

  .. code-block:: csharp

    // 複数スレッドからコレクション操作できるようにする
    BindingOperations.EnableCollectionSynchronization(Binding元のコレクション, new object());

ボタンの連打を抑制
==================

AsyncReactiveCommandを使用し、戻り値がTaskのメソッドをWithSubscribe()に設定することで、
メソッド実行完了までボタンを非活性化し、ボタンの連打を抑制できる。

  .. code-block:: csharp

    public AsyncReactiveCommand ButtonStartCommand { get; }
    
    this.ButtonStartCommand = this.Assay
        .CombineLatest(this.ProjectName, (x,y) => (x != null) && !string.IsNullOrEmpty(y))
        .ToAsyncReactiveCommand()
        .WithSubscribe(() => ButtonStartActionAsync())
        .AddTo(this._disposables);

    private async Task ButtonStartActionAsync(){}	// ←Taskである必要あり


