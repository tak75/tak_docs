================================
ReactiveExtensionsメソッドリスト
================================

* 参考：`UniRx オペレータ逆引き <https://qiita.com/toRisouP/items/3cf1c9be3c37e7609a2f>`__

ファクトリメソッド
==================

.. list-table:: IObservableのファクトリメソッド（Observable.XXX）
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - `3 <https://blog.okazuki.jp/entry/20111104/1320409976>`__
     - :term:`Return`
     - 
     - 値を1つだけ発行
     - 
   * - `3 <https://blog.okazuki.jp/entry/20111104/1320409976>`__
     - :term:`Repeat`
     - .. figure:: images/Repeat.png
     - 同じ値を指定した回数発行
     - 
   * - `3 <https://blog.okazuki.jp/entry/20111104/1320409976>`__
     - :term:`Range`
     - .. figure:: images/Range.png
     - 指定した値から1ずつカウントアップした値を指定した数だけ発行
     - 
   * - `3 <https://blog.okazuki.jp/entry/20111104/1320409976>`__
     - :term:`Generate`
     - .. figure:: images/Generate.png
     - * 指定した範囲の値を用いて算出される値を返す(:math:`1^2、2^2、3^2`)
       * インターバル指定できる
     - 
   * - `3 <https://blog.okazuki.jp/entry/20111104/1320409976>`__
     - :term:`Defer`
     - .. figure:: images/Defer.png
     - * 任意の値を返す
       * Observableの定義をSubscribe時まで遅延させる
     - 
   * - `3 <https://blog.okazuki.jp/entry/20111104/1320409976>`__
     - :term:`Create`
     - .. figure:: images/Create.png
     - * 任意の値を返す
       * 値を発行するObservableを自分で好きなように作る
     - 
   * - `3 <https://blog.okazuki.jp/entry/20111104/1320409976>`__
     - :term:`Throw`
     - .. figure:: images/Throw.png
     - * 疑似的にエラーを起こす
       * OnErrorを直ちに発行
     - 
   * -
     - :term:`Empty_`
     - .. figure:: images/Empty.png
     - OnCompleted直ちに発行
     - 
   * -
     - :term:`Never`
     - .. figure:: images/Never.png
     - 何も起きないObservableを定義
     - 

.. list-table:: Timer系のファクトリメソッド（Observable.XXX）
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - `4 <https://blog.okazuki.jp/entry/20111106/1320584830>`__
     - :term:`Timer`
     - .. figure:: images/Timer.png
     - * 一定間隔で値（実行回数）を発行
       * 一定時間後に値を発行（Delay）
     - 
   * - `4 <https://blog.okazuki.jp/entry/20111106/1320584830>`__
     - :term:`Interval`
     - .. figure:: images/Interval.png
     - 一定間隔で値（実行回数）を発行
     - 
   * - `4 <https://blog.okazuki.jp/entry/20111106/1320584830>`__
     - :term:`Generate`
     - .. figure:: images/Generate.png
     - 任意の時間間隔で、指定した範囲の値を用いて算出される値を返す
     - 
   * -
     - :term:`TimerFrame`
     - 
     - * 一定フレーム間隔で値を発行
       * 指定フレーム後に値を発行
     - 
   * -
     - :term:`IntervalFrame`
     - 
     - 一定フレーム間隔で値を発行
     - 

.. list-table:: HotなIObservableを作成するファクトリメソッド
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - | `6 <https://blog.okazuki.jp/entry/20111109/1320849106>`__
       | `9 <https://blog.okazuki.jp/entry/20111124/1322145011>`__
     - | :term:`FromEvent`
       | :term:`FromEventPattern`
     - .. figure:: images/FromEvent.png
     - 「C#標準のイベント」をIObservable<T>に変換
     - 
   * - `6 <https://blog.okazuki.jp/entry/20111109/1320849106>`__
     - :term:`Start`
     - .. figure:: images/Start.png
     - バックグラウンドで処理を実行し結果を返す
     - 
   * - `6 <https://blog.okazuki.jp/entry/20111109/1320849106>`__
     - :term:`ToAsync`
     - 
     - バックグラウンドで任意のタイミングで処理を実行し結果を返す
     - 
   * - `6 <https://blog.okazuki.jp/entry/20111109/1320849106>`__
     - :term:`FromAsyncPattern`
     - 
     - 
     - 

フィルタリングメソッド
======================

