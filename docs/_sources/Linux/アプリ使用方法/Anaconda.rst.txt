========
Anaconda
========

はじめに
==========

* Windows環境でpythonをインストールしたい場合、Anaconda3 を利用するのがベスト。
* 仮想環境をいろいろと構築でき、例えば Python2.7 と 3.6 の環境を構築することも可能（ :ref:`仮想環境構築_label` ）。
  この場合、スタートメニュー->全てのプログラム->Anaconda3の中に、Anaconda Prompt と Anaconda Prompt(py27) が作成される。
  各々の環境に入り、pip install などを行うことで、各々の環境にパッケージをインストール可能となる。

.. _仮想環境構築_label:

仮想環境構築
=============

https://www.closetoyou.jp/kivy/introduction-to-kivy01/

仮想環境を作成する（仮想環境名 = kivy、pythonバージョン = 3.6 の場合）::

  conda create -n kivy python=3.6

仮想環境一覧表示し作成を確認::

  conda info -e

仮想環境に入る::

  activate kivy

仮想環境から抜ける::

  deactivate

仮想環境の削除::

  conda remove -n py36 --all

補足
====

https://www.kunihikokaneko.com/dblab/toolchain/python27.html

環境専用の Anaconda Prompt を作成する？方法は以下の通り::

  conda create --name py27 python=2.7 Anaconda

