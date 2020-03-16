=============
Ruby on Rails
=============

用語
====

.. glossary::

  Ruby on Rails

    * Rubyで書かれたWebアプリケーションフレームワーク
    * RoR, Railsと呼ばれることもある
    * `公式サイト <https://rubyonrails.org/>`__
    * `Ruby on Rails ガイド <https://railsguides.jp/>`__

  RubyGems

    * 幅広いライブラリが"gem"という形式で公開されている
    * RubyGemsは、ライブラリの作成や公開、インストールを助けるシステム
    * `gemを探す <https://rubygems.org/>`__

  erb【Rails】

    * Embedded Ruby
    * 拡張子
    * テンプレートエンジン
    * HTMLの中に、rubyプログラムを書くことができる
    * 任意のコードを実行した時

      .. code-block:: html+erb

        <% 任意のコード %>

    * 何か出力したい時

      .. code-block:: html+erb
  
        <%= 何らかの値を返す式 %>

  ヘルパー【Rails】
    
    Ruby on Rails において、ビューでの共通処理をメソッドとして定義し、簡単に使いまわせるようにした機能。
    "link_to" や "check_box_tag" など

    * link_to（文字列のリンクを生成）

      .. code-block:: html+erb

        <%= link_to 表示文字列, 遷移先パス %>

    * form_for（フォームを生成）

      .. code-block:: html+erb

        <%= form_for(モデル,[オプション]) do |f| %>
          フォームの中身
        <% end %>

      .. note::

        form_forヘルパーは、Rails5.1から非推奨（将来的になくなる可能性がある）。
        Rails5.1以降では、form_forヘルパーの代わりにform_withヘルパーを使用すること

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

helloプロジェクト
=================

----------------------
新規プロジェクトの作成
----------------------

* Cloud9 作業1

  .. code-block:: console

    // バージョンを指定して"hello"プロジェクトを新規作成する
    $ rails _5.1.4_ new hello

    // 作成したプロジェクトに移動する
    $ cd hello/

    // 必要なgem（ライブラリ）をインストールする
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

* Preview->Preview Running Applicationを選択し、
  表示される画面の右上↗ボタンを押すことで、Webアプリ画面が表示される

----------------
ディレクトリ構成
----------------

* app：主要なプログラムを配置してメインで使っていく

  * /models：MVCモデルの「モデル」を配置する
  * /views：MVCモデルの「ビュー」を配置する
  * /controllers：MVCモデルの「コントローラ」を配置する
  * /assets：画像／Javascript／スタイルシート　を配置する

* config：設定を行う

  * routes.rb：ルーティングを設定する

* db：データベースの設定を行う

* 基本的には、configとdbの設定を行いつつ、appディレクトリの中の
  models, views, controllers を開発していく流れとなる

------------------
コントローラの作成
------------------

* helloコントローラを作成し、indexアクションメソッドを追加する

  .. code-block:: console

    // g：generateの略で、"generate"と記述してもOK
    // hello：コントローラの名前
    // index：アクションメソッドの名前
    $ rails g controller hello index
    create  app/controllers/hello_controller.rb
      route  get 'hello/index'      invoke  erb
    create    app/views/hello      create    app/views/hello/index.html.erb
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

* 引数に"index"を追加したことで、以下のファイルやコードが作成される

  * app/controllers/hello_controller.rb

    .. code-block:: ruby

      class HelloController < ApplicationController
        def index
        end
      end

  * app/views/hello/index.html. :term:`erb`

    .. code-block:: html+erb

      <h1>Hello#index</h1>
      <p>Find me in app/views/hello/index.html.erb</p>

  * config/routes.rb

    .. code-block:: ruby

      # ルーティング設定が記載されている
      Rails.application.routes.draw do
        get 'hello/index'
      end

* ルーティング設定を確認する

  .. code-block:: console

    $ rails routes
    Prefix Verb URI Pattern            Controller#Action
    hello_index GET  /hello/index(.:format) hello#index
    // /hello/indexにアクセスすると、helloコントローラのindexアクションがコールされる

* ルートURLにアクセスした場合のアクションを定義するには、routes.rbにて、

  .. code-block:: ruby

    Rails.application.routes.draw do
    #   get 'hello/index'
        root 'hello#index'  # helloコントローラのindexアクションに割り当てる
    end


TODOプロジェクト
================

----------------------
新規プロジェクトの作成
----------------------

* Cloud9 作業

  .. code-block:: console

    $ rails _5.1.4_ new todo
    $ cd todo/
    $ bundle install

------------------
コントローラの作成
------------------

* "Tasks"コントローラを作成する（複数形であることに注意）

  .. code-block:: console

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

------------
モデルの作成
------------

