.. _python_APIドキュメント作成_label:

============================
python API ドキュメント作成
============================

はじめに
==========

pythonソースでは、docstring形式でコメントを入力することで、sphinxでAPIドキュメント出力を行うことができる。

操作方法
=========

---------------------
プロジェクト新規作成
---------------------

以下のディレクトリ構成を例に説明する::

  - project # Pythonプロジェクト
    |
    |- src # APIドキュメントを自動生成したいPythonコードのディレクトリ
    |   |- __init__.pyとか
    |   |- hoge # サブモジュールとか
    |
    |- docs # Sphinxプロジェクトのディレクトリ

docsディレクトリにAPIドキュメント用のSphinxプロジェクトを作成::

  cd project
  sphinx-apidoc -F -o docs/ src/

---------------
conf.pyの修正
---------------

conf.pyファイル内のコメントを外し以下のように追記する::

  # If extensions (or modules to document with autodoc) are in another directory,
  # add these directories to sys.path here. If the directory is relative to the
  # documentation root, use os.path.abspath to make it absolute, like shown here.
  #
  import os
  import sys
  sys.path.insert(0, 'Z:\BBB\GyroViewer\GyroViewer')

conf.pyファイルに以下を追記する::

  # インポートエラーとなるモジュールがあると以降のビルドが中止されてしまうため、
  # インポートエラーとなるモジュールをあらかじめ知らせておくことでエラーを防止する
  autodoc_mock_imports = [
    'ptvsd',
    'smbus',
    'ConfigParser']

  # privateを含めたMethodの表示
  autodoc_default_flags = [
    'members',
    'private-members'
  ]

-------
ビルド
-------

通常のsphinxと同様::

  cd docs
  make html

docstring
=========

以下のように記述する::

  """
  Sample機能提供モジュール
  
  """
 
  class Sample:
      """ 
      sample機能を実装したクラスです。
      """
  
      bar = 1
      """ xxを保持するメンバです """
  
      #: yyを保持するメンバです
      foo = 1
  
      def __init__(self):
          """ 
          初期化処理を行います。
          """
          self.x = 'hoge'
  
  
  
      def add(self, arg1, arg2):
          """ 
          引数で指定した値を足し算して返します。``arg1 + arg2`` 
          
          :param int arg1: 足される値。
          :param arg2: 足す値。
          :type arg2: int 
          :rtype: int
          :return: 足し算した結果。
          """
          return a + b 