.. list-table:: フィルタリングメソッド
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - `7 <https://blog.okazuki.jp/entry/20111110/1320849106>`__
     - :term:`Where_`
     - 
     - 条件式を満たすものだけ通す
     - 
   * - 
     - :term:`Distinct_`
     - .. figure:: images/Distinct.png
     - 重複したものを除く
     - 
   * - 
     - :term:`DistinctUntilChanged`
     - .. figure:: images/DistinctUntilChanged.png
     - 値が変化した時のみ通す
     - 
   * - `28 <https://blog.okazuki.jp/entry/20120202/1328107196>`__
     - | :term:`Throttle`
       | :term:`ThrottleFrame`
     - .. figure:: images/Throttle.png
     - * まとめて流れてきたOnNextの最後だけ通す
       * 指定した間、新たな値が発行されなかったら最後に発行された値を後続に流す
     - TextBoxの入力が終わって1秒後に自動で検索処理を実行などで使う
   * - 
     - | :term:`ThrottleFirst`
       | :term:`ThrottleFirstFrame`
     - .. figure:: images/ThrottleFirst.png
     - まとめて流れてきたOnNextの最初だけ通す
     - 
   * - 
     - | :term:`First_`
       | :term:`FirstOrDefault_`
     - .. figure:: images/First.png
     - 一番最初に到達したOnNextのみを流してObservableを完了
     - 
   * - 
     - | :term:`Single_`
       | :term:`SingleOrDefault_`
     - 
     - OnNextが2つ以上発行されたらエラー
     - 
   * - 
     - | :term:`Last_`
       | :term:`LastOrDefault_`
     - .. figure:: images/Last.png
     - Observableの最後の値だけを通す
     - 
   * - `8 <https://blog.okazuki.jp/entry/20111113/1321191314>`__
     - :term:`Take_`
     - .. figure:: images/Take.png
     - 先頭から指定した個数だけ通す
     - 指定した個数を通したらすぐにOnCompleted()
   * - `8 <https://blog.okazuki.jp/entry/20111113/1321191314>`__
     - :term:`TakeWhile_`
     - .. figure:: images/TakeWhile.png
     - * 先頭から条件が成り立たなくなるまで通す
       * 条件が成立したらすぐにOnCompleted()
     - TakeWhile(i => i < 10)
   * - | `8 <https://blog.okazuki.jp/entry/20111113/1321191314>`__
       | `9 <https://blog.okazuki.jp/entry/20111124/1322145011>`__
     - :term:`TakeUntil`
     - .. figure:: images/TakeUntil.png
     - * 先頭から指定したObservableにOnNextが来るまで通す
       * 引数がIObservable
     - TakeUntil(IObservable<TOther> other)
   * - `8 <https://blog.okazuki.jp/entry/20111113/1321191314>`__
     - :term:`Skip_`
     - .. figure:: images/Skip.png
     - 先頭から指定した個数無視
     - 
   * - `8 <https://blog.okazuki.jp/entry/20111113/1321191314>`__
     - :term:`SkipWhile_`
     - .. figure:: images/SkipWhile.png
     - * 先頭から条件が成り立つ間は無視
       * 条件が成立したらすぐにOnCompleted()（その後条件が成立しなくなっても後続に流す）
     - SkipWhile(i => i < 5)
   * - | `8 <https://blog.okazuki.jp/entry/20111113/1321191314>`__
       | `9 <https://blog.okazuki.jp/entry/20111124/1322145011>`__
     - :term:`SkipUntil`
     - .. figure:: images/SkipUntil.png
     - * 先頭から指定したObservableにOnNextが来るまで無視
       * 引数がIObservable
     - SkipUntil(IObservable<TOther> other)
   * - 
     - :term:`OfType<T>`
     - 
     - 型が一致するもののみ通す(型変換も同時に行う)
     - 
   * - 
     - :term:`IgnoreElements`
     - .. figure:: images/IgnoreElements.png
     - OnErrorまたはOnCompletedのみを通す
     - 