* "Task"モデルを作成する

  .. code-block:: console

    // Task：モデル名（単数形であることに注意）
    // title：タスクの名前を保持するカラム
    // done：タスクの完了状態を保持するカラム
    $ rails g model Task title:string done:boolean
    invoke  active_record
    create    db/migrate/20200311051750_create_tasks.rb   // 重要！
    create    app/models/task.rb                          // 重要！
    invoke    test_unit
    create      test/models/task_test.rb
    create      test/fixtures/tasks.yml

* 上記で作成される"20200311051750_create_tasks.rb"はマイグレーションファイル
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

------------------------------
マイグレーションファイルの編集
------------------------------

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

--------------------------------------
DBスキーマ（DBの構造）をDBに反映させる
--------------------------------------

* DBの構造をDBに反映させる

  .. code-block:: console

    $ rails db:migrate
    == 20200311051750 CreateTasks: migrating ======================================
    -- create_table(:tasks)
      -> 0.0015s
    == 20200311051750 CreateTasks: migrated (0.0020s) =============================

  .. note::

    Rails 4までは、「このコマンドはrailsから、このコマンドはrakeから」というように分かれていたが、
    分けるのも煩雑になるだけということで、Rails 5からは、今までrakeで実行していたコマンドを
    railsでも実行できるようになった。
    よって、Rails 5以降でコマンドを使うだけなら、railsだけで問題ない。

* 上記の実行で、"db/development.sql"ファイルが追加される。
  このファイルにDBのデータが入っている
* DBの構造を確認する

  .. code-block:: console

    // DBコマンドラインツールを起動する
    $ rails db
    SQLite version 3.7.17 2013-05-20 00:56:22
    Enter ".help" for instructions
    Enter SQL statements terminated with a ";"

    // DBの構造を確認する
    // 出力結果のうち、上2行はRailsがDBの構造を管理するために使用するもの
    // 下1行がマイグレーションファイルで指定したもの
    // "created_at"と"updated_at"は、RailsがDBの作成／更新日時を管理するためのもの
    sqlite> .schema
    CREATE TABLE "schema_migrations" ("version" varchar NOT NULL PRIMARY KEY);
    CREATE TABLE "ar_internal_metadata" ("key" varchar NOT NULL PRIMARY KEY
      , "value" varchar
      , "created_at" datetime NOT NULL, "updated_at" datetime NOT NULL);
    CREATE TABLE "tasks" ("id" INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL
      , "title" varchar, "done" boolean DEFAULT 'f'
      , "created_at" datetime NOT NULL, "updated_at" datetime NOT NULL);

    // DBコマンドラインツールを終了する
    sqlite> .exit

----------------
初期データの作成
----------------

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

------------------
ルーティングの設定
------------------

* ファイルを編集する（config/routes.rb）

  .. code-block:: ruby

    Rails.application.routes.draw do
      # tasksのレストフルなURLを自動生成する
      # よく使う一般的なルーティングをまとめて用意してくれる設定
      # この記述により、後述のルーティングの※部分が追加される
      resources :tasks
      # rootのURLにアクセスしたら、
      # tasksコントローラのindexアクションメソッドを実行する
      root 'tasks#index'
    end

.. glossary::

  resourcesメソッド【Rails】

    railsで定義されている7つのアクションのルーティングを自動で作成するメソッド。
    resourcesメソッドを使うことにより、簡単にルーティングを作成することができる。

    .. csv-table:: resourcesメソッドで自動生成されるルーティング
      :header-rows: 1
      :widths: 10, 40

      アクション名,役割
      index,リソースの一覧を表示させる
      show,リソースの詳細を表示させる
      new,投稿フォームを表示させる
      create,リソースを追加させる
      edit,更新フォームを表示させる
      update,リソースを更新させる
      destroy,リソースを削除する

* ルーティングを確認する

  .. code-block:: console

    $ rails routes
       Prefix Verb   URI Pattern               Controller#Action
        tasks GET    /tasks(.:format)          tasks#index    # ※
              POST   /tasks(.:format)          tasks#create   # ※
     new_task GET    /tasks/new(.:format)      tasks#new      # ※
    edit_task GET    /tasks/:id/edit(.:format) tasks#edit     # ※
         task GET    /tasks/:id(.:format)      tasks#show     # ※
              PATCH  /tasks/:id(.:format)      tasks#update   # ※
              PUT    /tasks/:id(.:format)      tasks#update   # ※
              DELETE /tasks/:id(.:format)      tasks#destroy  # ※
         root GET    /                         tasks#index

--------------------------
一覧画面のcontrollerを開発
--------------------------

* タスク一覧ページがリクエストされた時に呼ばれる、Tasksコントローラのindexメソッドを実装する
* ファイルを編集する（app/controllers/tasks_controller.rb）

  .. code-block:: ruby

    class HelloController < ApplicationController
      def index
        # "Task"テーブルの全てのレコードを取得して、テンプレート変数"@tasks"に入れる
        # 裏でRailsがSQLを発行している
        @tasks = Task.all
      end
    end

