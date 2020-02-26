==================
python 開発環境
==================

はじめに
==========

開発環境としては、以下の点でVisualStudioが最もよさそう（Windowsで開発し、RasPiに接続してリモートデバッグ）。

* リファクタリングができる（関数名変更など）
* リモートデバッグができる


リモートデバッグ
=================

WindowsのVisualStudioを使って、RasPi上のpythonコードをリモートデバッグする方法をご紹介します。

※ツール類は全部無償

-------------
用意するもの
-------------

* Win側

  * VisualStuido Express 2013(無償のやつ)
  * Python Tools for Visual Studio　2.1　（略称：PTVS）
    http://pytools.codeplex.com/
    ※Win側にもpythonをインストール済みのこと

* RasPi側

  * Python Tools for Visual Studio remote debugging server　2.1（略称：PTVSD）
    https://pypi.python.org/pypi/ptvsd
    ※pipで入れるもよし、落としたzip解凍してpython setup.py installもよし

    pipの例::

      sudo pip install ptvsd

-------
使い方
-------

1. RasPi上にある、デバッグしたいpyファイルの先頭に以下2行を追加（app.pyの先頭でよい）::

    import ptvsd
    ptvsd.enable_attach(secret = 'test')
    #'test' のところは任意のプロセス識別名

2. 上記ファイルをRasPiの共有フォルダにおくか、Win側にもコピーして VisualStudio（以降VS）で開き、好きにブレークポイントを設定

3. RasPi側で①のファイルを実行する（処理の先頭にinput()をおくなりして、一旦とまるようにしとく）

4. VSメニューの「デバッグ」→「プロセスにアタッチ」からダイアログ表示し、トランスポートの選択を"Python remote debugging"に、
   修飾子に"tcp://test@**.**.**.**"と入力すると、（testは①で決めたプロセス名。＠以降はRasPiのIPアドレス）
   選択可能なプロセスとしてリストアップされる

5. プロセスを選択して「アタッチ」すると、VS側でデバッグ実行状態になる

6. 3.で一旦停めていたRasPi側の処理を続行させると、以降はVS側でデバッグ実行（ちゃんとブレークポイントで止まる。変数の値も見える）。