.. list-table:: Observable自体の合成メソッド
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * -
     - :term:`Amb`
     - .. figure:: images/Amb.png
     - 複数のObservableのうち一番早くメッセージが来たObservableを採用
     - 
   * - `link <https://atmarkit.itmedia.co.jp/fdotnet/introrx/introrx_02/introrx_02_03.html>`__
     - :term:`Zip_`
     - .. figure:: images/Zip.png
     - 複数のObservableにそれぞれ1つずつメッセージが来たらそれらを合成して流す
     - 
   * - 
     - :term:`ZipLatest`
     - .. figure:: images/ZipLatest.png
     - 複数のObservableにそれぞれ1つ以上メッセージが来たらそれらを合成して流す(それぞれのObservableの最新のメッセージのみを保持)
     - 
   * - `link <https://atmarkit.itmedia.co.jp/fdotnet/introrx/introrx_02/introrx_02_03.html>`__
     - :term:`CombineLatest`
     - .. figure:: images/CombineLatest.png
     - 複数のObservableのどれかに値が来たら他のObservableの過去の値と合成して流す
     - 
   * - 
     - :term:`WithLatestFrom`
     - .. figure:: images/WithLatestFrom.png
     - 2つのObservableのうち片方を主軸にし、片方のObservableの最新値を合成
     - 
   * - `link <https://atmarkit.itmedia.co.jp/fdotnet/introrx/introrx_02/introrx_02_03.html>`__
     - :term:`Merge`
     - .. figure:: images/Merge.png
     - 複数のObservableを1本にまとめる
     - 
   * - `link <https://atmarkit.itmedia.co.jp/fdotnet/introrx/introrx_02/introrx_02_03.html>`__
     - :term:`Concat_`
     - .. figure:: images/Concat.png
     - ObservableのOnCompleted時に別のObservableを繋ぐ
     - 
   * - `link <https://atmarkit.itmedia.co.jp/fdotnet/introrx/introrx_02/introrx_02_03.html>`__
     - :term:`SelectMany_`
     - .. figure:: images/SelectMany.png
     - * Observableの値を使って別のObservableを作り、それぞれの値を合成
       * メッセージの値を元に別のObservableを呼び出してそちらの結果を利用
     - 
   * - 
     - :term:`Catch`
     - .. figure:: images/Catch.png
     - 複数のObservableを成功するまで順番に実行
     - 
   * - `link <https://atmarkit.itmedia.co.jp/fdotnet/introrx/introrx_02/introrx_02_03.html>`__
     - :term:`Scan`
     - .. figure:: images/Scan.png
     - 
     - 

.. list-table:: Observable自体の変換メソッド
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - 
     - :term:`ToReactiveProperty`
     - 
     - ObservableをReactivePropertyに変換
     - 
   * - 
     - :term:`ToReadOnlyReactiveProperty`
     - 
     - ObservableをReadOnlyReactivePropertyに変換
     - 
   * - 
     - :term:`ToYieldInstruction`
     - 
     - コルーチンでObservableを待つ
     - 

.. list-table:: Observableの分岐メソッド
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - 
     - :term:`Publish`
     - 
     - Observableを枝分かれさせる
     - Publishの返り値はIConnectabaleObservable。Multicast(Subject)と同義
   * - 
     - :term:`ToReactivePropety`
     - 
     - Observableを枝分かれさせる
     - 
   * - 
     - :term:`Publish`
     - 
     - Observableを枝分かれさせつつ、初期値を指定
     - 引数を与えるとMulticast(BehaviorSubject)と同義
   * - 
     - :term:`PublishLast`
     - .. figure:: images/PublishLast.png
     - Observableを枝分かれさせ、その際にObservableの最後の値のみをキャッシュ
     - Multicast(AsyncSubject)と同義
   * - 
     - :term:`Replay`
     - .. figure:: images/Replay.png
     - Observableを枝分かれさせ、その際に今までに発行された全てのOnNextをキャッシュ
     - Multicast(ReplaySubject)と同義
   * - 
     - :term:`Multicast`
     - 
     - Observableを枝分かれさせる時にSubjectを指定
     - 
   * - 
     - :term:`RefCount`
     - .. figure:: images/RefCount.png
     - Observerが1つでもいたらConnectし、いなくなったらDispose
     - Publish().RefCount()はほぼ定型文
   * - 
     - :term:`Share`
     - 
     - Publish().RefCount()を省略
     - 

.. list-table:: メッセージ同士の合成・演算
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - 
     - :term:`Scan`
     - .. figure:: images/Scan.png
     - メッセージの値と前回の結果との両方を使い関数を適用
     - LINQでいうAggregate
   * - 
     - :term:`Buffer`
     - .. figure:: images/Buffer.png
     - * メッセージを一定個数ごとにまとめる
       * あるObservableにメッセージが来るまで値を塞き止めてまとめる
     - * 第二引数を指定することで挙動が変わる
       * 引数にObservableを渡す
   * - 
     - :term:`PairWise`
     - 
     - 直前のメッセージとセットにする
     - Bufer(2,1)と挙動は似ている