--------------------
一覧画面のviewを開発
--------------------

* ファイルを作成する（app/views/tasks/index.html.erb）

  .. code-block:: html+erb

    <h1>ToDoアプリ</h1>
    <ul>
      <% @tasks.each do |task| %>
        <li>
          <%= check_box_tag '', '' %>
          <%= task.title %>
        </li>
      <% end %>
    </ul>

* 上記の"check_box_tag"は、htmlのチェックボックスを作成する :term:`ヘルパー【Rails】`

--------------------------------------
一覧画面へ新規追加画面へのリンクを追加
--------------------------------------

* ファイルの末尾に以下を追加する（app/views/tasks/index.html.erb）

  .. code-block:: html+erb

    <%= link_to '新規追加', new_task_path %>

* 上記の"link_to"は、ハイパーリンクを作成する :term:`ヘルパー【Rails】`
* Webアプリで表示される"新規追加"リンクをクリックすると、"/tasks/new"のページが表示される

.. glossary::

  Prefix【Rails】

    パスが代入されている変数のようなもの。
    resourcesメソッドを使ってルーティングを定義すると自動で作成される。
    Prefixを使うときは末尾に"_path"と追記すればパスとなる。
    例えば、以下の"rails routes"コマンドで出力される"/tasks/new"のパスは、"new_task_path"となる
  
    .. code-block:: console

      $ rails routes
        Prefix Verb   URI Pattern               Controller#Action
      new_task GET    /tasks/new(.:format)      tasks#new

------------------------
新規追加画面のviewを開発
------------------------

* ファイルを作成する（app/views/tasks/new.html.erb）

  .. code-block:: html+erb

    <h1>新規追加画面</h1>
    <%= form_for @task do |f| %>
      <p>
        <%= f.label :title %> <br>
        <%= f.text_field :title %>
      </p>
      <p>
        <%= f.submit %>
      </p>
    <% end %>

* 上記の"form_for"は、フォームを作成する :term:`ヘルパー【Rails】`

------------------------------
新規追加画面のcontrollerを開発
------------------------------

* "新規追加"リンクをクリックした際の処理を記述する
  （app/controllers/tasks_controller.rb）

  .. code-block:: ruby

    def new
      # モデル"Task"のレコードを1つ作成して、テンプレート変数"@task"に入れる
      @task = Task.new
    end

* newメソッドでは、レコードを作成するのみで、作成されたレコードはDBには保存されない
* 保存する場合はsaveメソッドを使用する
* createメソッドであれば、レコードを作成し、作成したレコードをDBに保存する
* "Create Task"ボタンを押した際の処理を記述する
  （app/controllers/tasks_controller.rb）

  .. code-block:: ruby

    def create
      @task = Task.new(task_params)

      if @task.save
        # DBへの保存に成功した場合はrootに戻る
        redirect_to root_path
      else
        # DBへの保存に失敗した場合は新規追加画面に戻る
        render 'new'
      end
    end

    private
      def task_params
        # paramsにはフォームから送られたデータが入っている
        # フォームから送られてきたデータのうち、titleカラムのみ取り出す
        params[:task].permit(:title)
      end

----------------
バリデートの追加
----------------

* タイトルが未入力の場合／タイトル文字数が5文字未満の場合にエラー出力するための処理を記述する
  （app/models/task.rb）

  .. code-block:: ruby

    class Task < ApplicationRecord
      validates :title,
      presence: { message: 'タイトルを入力してください！'},
      length: { minimum: 5, message: '5文字以上で入力してください！'}
    end

------------------------------------
一覧画面から編集画面へのリンクを追加
------------------------------------

* 一覧画面に編集リンクを追加する（app/views/tasks/index.html.erb）

  .. code-block:: html+erb

    <h1>ToDoアプリ</h1>
    <ul>
      <% @tasks.each do |task| %>
        <li>
          <%= check_box_tag '', '' %>
          <%= task.title %>
          # 下記1行を追加
          <%= link_to '[編集]', edit_task_path(task.id) %>
        </li>
      <% end %>
    </ul>

--------------------
編集機能のviewを開発
--------------------

* 編集機能は新規追加とほぼ同じなので、"new.html.erb"をコピーし作成する
  （app/views/tasks/edit.html.erb）
* 両者のviewは共通化した方がよいが、とりあえず今回は複製する

  .. code-block:: ruby

    <h1>編集画面</h1>
    <%= form_for @task do |f| %>
      <p>
        <%= f.label :title %> <br>
        <%= f.text_field :title %>
        <% if @task.errors.any? %>
          <%= @task.errors.messages[:title][0] %>
        <% end %>
      </p>
      <p>
        <%= f.submit %>
      </p>
    <% end %>

--------------------------
編集画面のcontrollerを開発
--------------------------

