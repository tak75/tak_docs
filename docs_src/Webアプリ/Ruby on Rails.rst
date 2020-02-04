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

新規プロジェクトの作成
======================

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

* Preview->Preview Running Applicationを選択し、表示される画面の右上↗ボタンを押すことで、Webアプリ画面が表示される

コントローラの作成
==================

* "Tasks"コントローラを作成する（複数形であることに注意）

  .. code-block:: console

    // "g" はgenerateの略で、"generate"と記述してもOK
    $ rails g controller Tasks
    create  app/controllers/tasks_controller.rb    // 重要！
    invoke  erb
    create    app/views/tasks
    invoke  test_unit
    create    test/controllers/tasks_controller_test.rb
    invoke  helper
    create    app/helpers/tasks_helper.rb
    invoke    test_unit
    invoke  assets
    invoke    coffee
    create      app/assets/javascripts/tasks.coffee
    invoke    scss
    create      app/assets/stylesheets/tasks.scss

    // 以下のように末尾にパラメータを1つ付けて、アクションメソッドを作成
    // することも可能
    // 以下の例では"index"という名のアクションメソッドが作成される
    $ rails g controller Tasks index

* 上記で作成されるファイルの内"app/controllers/tasks_controller.rb"が特に重要

モデルの作成
============

* "Task"モデルを作成する（単数形であることに注意）

  .. code-block:: console

    // "title"はタスクの名前を保持するカラム
    // "done"はタスクの完了状態を保持するカラム
    $ rails g model Task title:string done:boolean
    invoke  active_record
    create    db/migrate/20200204121345_create_tasks.rb   // 重要！
    create    app/models/task.rb                          // 重要！
    invoke    test_unit
    create      test/models/task_test.rb
    create      test/fixtures/tasks.yml

* 上記で作成される"20200204121345_create_tasks.rb"はマイグレーションファイル
* マイグレーションファイルとは、DBを生成する際の設計図であり、以下のようにRubyでDBの構造が記述されている

  .. code-block:: ruby

    class CreateTasks < ActiveRecord::Migration[5.1]
      def change
        create_table :tasks do |t|
          t.string :title
          t.boolean :done

          # DBのレコードの作成日と更新日を管理するために、
          # Railsが使うカラムを作成するためのもの
          t.timestamps
        end
      end
    end

* マイグレーションファイルを実行することで、その内容に基づいたデータテーブルを生成してくれる

マイグレーションファイルの編集
==============================

* "done"のデフォルト値がfalseになるよう、マイグレーションファイルを編集する

  .. code-block:: ruby

    class CreateTasks < ActiveRecord::Migration[5.1]
      def change
        create_table :tasks do |t|
          t.string :title
          t.boolean :done, default: false   # 追加！

          t.timestamps
        end
      end
    end

DBスキーマ（DBの構造）をDBに反映させる
======================================

* DBの構造をDBに反映させる

  .. code-block:: console

    $ rake db:migrate

    // 以下でもOK
    $ rails db:migrate

  .. note::

    Rails 4までは、「このコマンドはrailsから、このコマンドはrakeから」というように分かれていたが、分けるのも煩雑になるだけということで、Rails 5からは、今までrakeで実行していたコマンドをrailsでも実行できるようになった。
    よって、Rails 5以降でコマンドを使うだけなら、railsだけで問題ない。


* 上記の実行で、"db/development.sql"ファイルが追加され、このファイルにDBのデータが入っている
* DBの構造を確認する

  .. code-block:: console

    // DBコマンドラインツールを起動する
    $ rails db
    SQLite version 3.7.17 2013-05-20 00:56:22
    Enter ".help" for instructions
    Enter SQL statements terminated with a ";"

    // DBの構造を確認する
    sqlite> .schema
    CREATE TABLE "schema_migrations" ("version" varchar NOT NULL PRIMARY KEY);
    CREATE TABLE "ar_internal_metadata" ("key" varchar NOT NULL PRIMARY KEY, "value" varchar, "created_at" datetime NOT NULL, "updated_at" datetime NOT NULL);
    CREATE TABLE "tasks" ("id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, "title" varchar, "done" boolean DEFAULT 'f', "created_at" datetime NOT NULL, "updated_at" datetime NOT NULL);
    
    // DBコマンドラインツールを終了する
    sqlite> .exit

初期データの作成
================

* 複数の方法があるが、ここではRailsコンソールを使用する
* Railsコンソールでは、Railsの環境をロードした状態でirbが起動するので、Modelの操作やデバッグに便利

  .. code-block:: console

    // Railsコンソールを起動する
    $ rails console

    // 任意のレコードを追加する
    2.6.3 :001 > Task.create(title:"test1")
    2.6.3 :002 > Task.create(title:"test2")

    // Railsコンソールを終了する
    2.6.3 :003 > exit

ルーティングの設定
==================

* "config/routes.rb"を編集する

  .. code-block:: ruby

    Rails.application.routes.draw do
      # tasksのレストフルなURLを自動生成する
      # よく使う一般的なルーティングをまとめて用意してくれる設定
      resources :tasks
      # rootのURLにアクセスしたら、
      # tasksコントローラのindexアクションメソッドを実行する
      root 'tasks#index'
    end

* ルーティングを確認する

  .. code-block:: console

    $ rake routes
       Prefix Verb   URI Pattern               Controller#Action
        tasks GET    /tasks(.:format)          tasks#index
              POST   /tasks(.:format)          tasks#create
     new_task GET    /tasks/new(.:format)      tasks#new
    edit_task GET    /tasks/:id/edit(.:format) tasks#edit
         task GET    /tasks/:id(.:format)      tasks#show
              PATCH  /tasks/:id(.:format)      tasks#update
              PUT    /tasks/:id(.:format)      tasks#update
              DELETE /tasks/:id(.:format)      tasks#destroy
         root GET    /                         tasks#index

    // 以下でもOK
    $ rails routes

一覧画面のcontrollerを開発
==========================






















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