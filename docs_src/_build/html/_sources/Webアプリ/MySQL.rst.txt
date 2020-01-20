=====
MySQL
=====

Cloud9での環境構築
==================

* Cloud9にはデフォルトでMySQLがインストールされている
* 現在のバージョンを表示する

  .. code-block:: console

    $ mysql --version
    mysql  Ver 14.14 Distrib 5.5.62, for Linux (x86_64) using readline 5.1

* 現在のバージョンより最新の安定版がある場合は、サービスを停止し、最新版を再インストールする
* 例）一旦5.5系をアンインストールし、安定版5.7系の最新バージョンをインストールする

  .. code-block:: console

    $ sudo service mysqld stop
    $ sudo yum -y remove mysql-config mysql55-server mysql55-libs mysql55
    $ sudo yum -y install mysql57-server mysql57

* サービスを開始する

  .. code-block:: console

    $ sudo service mysqld start

* 現在のステータスを表示する

  .. code-block:: console

    $ service mysqld status

* rootユーザでログインする（パスワード不要）

  .. code-block:: console

    $ mysql -u root
    mysql> exit    // 終了する場合

* 日本語の文字コードをUTF8に変える

  .. code-block:: console

    // 現在の文字セットを確認
    $ mysql -u root
    
    mysql> show variables like '%char%';
    +--------------------------+------------------------------+
    | Variable_name            | Value                        |
    +--------------------------+------------------------------+
    | character_set_client     | utf8                         |
    | character_set_connection | utf8                         |
    | character_set_database   | latin1                       |   // これをutf8に変えたい
    | character_set_filesystem | binary                       |
    | character_set_results    | utf8                         |   // これをutf8に変えたい
    | character_set_server     | latin1                       |
    | character_set_system     | utf8                         |
    | character_sets_dir       | /usr/share/mysql57/charsets/ |
    +--------------------------+------------------------------+

  .. code-block:: console

    // 現在の設定ファイルをチェック（lessを抜ける際は"Q"+"Enter"）
    $ less /etc/my.cnf

    // 念のため現在の設定ファイルをバックアップ
    $ sudo cp /etc/my.cnf /etc/my.cnf.bk

    // 文字コードをUTF8に変更
    //   "i"でInsertモード、
    //   [mysqld]の最後に"character-set-server = utf8"を追記し、
    //   "esc"+":wq"で上書き保存
    $ sudo vim /etc/my.cnf

    // 念のため設定ファイルを再確認（lessを抜ける際は"Q"+"Enter"）
    $ less /etc/my.cnf

    // MySQLをリスタート
    $ sudo service mysqld restart

  .. code-block:: console

    // 文字セットを確認
    $ mysql -u root

    mysql> show variables like '%char%';
    +--------------------------+------------------------------+
    | Variable_name            | Value                        |
    +--------------------------+------------------------------+
    | character_set_client     | utf8                         |
    | character_set_connection | utf8                         |
    | character_set_database   | utf8                         |
    | character_set_filesystem | binary                       |
    | character_set_results    | utf8                         |
    | character_set_server     | utf8                         |
    | character_set_system     | utf8                         |
    | character_sets_dir       | /usr/share/mysql57/charsets/ |
    +--------------------------+------------------------------+

* MySQLを自動起動に設定する

  .. code-block:: console

    // 自動起動に設定
    $ sudo chkconfig mysqld on

    // 自動起動に設定されたか確認
    $ sudo chkconfig | grep mysql
    mysqld          0:off   1:off   2:on    3:on    4:on    5:on    6:off

使用方法
========

* 現在のDBを表示する

  .. code-block:: sql

    mysql> show databases;

* コマンドラインをクリアする

  .. code-block:: sql

    mysql> system clear

* DB"xxx"を作成する

  .. code-block:: sql

    mysql> create database xxx;

* DB"xxx"を削除する

  .. code-block:: sql

    mysql> drop database xxx;

* 現在の操作対象のDBを確認する

  .. code-block:: sql

    mysql> select database();

* 操作対象のDBを"xxx"にセットする

  .. code-block:: sql

    mysql> use xxx;

* 操作対象のDBを"xxx"にセットしてログインする

  .. code-block:: console

    $ mysql -u root db01

作業用ユーザの作成
==================

* rootユーザは全ての権限を持っており危険であるため、作業用のユーザを作成する。

  .. code-block:: console

    // rootユーザでログインする
    $ mysql -u root

  .. code-block:: sql

    -- localhostからアクセスするユーザ"dbuser01"を作成し、パスワードを"xxx"に設定する
    mysql> create user dbuser01@localhost identified by 'xxx';

    -- localhostからアクセスするユーザ"dbuser01"に、DB"db01"の全てのテーブルに対する全て権限を付与する
    mysql> grant all on db01.* to dbuser01@localhost;

* 作業用ユーザでログインする

  .. code-block:: console

    // ユーザ"dbuser01"（要パスワード）でログインする
    $ mysql -u dbuser01 -p

  .. code-block:: sql

    -- 以下が表示されるので設定したパスワードを入力しEnterキーを押す
    Enter password:

    -- 現在のユーザを確認する
    mysql> select user();

    -- 出力内容
    +--------------------+
    | user()             |
    +--------------------+
    | dbuser01@localhost |
    +--------------------+

* ユーザとDBを削除する場合

  .. code-block:: console

    // rootユーザでログインする
    $ mysql -u root

  .. code-block:: sql

    -- DB"xxx"を削除する
    mysql> drop database xxx;

    -- ユーザ"dbuser01@localhost"を削除する
    mysql> drop user dbuser01@localhost;

SQLファイルからSQLを実行
==========================

* SQLでのコメント方法は"--"か、"/* */"
* "initialize.sql"ファイルを作成する（例）

  .. code-block:: sql

    -- DB"mydb"が存在していたら削除する（存在しない場合は何もしない）
    drop database if exists mydb;

    -- DB"mydb"を作成する
    create database mydb;

    -- localhostからアクセスするユーザ"dbuser01"を作成
    -- パスワードを"xxx"に設定
    -- DB"mydb"の全てのテーブルに対する全て権限を付与する
    grant all on mydb.* to mydbuser@localhost identified by 'xxx';

* "initialize.sql"ファイルをrootユーザ権限で実行する

  .. code-block:: console

    $ mysql -u root < initialize.sql

テーブル操作
============

  .. code-block:: sql

    -- DB"mydb"を使用
    mysql> use mydb;

    -- テーブル"users"を作成
    mysql> create table users(id int unsigned, name varchar(32), age int);

    -- テーブルを表示
    mysql> show tables;
    +----------------+
    | Tables_in_mydb |
    +----------------+
    | users          |
    +----------------+

    -- テーブル"users"の詳細を表示（desc:description）
    mysql> desc users;
    +-------+------------------+------+-----+---------+-------+
    | Field | Type             | Null | Key | Default | Extra |
    +-------+------------------+------+-----+---------+-------+
    | id    | int(10) unsigned | YES  |     | NULL    |       |
    | name  | varchar(32)      | YES  |     | NULL    |       |
    | age   | int(11)          | YES  |     | NULL    |       |
    +-------+------------------+------+-----+---------+-------+

    -- テーブル"users"を削除
    mysql> drop table users;

    -- テーブルを表示
    mysql> show tables;
    Empty set (0.00 sec)
