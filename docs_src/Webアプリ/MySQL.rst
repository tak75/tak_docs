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

データの挿入
============

  .. code-block:: sql

    -- データの挿入
    mysql> insert into users(id, name, age) values(1,'sato',20);
    mysql> insert into users(id, name, age) values(2,'suzuki',21);
    mysql> insert into users(id, name, age) values(3,'takahashi',null);

    -- テーブル"users"から全てを選択し表示
    mysql> select * from users;
    +------+-----------+------+
    | id   | name      | age  |
    +------+-----------+------+
    |    1 | sato      |   20 |
    |    2 | suzuki    |   21 |
    |    3 | takahashi | NULL |
    +------+-----------+------+

    -- 一度に複数のデータを挿入
    mysql> insert into users(id, name,age) values
        -> (4,'tanaka',23),
        -> (5,'ito',24),
        -> (6,'watanabe',25);

    -- テーブル"users"から全てを選択し表示
    mysql> select * from users;
    +------+-----------+------+
    | id   | name      | age  |
    +------+-----------+------+
    |    1 | sato      |   20 |
    |    2 | suzuki    |   21 |
    |    3 | takahashi | NULL |
    |    4 | tanaka    |   23 |
    |    5 | ito       |   24 |
    |    6 | watanabe  |   25 |
    +------+-----------+------+

  .. code-block:: sql

    -- id を "auto increment" & "not null" & "prmary key"
    -- age を "not null" としてテーブル"users"を作成する
    mysql> create table users(id int unsigned auto_increment not null primary key, name varchar(32), age int not null);
    mysql> desc users;
    +-------+------------------+------+-----+---------+----------------+
    | Field | Type             | Null | Key | Default | Extra          |
    +-------+------------------+------+-----+---------+----------------+
    | id    | int(10) unsigned | NO   | PRI | NULL    | auto_increment |
    | name  | varchar(32)      | YES  |     | NULL    |                |
    | age   | int(11)          | NO   |     | NULL    |                |
    +-------+------------------+------+-----+---------+----------------+

    mysql> insert into users (name, age) values('sato', 20);
    mysql> insert into users (name, age) values('suzuki', 21);
    mysql> select * from users;
    +----+--------+-----+
    | id | name   | age |
    +----+--------+-----+
    |  1 | sato   |  20 |
    |  2 | suzuki |  21 |
    +----+--------+-----+

  .. code-block:: sql

    -- id を "auto increment" & "not null" & "prmary key"
    -- age を "not null" & "初期値=1" としてテーブル"users"を作成する
    mysql> create table users(id int unsigned auto_increment not null primary key,
        -> name varchar(32),
        -> age int not null default 1);
    mysql> desc users;
    +-------+------------------+------+-----+---------+----------------+
    | Field | Type             | Null | Key | Default | Extra          |
    +-------+------------------+------+-----+---------+----------------+
    | id    | int(10) unsigned | NO   | PRI | NULL    | auto_increment |
    | name  | varchar(32)      | YES  |     | NULL    |                |
    | age   | int(11)          | NO   |     | 1       |                |
    +-------+------------------+------+-----+---------+----------------+

    mysql> insert into users(name) values('sato');
    mysql> select * from users;
    +----+------+-----+
    | id | name | age |
    +----+------+-----+
    |  1 | sato |   1 |
    +----+------+-----+

値の取得
========

  .. code-block:: sql

    -- テーブル"users"から全ての値を取り出す
    mysql> select * from users;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | sato      |   18 |
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    |  5 | ito       |   19 |
    |  6 | watanabe  |   20 |
    |  7 | yamamoto  | NULL |
    +----+-----------+------+

    -- テーブル"users"から"name"の値を取り出す
    mysql> select name from users;
    +-----------+
    | name      |
    +-----------+
    | sato      |
    | suzuki    |
    | takahashi |
    | tanaka    |
    | ito       |
    | watanabe  |
    | yamamoto  |
    +-----------+

    -- テーブル"users"から"name"と"age"の値を取り出す
    mysql> select name, age from users;
    +-----------+------+
    | name      | age  |
    +-----------+------+
    | sato      |   18 |
    | suzuki    |   22 |
    | takahashi |   29 |
    | tanaka    |   30 |
    | ito       |   19 |
    | watanabe  |   20 |
    | yamamoto  | NULL |
    +-----------+------+

