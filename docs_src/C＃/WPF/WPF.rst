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

