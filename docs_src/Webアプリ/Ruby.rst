====
Ruby
====

概要
====

* Ruby

  日本人が開発したプログラミング言語。

* Ruby on Rails

  Rubyで書かれたWebアプリケーションフレームワーク

Rubyのバージョン管理コマンド（Cloud9のコマンドラインで入力し使用）
==================================================================

* 現在のRubyのバージョンを表示する

  .. parsed-literal::

    $ ruby -v

    //出力例
    ruby 2.3.8p459 (2018-10-18 revision 65136) [x86_64-linux]

* 現在インストールされているRubyのバージョンリストを表示する

  .. parsed-literal::

    $ rvm list
    
    //出力例
       ruby-2.3.1 [ x86_64 ]
    => ruby-2.3.8 [ x86_64 ]
     * ruby-2.6.3 [ x86_64 ]

    # => - current
    # =* - current && default
    #  * - default

* 特定のバージョンをインストールする

  .. parsed-literal::

    $ rvm install 2.3.4
    
* 特定のメジャーバージョンの最新版をインストールする

  .. parsed-literal::

    $ rvm install 2.3   // 2.3.x の最新版がインストールされる

* 特定のバージョンを使用する

  .. parsed-literal::

    $ rvm use 2.6.3
    
* 特定のバージョンをアンインストールする

  .. parsed-literal::

    $ rvm remove 2.3.1
    
* 特定のバージョンをデフォルトで使用するバージョンに設定する

  .. parsed-literal::

    $ rvm --default 2.6.3
    
開発環境
========

* AWS Cloud9を使用する

Rubyを動かす方法
==================

* irbを使う

  * Interactive Rubyの略
  * 対話型
  * Cloud9のコマンドラインで以下のように入力し使用する

    .. parsed-literal::

      $ irb       // 開始時
      > exit      // 終了時

* ファイルに保存したプログラムを実行する

  * ファイル拡張子は.rb
  * Cloud9のコマンドラインにて、実行ファイルのディレクトリに移動（cd）した上で、以下を入力し実行する

    .. parsed-literal::
  
      $ ruby xxx.rb   // xxx.rbはファイル名

言語仕様
========

-------
文字列
-------

* 文字列を囲う記号は「ダブルクォート""」と「シングルクォート''」の2種がある。
  両者で実行結果が異なるので要注意。

  .. code-block:: ruby

    first_name = 'Hanako'
    last_name = 'Yamada'

    # ダブルクォート""では、特殊文字や式展開が行われる
    # 以下の実行結果は、「My name is Hanako Yamada」
    puts "My name is #{first_name} #{last_name}"

    # シングルクォート''では、特殊文字や式展開が行われない
    # 以下の実行結果は、「My name is #{first_name} #{last_name}」
    puts 'My name is #{first_name} #{last_name}'
  
* 破壊的メソッド

  文字列操作メソッドの末尾に"!"を付けることで、対象の文字列自体を操作し変更することができる。

  .. code-block:: ruby

    s = 'Hello World!'
    puts s.upcase     # "HELLO WORLD!"と出力される
    puts s            # "Hello World!"と出力される
    puts s.pucase!    # "HELLO WORLD!"と出力される
    puts s            # "HELLO WORLD!"と出力される（対象の文字列自体が変更された）

--------
条件分岐
--------

if文
----

* if/elsif/else/end の並び。

unless文
--------

* unless/else/end の並び。
* "elsif"に相当するものはない。

  .. code-block:: ruby

    n = 0
    unless n.zero?
      puts '0ではありません'
    else
      puts '0です'
    end

case文
------

* case/when/else/end の並び。

  .. code-block:: ruby

    stone = 'garnet'
    case stone
    when 'ruby'
      puts '7月'
    when 'peridot'
      puts '8月'
    when 'sapphire'
      puts '9月'
    else 
      puts 'データが登録されていません'
    end

----
関数
----

.. code-block:: ruby

  # 例1
  # 引数がない場合は括弧()は不要
  def hello_world
    puts 'Hello World!'
  end

  # 例2
  def add(a, b)
    a + b       # 返り値に "return" は不要。あってもエラーにはならない。
  end

----------------------
puts,print,p メソッド
----------------------

.. parsed-literal::

  // putsメソッドは改行あり。戻り値はnil
  2.5.0 :001 > puts 'nakamura'
  nakamura
  => nil 

  // printメソッドは改行なし。戻り値はnil
  2.5.0 :002 > print 'nakamura'
  nakamura => nil 

  // pメソッドはデバッグ用。戻り値は引数のオブジェクト
  2.5.0 :003 > p 'nakamura'
  "nakamura"
  => "nakamura" 

-------
その他
-------

* nil

  何も存在しないことを意味する値。nullと同意？

* インクリメント"++"やデクリメント"--"はrubyにはない。代わりに"+="と"-="を使う。

* 