条件を指定して値を取得
======================

  .. code-block:: sql

    -- テーブル"users"からnameが'sato'の値を取り出す
    mysql> select * from users where name='sato';
    +----+------+------+
    | id | name | age  |
    +----+------+------+
    |  1 | sato |   18 |
    +----+------+------+

    -- テーブル"users"からageが20でない値を取り出す（下記は2者同意）
    mysql> select * from users where age <> 20;
    mysql> select * from users where age != 20;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | sato      |   18 |
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    |  5 | ito       |   19 |
    +----+-----------+------+

    -- テーブル"users"からidが1～3の値を取り出す（下記は3者同意）
    mysql> select * from users where id in (1,2,3);
    mysql> select * from users where id between 1 and 3;
    mysql> select * from users where id >= 1 and id <= 3;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | sato      |   18 |
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    +----+-----------+------+

    -- テーブル"users"からidが1～3以外の値を取り出す
    mysql> select * from users where id not in (1,2,3);
    +----+----------+------+
    | id | name     | age  |
    +----+----------+------+
    |  4 | tanaka   |   30 |
    |  5 | ito      |   19 |
    |  6 | watanabe |   20 |
    |  7 | yamamoto | NULL |
    +----+----------+------+

    -- テーブル"users"からageがnullでない値を取り出す
    mysql> select * from users where age is not null;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | sato      |   18 |
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    |  5 | ito       |   19 |
    |  6 | watanabe  |   20 |
    +----+-----------+------+

    -- テーブル"users"からageがnullの値を取り出す
    mysql> select * from users where age is null;
    +----+----------+------+
    | id | name     | age  |
    +----+----------+------+
    |  7 | yamamoto | NULL |
    +----+----------+------+

    -- テーブル"users"からageが20か29の値を取り出す
    mysql> select * from users where age = 20 or age = 29;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  3 | takahashi |   29 |
    |  6 | watanabe  |   20 |
    +----+-----------+------+

パターンマッチ
==============

* "%"はワイルドカードとして認識され、文字数は指定されない。
* "_"はワイルドカードとして認識され、その数が文字数を表す。

  .. code-block:: sql

    mysql> select * from users;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | sato      |   18 |
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    |  5 | ito       |   19 |
    |  6 | watanabe  |   20 |
    |  7 | yamamoto  | NULL |
    +----+-----------+------+

    -- テーブル"users"からnameが'sa'で始まる値を取り出す
    -- （下記は2者同意。大文字／小文字は区別されない）
    mysql> select * from users where name like 'sa%';
    mysql> select * from users where name like 'SA%';
    +----+------+------+
    | id | name | age  |
    +----+------+------+
    |  1 | sato |   18 |
    +----+------+------+

    -- テーブル"users"からnameの途中に'a'を含む値を取り出す
    mysql> select * from users where name like '%a%';
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | sato      |   18 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    |  6 | watanabe  |   20 |
    |  7 | yamamoto  | NULL |
    +----+-----------+------+

    -- テーブル"users"からnameが'a'で終わる値を取り出す
    mysql> select * from users where name like '%a';
    +----+--------+------+
    | id | name   | age  |
    +----+--------+------+
    |  4 | tanaka |   30 |
    +----+--------+------+

    -- テーブル"users"からnameの途中に'a'と'k'をその順番で含む値を取り出す
    mysql> select * from users where name like '%a%k%';
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    +----+-----------+------+

    -- テーブル"users"からnameが6文字の値を取り出す（"_"を6つ書く）
    mysql> select * from users where name like '______';
    +----+--------+------+
    | id | name   | age  |
    +----+--------+------+
    |  2 | suzuki |   22 |
    |  4 | tanaka |   30 |
    +----+--------+------+

    -- テーブル"users"からnameの2文字目が'a'の値を取り出す
    mysql> select * from users where name like '_a%';
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | sato      |   18 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    |  6 | watanabe  |   20 |
    |  7 | yamamoto  | NULL |
    +----+-----------+------+

並び替え
========

  .. code-block:: sql

    -- テーブル"users"からageを昇順にソートして全ての値を取り出す
    -- （下記は2者同意。昇順の場合は省略できる）
    mysql> select * from users order by age asc;
    mysql> select * from users order by age;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  7 | yamamoto  | NULL |
    |  1 | sato      |   18 |
    |  5 | ito       |   19 |
    |  6 | watanabe  |   20 |
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    +----+-----------+------+

    -- テーブル"users"からageを降順にソートして全ての値を取り出す
    mysql> select * from users order by age desc;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  4 | tanaka    |   30 |
    |  3 | takahashi |   29 |
    |  2 | suzuki    |   22 |
    |  6 | watanabe  |   20 |
    |  5 | ito       |   19 |
    |  1 | sato      |   18 |
    |  7 | yamamoto  | NULL |
    +----+-----------+------+

