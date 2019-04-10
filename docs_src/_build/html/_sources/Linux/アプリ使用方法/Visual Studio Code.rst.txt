==================
Visual Studio Code
==================

はじめに
==========

使用実績は以下の通り

* sphinxでのreSTファイル作成

.. note:: python開発環境としては使いにくい。名前変更のリファクタリングができない。

インストール
=============

Raspberry Pi へのインストールは以下の通り::

  # インストール
  wget -O - https://code.headmelted.com/installers/apt.sh | sudo bash

  # 実行
  メニュー -> プログラミング -> Code-OSS

仮想環境構築
=============

----------------------------------
VS codeのターミナルを使用する場合
----------------------------------

仮想環境を作成する（仮想環境名 = kivyの場合）::

  py -m venv kivy

仮想環境を作成したら、コマンドパレットで「interpreter」などと入力して［Python: インタープリターを選択］コマンドを実行して、
今作成した仮想環境を選択しておく（これにより、ワークスペース設定のpython.pythonPath項目の値が、作成した仮想環境に含まれるpythonコマンドに設定される）。
（少々時間を要する）

--------------------
condaを使用する場合
--------------------

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

以下のように入力すると、環境専用の Anaconda Prompt を作成できるみたい
（https://www.kunihikokaneko.com/dblab/toolchain/python27.html）::

  conda create --name py27 python=2.7 Anaconda

Python開発環境構築
====================

-----------------
各種インストール
-----------------

https://qiita.com/84zume/items/27d143f529396c9fa1cc

* Python拡張インストール
* Lint（PyLint）インストール::

    pip install pylint

  pylintを利用する設定（ファイル→基本設定→設定）ができているかを念のため確認::

    // Whether to lint Python files.
    "python.linting.enabled": true,
    // Whether to lint Python files using pylint.
    "python.linting.pylintEnabled": true,

-----------
ユーザ設定
-----------

https://qiita.com/Atupon0302/items/ee3303629ce0b2ae58d7

ファイル -> 基本設定 -> 設定::

  {
    // 左のファイルツリーに表示させないファイル拡張子
    "files.exclude": {
        "**/*.pyc": true,
        "**/*.pyproj": true,
        "**/Makefile": true,
        "**/*.bat": true,
        "**/_build": true,
        "**/_static": true,
        "**/_templates": true,
        "**/.vscode": true,
    },
    // 空白文字の表示
    "editor.renderWhitespace": "all",
    "editor.detectIndentation": true,
    "editor.tabSize": 2,
    // pylintへのパスを設定
    "python.linting.pylintPath": "C:/Users/i/Anaconda3/Lib/site-packages/pylint/epylint.py",
    // pythonへのパスを設定
    "python.pythonPath": "C:/Users/i/Anaconda3/python.exe",
  }

---------------------
ワークスペースの設定
---------------------

ファイル -> 基本設定 -> 設定::

  {
    "folders": [
      {
        "path": "C:\\Users\\i\\Google ドライブ\\tak_doc",
        "editor.tabSize": 2,
      },
      {
        "path": "Z:\\BBB\\GyroViewer\\GyroViewer",
        "editor.tabSize": 4,
      }
    ],
    "settings": {
      "restructuredtext.workspaceRoot": "c:\\Users\\i\\Google ドライブ\\tak_doc"
    },
  }