.. list-table:: メッセージの変換
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - `7 <https://blog.okazuki.jp/entry/20111110/1320849106>`__
     - :term:`Select`
     - 
     - 値を変換/値に関数を適用する
     - 他の言語だとmap
   * -
     - :term:`Cast<T>`
     - 
     - 型変換をする
     - 
   * -
     - :term:`Materialize`
     - .. figure:: images/Materialize.png
     - メッセージにイベントのメタ情報を付与
     - OnNext/OnError/OnCompletedのどれであるかを示す情報を付与
   * -
     - :term:`TimeInterval`
     - .. figure:: images/TimeInterval.png
     - 前回のメッセージからの経過時間を付与
     - 
   * -
     - :term:`TimeStamp`
     - .. figure:: images/TimeStamp.png
     - メッセージにタイムスタンプを付与
     - 
   * -
     - :term:`AsUnitObservable`
     - 
     - メッセージをUnit型に変換
     - Select(_=>Unit.Default)と同義

.. list-table:: 時間に絡んだ処理
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - `29 <https://blog.okazuki.jp/entry/20120203/1328274110>`__
     - :term:`Delay`
     - .. figure:: images/Delay.png
     - メッセージを時間遅延させる。特定の時点までの遅延も可能
     - 
   * - 
     - :term:`DelayFrame`
     - 
     - メッセージを時間遅延させる
     - 
   * - 
     - :term:`Timeout`
     - .. figure:: images/Timeout.png
     - * 最後にOnNextが発行されてから一定時間以内に次のOnNextが来なかったらOnErrorを発行
       * Subscribeしてから一定時刻までにOnCompletedが来なかったらOnErrorを発行
     - 
   * - `27 <https://blog.okazuki.jp/entry/20120201/1328107196>`__
     - :term:`Sample`
     - .. figure:: images/Sample.png
     - * 指定した間隔（時間や任意のタイミング）で最後に発行された値を後続に流す
       * サンプリングする
     - 非同期処理が終わったタイミングや、ボタンのクリックイベントなどをトリガーにして、一番最後に発行された値を後続に流せる

.. list-table:: 非同期処理
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - 
     - 
     - 
     - 
     - 

.. list-table:: メソッドリスト
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - `10 <https://blog.okazuki.jp/entry/20111128/1322491648>`__
     - :term:`Do`
     - .. figure:: images/Do.png
     - IObservableのシーケンスを処理する ``途中に`` 任意のアクションを実行（途中ではなく最後にアクションを実行する場合はSubscribeを使用する）
     - 本来は外部に対して副作用を起こさないReactive Extensionsの処理の中で副作用を起こすためのメソッドとなるため、Doメソッドの利用は必要最低限にとどめることが推奨

.. list-table:: 集計を行うメソッドリスト(Cold)
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - `17 <https://blog.okazuki.jp/entry/20111212/1323698319>`__
     - :term:`Aggregate`
     - .. figure:: images/Aggregate.png
     - 収集・集計し、OnCompleted()で結果のみを後続に流す
     - 
   * - `17 <https://blog.okazuki.jp/entry/20111212/1323698319>`__
     - :term:`Scan`
     - .. figure:: images/Scan.png
     - 収集・集計し、OnNext()の都度、集計経過を後続に流す
     - 

.. list-table:: 時間に関する情報を付与するTimestampとTimeIntervalメソッド
   :header-rows: 1
   :widths: 1, 3, 10, 6, 6

   * - link
     - メソッド
     - 図
     - 説明
     - 備考
   * - `31 <https://blog.okazuki.jp/entry/20120205/1328450809>`__
     - :term:`Timestamp`
     - .. figure:: images/Timestamp.png
     - タイムスタンプを追加する
     - 

.. list-table:: その他メソッドリスト
   :header-rows: 1
   :widths: 1, 3, 6, 6

   * - link
     - メソッド
     - 説明
     - 備考
   * - `link <https://qiita.com/toRisouP/items/f6088963037bfda658d3>`__
     - Publish
     - Cold->Hot変換
     - 
   * - `9 <https://blog.okazuki.jp/entry/20111124/1322145011>`__
     - Finally
     - * IObservableのシーケンスが終了したタイミングで処理を実施
       * OnCompletedだけでなく、OnError時（例外発生時）にも実行される
       * SubscribeのOnCompletedとOnErrorに同じ処理を記載するのと同等？
     - Finally(() => 処理)
