====
xaml
====

最初に準備すべきこと
====================

xamlに以下の4 行を追加すると、土台となる UserControl が指定したサイズで表示されるようになるため、デザイン時に実行時のイメージがつかみやすくなる。

.. code-block:: xaml

    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    mc:Ignorable="d"
    d:DesignHeight="500" d:DesignWidth="500"

コードビハインドのプロパティをバインドする方法
==============================================

* CLRプロパティやDependencyPropertyはViewインスタンス（上でいう子View）に属するもの
* VMのプロパティはDataContextに設定された別インスタンスに属するもの

である。
Viewで自身のCLRプロパティやDependencyPropertyをバインドする場合は、バインドデータに以下の記載が必要

.. code-block:: xaml

  RelativeSource={RelativeSource AncestorType=UserControl}

RelativeSourceの使用例
======================

* 自分の親をさかのぼり最初のExpanderのActualWidthを自分のWidthにバインディングする

  .. code-block:: xaml

    Width="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type Expander}}, Path=ActualWidth}"


Region名のバインディングについて
================================

RegionNameはバインディングすることはできるが、バインディングしている名前を途中で変更してはいけない。
例外が発生する。

様々なイベントへのバインディング
================================

.. code-block:: xaml

  xmlns:i="http://schemas.microsoft.com/xaml/behaviors"
  xmlns:interactivity="clr-namespace:Reactive.Bindings.Interactivity;assembly=ReactiveProperty.WPF"

  <ComboBox ItemsSource="{Binding ComList}" SelectedItem="{Binding ComSelected.Value}">
      <i:Interaction.Triggers>
          <i:EventTrigger EventName="DropDownOpened">
              <interactivity:EventToReactiveCommand Command="{Binding ComboBoxDropDownOpendCommand}"/>
          </i:EventTrigger>
      </i:Interaction.Triggers>
  </ComboBox>

バインドした値がNullやなしの場合の挙動設定
==========================================

* Value=null、もしくは、Value.Project.Value=null の場合は、FallbackValueが実行される
* Value.Project.Value.MeasurableRemainingTime.Value=null の場合は、TargetNullValueが実行される

.. code-block:: xaml

  Text="{Binding Value.Project.Value.MeasurableRemainingTime.Value, TargetNullValue='-', FallbackValue='--'}"

