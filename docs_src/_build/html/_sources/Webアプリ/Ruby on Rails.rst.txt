=============
Ruby on Rails
=============

はじめに
========

* RoR, Railsと呼ばれることもある
* `公式サイト <https://rubyonrails.org/>`__
* `Ruby on Rails ガイド <https://railsguides.jp/>`__
* RubyGems

  * 幅広いライブラリが"gem"という形式で公開されている
  * RubyGemsは、ライブラリの作成や公開、インストールを助けるシステム
  * `gemを探す <https://rubygems.org/>`__

開発環境構築
============

* AWS Cloud9を使用する
* rubyのバージョンを確認する

  .. code-block:: console
  
    $ ruby -v
    ruby 2.6.3p62 (2019-04-16 revision 67580) [x86_64-linux]

* railsをバージョンを指定してインストールする

  .. code-block:: console
  
    // --no-documentはドキュメントなしでインストールする場合
    $ gem install rails --version="5.1.4" --no-document

* railsのバージョンを確認する

  .. code-block:: console
  
    $ rails -v
    Rails 5.1.4

* sqlite3のバージョンを確認する

  .. code-block:: console
  
    $ sqlite3 --version
    3.7.17 2013-05-20 00:56:22 118a3b35693b134d56ebd780123b7fd6f1497668

新規railsプロジェクトの作成
===========================

* Cloud9 作業1

  .. code-block:: console
  
    // バージョンを指定して"hello"プロジェクトを新規作成する
    $ rails _5.1.4_ new hello

    // 必要な"bundle"ライブラリをインストールする
    $ bundle install

* ファイル修正::

    プロジェクト内の"Gemfile"ファイルを開き、以下のように修正する。
    これにより、使用するsqlite3のバージョンを指定する。

    【変更前】 gem 'sqlite3'
    【変更後】 gem 'sqlite3', '~> 1.3.6'
  
* Cloud9 作業2

  .. code-block:: console

    // "bundle"ライブラリをアップデートする
    $ bundle update

    // DBを作成する
    $ rails db:create

    // RailsのWebサーバ(puma)を起動する（引数の"s"はサーバを意味する）
    $ rails s

* "hello"コントローラを作成する

  .. code-block:: console

    // hello : コントローラの名前
    // index : アクションメソッドの名前
    // generateは"g"と省略可能
    $ rails generate controller hello index
    Running via Spring preloader in process 8361
      create  app/controllers/hello_controller.rb
       route  get 'hello/index'
      invoke  erb
      create    app/views/hello
      create    app/views/hello/index.html.erb
      invoke  test_unit
      create    test/controllers/hello_controller_test.rb
      invoke  helper
      create    app/helpers/hello_helper.rb
      invoke    test_unit
      invoke  assets
      invoke    coffee
      create      app/assets/javascripts/hello.coffee
      invoke    scss
      create      app/assets/stylesheets/hello.scss

* 上記で作成されるファイルについて

  * .erb
  
    Embedded Ruby の略。テンプレートエンジン

* ルーティング設定は、config->routes.rbに記載される
* ルーティング設定を確認する

  .. code-block:: console

    $ rails routes
    Prefix Verb URI Pattern            Controller#Action
    hello_index GET  /hello/index(.:format) hello#index

    // 出力内容について
    // /hello/indexにアクセスすると、helloコントローラのindexアクションがコールされるの意

* ルートURLにアクセスした場合のアクションを定義するには、routes.rbにて、

  .. code-block:: ruby

    Rails.application.routes.draw do
    #   get 'hello/index'
        root 'hello#index'
    end