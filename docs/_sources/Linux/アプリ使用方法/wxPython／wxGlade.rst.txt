==================
wxPython／wxGlade
==================

インストール
=============

---------
wxPython
---------

Windows環境
-------------

http://nippori30.hatenablog.com/entry/2017/09/15/111936

anaconda prompt を開き、pipでインストールする::

  pip install wxPython

Linux環境
-----------

LXTerminal を開き::

  # python2環境へインストール
  sudo pip install wxPython

  # python3環境へインストール（これだと失敗？）
  sudo pip3 install wxPython

--------
wxGlade
--------

以下のページより最新版を入手する。

https://sourceforge.net/projects/wxglade/

zipの場合は解凍後、wxglade.pywを実行する。
（ショートカットを作成し、スタートメニューに入れておけばよい）

インストーラの場合はインストーラを実行する。
（インストーラの役割は、解凍しショートカットをスタートメニューに登録してくれるだけ。多分）

使い方
=======

* wxGlade でGUIを作成し、ソースを出力する
* 出力したソース（BaseFrame.py）のクラス（BaseFrame）を継承したクラスを作成し、BaseFrame.py内の空のメソッドを全てコピーする