件数の制限
===========

  .. code-block:: sql

    -- テーブル"users"から3件値を取り出す
    mysql> select * from users limit 3;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | sato      |   18 |
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    +----+-----------+------+

    -- テーブル"users"からageを昇順にソートして上位3件を取り出す
    mysql> select * from users order by age asc limit 3;
    +----+----------+------+
    | id | name     | age  |
    +----+----------+------+
    |  7 | yamamoto | NULL |
    |  1 | sato     |   18 |
    |  5 | ito      |   19 |
    +----+----------+------+

    -- テーブル"users"からageがnull以外の値を取り出し、ageを昇順にソートして上位3件を取り出す
    mysql> select * from users where age is not null order by age asc limit 3;
    +----+----------+------+
    | id | name     | age  |
    +----+----------+------+
    |  1 | sato     |   18 |
    |  5 | ito      |   19 |
    |  6 | watanabe |   20 |
    +----+----------+------+

    -- テーブル"users"からageがnull以外の値を取り出し、
    -- ageを昇順にソートして3件オフセットして上位3件を取り出す
    mysql> select * from users where age is not null order by age asc limit 3 offset 3;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    +----+-----------+------+

データの更新
============

  .. code-block:: sql

    mysql> mysql> select * from users;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | sato      |   18 |
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    |  5 | ito       |   19 |
    |  6 | watanabe  |   20 |
    |  7 | yamamoto  | NULL |
    +----+-----------+------+

    -- テーブル"users"において、id=1の値のageを40に更新する
    mysql> update users set age = 40 where id = 1;
    mysql> select * from users;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | sato      |   40 |
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    |  5 | ito       |   19 |
    |  6 | watanabe  |   20 |
    |  7 | yamamoto  | NULL |
    +----+-----------+------+

    -- テーブル"users"において、id=1の値のnameを'aaaaa'に、ageを40に更新する
    mysql> update users set name = 'aaaaa', age = 41 where id = 1;
    mysql> select * from users;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | aaaaa     |   41 |
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    |  5 | ito       |   19 |
    |  6 | watanabe  |   20 |
    |  7 | yamamoto  | NULL |
    +----+-----------+------+

    -- テーブル"users"において、ageが30以上の値のageを99に更新する
    mysql> update users set age = 99 where age >= 30;
    mysql> select * from users;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | aaaaa     |   99 |
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   99 |
    |  5 | ito       |   19 |
    |  6 | watanabe  |   20 |
    |  7 | yamamoto  | NULL |
    +----+-----------+------+

    -- テーブル"users"において、nameを全て'hote'に更新する
    mysql> update users set name = 'hoge';
    mysql> select * from users;
    +----+------+------+
    | id | name | age  |
    +----+------+------+
    |  1 | hoge |   99 |
    |  2 | hoge |   22 |
    |  3 | hoge |   29 |
    |  4 | hoge |   99 |
    |  5 | hoge |   19 |
    |  6 | hoge |   20 |
    |  7 | hoge | NULL |
    +----+------+------+

データの削除
============

  .. code-block:: sql

    mysql> select * from users;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  1 | sato      |   18 |
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    |  5 | ito       |   19 |
    |  6 | watanabe  |   20 |
    |  7 | yamamoto  | NULL |
    +----+-----------+------+

    -- テーブル"users"からid=1の値を削除する
    mysql> delete from users where id = 1;
    mysql> select * from users;
    +----+-----------+------+
    | id | name      | age  |
    +----+-----------+------+
    |  2 | suzuki    |   22 |
    |  3 | takahashi |   29 |
    |  4 | tanaka    |   30 |
    |  5 | ito       |   19 |
    |  6 | watanabe  |   20 |
    |  7 | yamamoto  | NULL |
    +----+-----------+------+

    -- テーブル"users"からageが30以上の値を削除する
    mysql> delete from users where age >= 20;
    mysql> select * from users;
    +----+----------+------+
    | id | name     | age  |
    +----+----------+------+
    |  5 | ito      |   19 |
    |  7 | yamamoto | NULL |
    +----+----------+------+

    -- テーブル"users"から全ての値を削除する
    mysql> delete from users;
    mysql> select * from users;
    Empty set (0.00 sec)