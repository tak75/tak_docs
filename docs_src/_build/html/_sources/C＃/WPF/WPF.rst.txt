===
WPF
===

Viewについての便利メモ
======================

xamlに以下の4 行を追加すると、土台となる UserControl が指定したサイズで表示されるようになるため、デザイン時に実行時のイメージがつかみやすくなる。

.. code-block:: xaml

    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    mc:Ignorable="d"
    d:DesignHeight="500" d:DesignWidth="500"

Dispatcherについて
==================

* Viewで使用する場合

  * オブジェクト（例listBox1）.Dispatcher.～を使う

* VMで使用する場合

  * Application.Current.Dispatcher.～を使う
  * Application.Current.Dispatcherは常にUIスレッドのディスパッチャを提供
  * これは唯一のApplicationインスタンスを起動するスレッドだからである

エラーメッセージ
================

------------------------------------------------
他のスレッドで作成されているためアクセスできない
------------------------------------------------

* ViewにバインドするオブジェクトはUIスレッドで作成する必要がある。
* Task.Run()など、他のスレッド上で生成している場合にエラーとなる。

Viewの中にViewを配置する方法
============================

-----------------------
RequestNavigateで配置
-----------------------

パラメータを渡すことはできるが、DependencyPropertyではない（値が変更されても通知されない？）
パラメータが参照型で、かつ受け取ったViewがReactivePropertyなどでパラメータを定義しておけば問題ない？

.. code-block:: csharp

  var param = new NavigationParameters();
  param.Add("property1", Property1);

  // view1を配置
  this._regionManager.RequestNavigate("XXXRegion", nameof(View1), param);

------------
xaml内に配置
------------

Messageプロパティは、View1のコードビハインドでDependencyPropertyとして定義必要

.. code-block:: xaml

  <Grid x:Name="grid">
      <Grid.RowDefinitions>
          <RowDefinition Height="Auto"/>
          <RowDefinition/>
      </Grid.RowDefinitions>

      <TextBlock Grid.Row="0" Text="Test Message"/>
      <v:View1 Message = "aaaaa"/>
  </Grid>

----------------------
コードビハインドで配置
----------------------

xaml

.. code-block:: xaml

  <Grid x:Name="grid">
      <Grid.RowDefinitions>
          <RowDefinition Height="Auto"/>
          <RowDefinition/>
      </Grid.RowDefinitions>

      <TextBlock Grid.Row="0" Text="Test Message"/>
      // ※ここにview1を配置する
  </Grid>

コードビハインド

.. code-block:: csharp

	var _view1 = new View1();
	_view1.Message.Value = "aaaaa"; // view1のpublicなフィールドやプロパティを直接設定できる
                                        // （②に対するメリット？）
	Grid.SetRow(_view1, 1);
	this.grid.Children.Add(_view1);
