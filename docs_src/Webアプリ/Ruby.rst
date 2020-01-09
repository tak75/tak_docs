====
Ruby
====

Rubyのバージョン管理コマンド（Cloud9のコマンドラインで入力し使用）
=================================================================

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
    
