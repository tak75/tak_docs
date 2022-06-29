============
VisualStudio
============

ショートカット
==============

https://baba-s.hatenablog.com/entry/2017/09/22/100000

.. csv-table:: ショートカット
  :header-rows: 1
  :widths: 1, 2

  ショートカット,説明
  Ctrl + Shift + F,検索
  F12,変数などの定義位置に移動
  Shift + F12,変数などが使用されている箇所を列挙
  Ctrl + F12,インタフェースのメソッドを実装している箇所（クラス）を列挙
  Ctrl + Shift + Space,パラメータヒント
  Ctrl + K -> Ctrl + F,インデント整形
  Ctrl + ],ブロック終端移動
  Alt + Shift + Enter,全画面表示
  Ctrl + Shift + B,ビルド

コードスニペット
=================

構文を入力し、Tabを2回押すことで雛型を入力してくれる

リファクタリング
=================

.. csv-table:: ショートカット
  :header-rows: 1
  :widths: 1, 3

  ショートカット,説明
  Ctrl + R -> Ctrl + E,フィールドのカプセル化（フィールドをプロパティに変更し、変更したプロパティを使用するように更新する）
  Ctrl + R -> Ctrl + R,リネーム

タスク・リスト機能
==================

以下は標準の内容である。

.. csv-table:: タスク・リスト機能
  :header-rows: 1
  :widths: 1, 4

  キーワード,説明
  TODO,未実装のため、新たにコードを追加する必要がある個所
  HACK,実装済みだが、コードをさらに改善する必要がある個所
  UNDONE,未完成のため、さらにコードを編集する必要がある個所

カスタム定義することも可能。

.. csv-table:: カスタム定義例
  :header-rows: 1
  :widths: 1, 4

  キーワード,説明
  NOTE,注意書き等のメモ

使用しているOSS情報の出力方法
=============================

Nugetパッケージマネージャーコンソールで、以下のコマンドを入力する。

.. code-block:: console

  >Get-Package | Select-Object Id,version,LicenseUrl