* createメソッドの下に追記する（app/controllers/tasks_controller.rb）

  .. code-block:: ruby

    def edit
      @task = Task.find(params[:id])
    end
    
    def update
      @task = Task.find(params[:id])
      
      if @task.update(task_params)
        redirect_to root_path
      else
        render 'edit'
      end
    end

--------------------
削除機能のviewを開発
--------------------

* 一覧画面に削除リンクを追加する（app/views/tasks/index.html.erb）

  .. code-block:: html+erb

    <h1>ToDoアプリ</h1>
    <ul>
      <% @tasks.each do |task| %>
        <li>
          <%= check_box_tag '', '' %>
          <%= task.title %>
          <%= link_to '[編集]', edit_task_path(task.id) %>
          # 下記の行を追加
          <%= link_to '[削除]', 
            task_path(task.id), # 下記ルートの※からきている
            method: :delete,    # 下記ルートの※からきている
            data:{ confirm: '削除してもよろしいですか？'} %>
        </li>
      <% end %>
    </ul>

  .. code-block:: console

    $ rails routes
       Prefix Verb   URI Pattern               Controller#Action
         task GET    /tasks/:id(.:format)      tasks#show
              PATCH  /tasks/:id(.:format)      tasks#update
              PUT    /tasks/:id(.:format)      tasks#update
              DELETE /tasks/:id(.:format)      tasks#destroy  # ※

--------------------------
削除機能のcontrollerを開発
--------------------------

* updateメソッドの下に追記する（app/controllers/tasks_controller.rb）

  .. code-block:: ruby

    def destroy
      @task = Task.find(params[:id])
      @task.destroy
      redirect_to root_path
    end

------------------------------------
チェックボックスのトグル動作について
------------------------------------

.. glossary::

  Ajax

    * Asynchronous JavaScript + XML
    * ウェブブラウザ内で非同期通信を行いながらインタフェースの構築を行うプログラミング手法
    * 言い換えると、画面を遷移しなくても、サーバとの通信を行いながら、
      動的に画面の表示内容が変わるWebアプリが作れる技術
    * 一般的に利用されており、gmail や google map などがその代表例
    * 素のJavaScriptでも実装できるが、手間なので、JavaScriptのライブラリ "jQuery" を使用
      （パフォーマンスをとことん追求したい特殊案件では素のJavaScriptでAjaxを実装する場合もある）

------------------
jQueryインストール
------------------

* ファイルを修正し以下を追記する（Gemfile）::

    gem 'jquery-rails', '~>4.3.1'

* jquery-railsをインストールする

  .. code-block:: console

    $ bundle install

* jquery-rails（https://github.com/rails/jquery-rails）のInstallationを参照し、
  jQuery3を使用するためファイル末尾に以下を追記する（app/assets/javascripts/application.js）::

    //= require jquery3
    //= require jquery_ujs

----------------
ルーティング設定
----------------

* ファイルを編集する（config/routes.rb）

  .. code-block:: ruby

    Rails.application.routes.draw do
      resources :tasks
      root 'tasks#index'
      # 以下の1行を追記
      post 'tasks/:id/toggle' => 'tasks#toggle'
    end

* 上記を追記することで、以下のルート※が追加される

  .. code-block:: console

    $ rails routes
       Prefix Verb   URI Pattern               Controller#Action
         root GET    /                           tasks#index
              POST   /tasks/:id/toggle(.:format) tasks#toggle   # ※

----------------------------------------------
チェックボックスのトグル動作のcontrollerを開発
----------------------------------------------

* destroyメソッドの下に追記する（app/controllers/tasks_controller.rb）

  .. code-block:: ruby

    def toggle
      # Ajaxを使うのでViewは使わない
      head :no_content
      @task = Task.find(params[:id])
      @task.done = !@task.done
      @task.save
    end

--------------------------------------------------
チェックボックスのトグル動作のクライアント側の開発
--------------------------------------------------

* 一覧画面に削除リンクを追加する（app/views/tasks/index.html.erb）

  .. code-block:: html+erb

    <h1>ToDoアプリ</h1>
    <ul>
      <% @tasks.each do |task| %>
        <li>
          # 下記1行を追記修正
          <%= check_box_tag '', '', task.done, {'data-id' => task.id} %>
          <%= task.title %>
          <%= link_to '[編集]', edit_task_path(task.id) %>
          <%= link_to '[削除]', 
            task_path(task.id),
            method: :delete,
            data:{ confirm: '削除してもよろしいですか？'} %>
        </li>
      <% end %>
    </ul>

    <%= link_to '新規追加', new_task_path %>

    # 以下のコードを追記
    <script>
      $(function(){
        $("input[type=checkbox]").click(function(){
          $.post('/tasks/' + $(this).data('id') + '/toggle');
        });
      });
    </script>

