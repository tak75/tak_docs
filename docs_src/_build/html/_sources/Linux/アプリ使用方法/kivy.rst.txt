====
kivy
====

はじめに
=========

* python で開発するGUI
* スマホアプリやタッチパネル操作用アプリを作りたい場合にメリットあり
* PCで操作する機器制御用アプリは wxPython + wxGlade が作成が楽で使いやすい気がする

.. note::
   つまり、スマホでpythonのリモートプロシージャ？を使用して機器操作できる？

Kivyと依存パッケージの更新／インストール
========================================

`2 Kivyの導入 <https://www.closetoyou.jp/kivy/introduction-to-kivy02/>`__

::

  # kivy環境（仮想環境）に入る
  activate kivy

  # 既存パッケージアップデート
  pip install --upgrade pip wheel setuptools

  # 依存パッケージインストール
  pip install docutils pygments pypiwin32 kivy.deps.sdl2 kivy.deps.glew1Copy

  # kivy本体とサンプルアプリをインストール
  pip install kivy kivy_examples

サンプルアプリ実行
===================

::

  # kivy環境にて実施
  python C:\Users\i\Anaconda3\envs\kivy\share\kivy-examples\demo\showcase\main.py

.. _Atomエディタ_label:

Atomエディタ
==============

-------------------
Atomのインストール
-------------------

`3 Atomエディタの導入 <https://www.closetoyou.jp/kivy/introduction-to-kivy03/>`__

* Atom：`公式サイト <https://atom.io/>`__
* 追加パッケージ（メニューから、「File」→「Settings」を選択）

  * japanese-menu
  * autocomplete-python

    ローカルで完結する「Jedi」を選択

  * atom-runner
  * minimap

-------------------
プログラムの実行
-------------------

Anaconda Prompt を使う場合
----------------------------

Anaconda Promptを開き、kivy仮想環境に入った上で、「python “ファイル名”」と入力する::

  activate kivy

  # ファイルパスは例
  python C:\kivy_project\main.py

Atom の atom-runner を使う場合
--------------------------------

`4 Kvファイルを用いた簡単なアプリ作成  <https://www.closetoyou.jp/kivy/introduction-to-kivy04/>`__

Anaconda Promptを立ち上げてkivy仮想環境に入って、Prompt上からAtomを起動する::

  activate kivy

  # パスはAtomの実行ファイル
  C:\Users\i\AppData\Local\atom\atom.exe

続いて、Atom の atom-runner を使う。
Atomでmain.pyファイルを開いた状態で、「Altキー + r」を押す。
すると、作成したプログラムが実行され、ウィンドウが開く。

プログラムについて
===================

-----------
ファイル名
-----------

まず前提として、main.pyにて、Appクラスを継承したXxxAppという名称を持つクラスのrunメソッドを呼ぶ場合、自動的にxxx.kvというファイルが存在するかどうかを確かめ、あればそれを読み込む。
以下の例ではAppクラスを継承したクラス名がExpenseAppなので、expense.kvが読み込まれることになる。
大文字と小文字の区別に気を付けること。

**main.py** ::

  from kivy.app import App

  class ExpenseApp(App):
      pass

  if __name__ == '__main__':
      ExpenseApp().run()

**expense.kv** ::

  Label:
      text: "Expense App"

-------------
コメント方法
-------------

kvファイルでは、「#」にてコメント可能。
ただし、日本語コメントを入力すると **UnicodeDecodeError** となる。

https://qiita.com/EsseiK/items/9d87a16cc586957416c8

回避のために以下のファイル修正が必要。

ファイルパス::

  C:\Users\[ユーザー名]\Anaconda3\envs\[環境名]\Lib\site-packages\kivy\lang\builder.py

の288行目。

変更前::

  with open(filename, 'r') as fd:

変更後::

  with open(filename, 'r', encoding='utf8') as fd:

.. note::
   コメントをコードと同じ行に続けて書くとエラーになるみたい。
   独立行に書くと問題ない。

レイアウト作成
===============

`5 Kvファイルによる基本的なレイアウト作成 <https://www.closetoyou.jp/kivy/introduction-to-kivy05/>`__

`6 画面設計とKvファイルによる画面アウトラインの作成 <https://www.closetoyou.jp/kivy/introduction-to-kivy06/>`__

`7 Kvファイルを用いた文字入力欄とボタンの設置 <https://www.closetoyou.jp/kivy/introduction-to-kivy07/>`__

`8 Widgetの外観修正 <https://www.closetoyou.jp/kivy/introduction-to-kivy08/>`__

`9 日本語の表示方法 <https://www.closetoyou.jp/kivy/introduction-to-kivy09/>`__

エディタをShift-JISにする必要はなさそう？？

`10 画面遷移の実装方法その1 <https://www.closetoyou.jp/kivy/introduction-to-kivy10/>`__

`11 画面遷移の実装方法その1 <https://www.closetoyou.jp/kivy/introduction-to-kivy11/>`__

`12 ログイン失敗時のエラーメッセージ表示方法その1 <https://www.closetoyou.jp/kivy/introduction-to-kivy12/>`__

`13 ログイン失敗時のエラーメッセージ表示方法その2 <https://www.closetoyou.jp/kivy/introduction-to-kivy13/>`__

`14 経費申請画面の作成その1  <https://www.closetoyou.jp/kivy/introduction-to-kivy14/>`__

`15 経費申請画面の作成その2  <https://www.closetoyou.jp/kivy/introduction-to-kivy15/>`__

`16 プログラムのWindows実行ファイル化  <https://www.closetoyou.jp/kivy/introduction-to-kivy16/>`__
