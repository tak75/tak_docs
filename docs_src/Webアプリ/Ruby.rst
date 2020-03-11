====
Ruby
====

用語
====

.. glossary::

  Ruby

    * 日本人が開発したプログラミング言語。
    * 関連用語： :term:`Ruby on Rails`

Rubyのバージョン管理コマンド（Cloud9のコマンドラインで入力し使用）
==================================================================

* 現在のRubyのバージョンを表示する

  .. code-block:: console

    $ ruby -v

    //出力例
    ruby 2.3.8p459 (2018-10-18 revision 65136) [x86_64-linux]

* 現在インストールされているRubyのバージョンリストを表示する

  .. code-block:: console

    $ rvm list

    //出力例
       ruby-2.3.1 [ x86_64 ]
    => ruby-2.3.8 [ x86_64 ]
     * ruby-2.6.3 [ x86_64 ]

    # => - current
    # =* - current && default
    #  * - default

* 特定のバージョンをインストールする

  .. code-block:: console

    $ rvm install 2.3.4

* 特定のメジャーバージョンの最新版をインストールする

  .. code-block:: console

    $ rvm install 2.3   // 2.3.x の最新版がインストールされる

* 特定のバージョンを使用する

  .. code-block:: console

    $ rvm use 2.6.3

* 特定のバージョンをアンインストールする

  .. code-block:: console

    $ rvm remove 2.3.1

* 特定のバージョンをデフォルトで使用するバージョンに設定する

  .. code-block:: console

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

    .. code-block:: console

      $ irb       // 開始時
      > exit      // 終了時

* ファイルに保存したプログラムを実行する

  * ファイル拡張子は.rb
  * Cloud9のコマンドラインにて、実行ファイルのディレクトリに移動（cd）した上で、以下を入力し実行する

    .. code-block:: console

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

---------------------
puts,print,p メソッド
---------------------

puts メソッド
-------------

* 改行を加えてターミナルに出力する
* 戻り値はnil

.. code-block:: ruby

  2.5.0 :001 > puts 'nakamura'
  nakamura
  => nil

print メソッド
--------------

* 改行なしでターミナルに出力する
* 戻り値はnil

.. code-block:: ruby

  2.5.0 :002 > print 'nakamura'
  nakamura => nil

p メソッド
----------

* デバッグ用
* 戻り値は引数のオブジェクト

.. code-block:: ruby

  2.5.0 :003 > p 'nakamura'
  "nakamura"
  => "nakamura"

----
配列
----

.. code-block:: ruby

  # 空の配列を作成する
  2.5.0 :006 > b = []
  => []
  2.5.0 :007 > b.empty?
  => true

  # 初期値を指定してい配列を作成する
  2.5.0 :001 > a = [1, 2, 3, 'aa', [1, 2, 3]]
  => [1, 2, 3, "aa", [1, 2, 3]]
  2.5.0 :002 > a[0]
  => 1

  # 特定の要素が含まれているか調べる
  2.5.0 :008 > a.include?('aa')
  => true
  2.5.0 :009 > a.include?('b')
  => false

  # 配列を逆順にして返す
  2.5.0 :010 > a.reverse
  => [[1, 2, 3], "aa", 3, 2, 1]
  2.5.0 :011 > a
  => [1, 2, 3, "aa", [1, 2, 3]]

  # 配列そのものを逆順にする
  2.5.0 :012 > a.reverse!
  => [[1, 2, 3], "aa", 3, 2, 1]
  2.5.0 :013 > a
  => [[1, 2, 3], "aa", 3, 2, 1]

  # 配列をシャッフルする
  2.5.0 :014 > a.shuffle
  => [1, 2, "aa", [1, 2, 3], 3]
  2.5.0 :015 > a.shuffle
  => ["aa", 1, 3, [1, 2, 3], 2]
  2.5.0 :016 > a
  => [[1, 2, 3], "aa", 3, 2, 1]

  # 0～10の連続した数値を持つ配列を作成する
  2.5.0 :022 > z = (0..10).to_a
  => [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

  # 配列への要素追加 1（"20"を追加）
  2.5.0 :023 > z << 20
  => [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20]

  # 配列への要素追加 2（"30"を追加）
  2.5.0 :025 > z.push(30)
  => [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, 30]

  # 配列から最後の要素を取り出し削除する
  2.5.0 :028 > z.pop
  => 30
  2.5.0 :030 > z
  => [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20]

  # 配列から最初の要素を取り出し削除する
  2.5.0 :031 > z.shift
  => 0
  2.5.0 :032 > z
  => [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20]

  # 重複する要素を削除する
  2.5.0 :034 > z
  => [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, 3, 6]
  2.5.0 :035 > z.uniq
  => [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20]

  # 配列文字列を結合する
  2.5.0 :039 > s = ['my', 'name', 'is', 'nakamura']
  => ["my", "name", "is", "nakamura"]
  2.5.0 :040 > s.join
  => "mynameisnakamura"

  # セパレータを指定して配列文字列を結合する
  2.5.0 :042 > s.join(' ')
  => "my name is nakamura"

--------
ハッシュ
--------

基本操作1
---------

.. code-block:: ruby

  # 空のハッシュを作成する
  2.5.0 :001 > h = {}
  => {}
  2.5.0 :002 > puts h
  {}
  => nil

  # 初期値を指定してハッシュを作成する
  2.5.0 :003 > nakamura = {'name' => 'Nakamura', 'birthplace' => 'Nagano'}
  => {"name"=>"Nakamura", "birthplace"=>"Nagano"}
  2.5.0 :004 > puts nakamura['name']
  Nakamura
  => nil

  # 要素を追加する
  2.5.0 :006 > nakamura['age'] = 20
  => 20
  2.5.0 :007 > puts nakamura
  {"name"=>"Nakamura", "birthplace"=>"Nagano", "age"=>20}
  => nil

  # 要素を削除する
  2.5.0 :008 > nakamura.delete('age')
  => 20
  2.5.0 :009 > puts nakamura
  {"name"=>"Nakamura", "birthplace"=>"Nagano"}
  => nil

  # シンボルを使ってハッシュを作成する
  # 前述の文字列を使った方法よりアクセスが早い
  2.5.0 :010 > sato = { name: 'Sato', birthplace: 'Tokyo' }
  => {:name=>"Sato", :birthplace=>"Tokyo"}
  2.5.0 :011 > puts sato
  {:name=>"Sato", :birthplace=>"Tokyo"}
  => nil
  2.5.0 :012 > puts sato[:name]
  Sato
  => nil

  # 要素を追加する
  2.5.0 :014 > sato[:age] = 20
  => 20
  2.5.0 :015 > puts sato
  {:name=>"Sato", :birthplace=>"Tokyo", :age=>20}
  => nil

  # 要素の値を変更する
  2.5.0 :016 > sato[:age] = 21
  => 21
  2.5.0 :017 > puts sato
  {:name=>"Sato", :birthplace=>"Tokyo", :age=>21}
  => nil

  # 要素を削除する
  2.5.0 :018 > sato.delete(:age)
  => 21
  2.5.0 :019 > puts sato
  {:name=>"Sato", :birthplace=>"Tokyo"}
  => nil

要素を1つずつ処理
-----------------

.. code-block:: ruby

  2.5.0 :020 > scores = {luke: 100, jack: 90, robert: 70}
  => {:luke=>100, :jack=>90, :robert=>70}
  2.5.0 :022 > puts scores
  {:luke=>100, :jack=>90, :robert=>70}
  => nil

  # ハッシュから1つずつ要素を取り出し値のみを表示する
  2.5.0 :023 > scores.each { |k, v| puts v}
  100
  90
  70
  => {:luke=>100, :jack=>90, :robert=>70}

  # ハッシュから1つずつ要素を取り出しキーと値を表示する
  2.5.0 :024 > scores.each { |k, v| puts "#{k}, #{v}" }
  luke, 100
  jack, 90
  robert, 70
  => {:luke=>100, :jack=>90, :robert=>70}

  # ハッシュから1つずつ要素を取り出し値が80以上の要素のみキーと値を表示する
  2.5.0 :026 > scores.each { |k, v|
  2.5.0 :027 >     if v >= 80
  2.5.0 :028?>       puts "#{k}, #{v}"
  2.5.0 :029?>     end
  2.5.0 :030?>   }
  luke, 100
  jack, 90
  => {:luke=>100, :jack=>90, :robert=>70}

基本操作2
---------

.. code-block:: ruby

  # ハッシュ内のキー一覧を表示
  2.5.0 :032 > scores.keys
  => [:luke, :jack, :robert]

  # ハッシュ内の値一覧を表示
  2.5.0 :033 > scores.values
  => [100, 90, 70]

  # ハッシュ内に所定のキーがあるか
  2.5.0 :034 > scores.has_key?(:luke)
  => true
  2.5.0 :035 > scores.has_key?(:takahashi)
  => false

  # ハッシュの要素数を取得
  2.5.0 :036 > scores.size
  => 3

------------
繰り返し処理
------------

each
----

.. code-block:: ruby

  # 配列の要素を変数numberに1つずつ取り出しながら処理を実行する
  # 方法その1
  numbers = [1, 2, 3, 4, 5]
  numbers.each do |number|
      puts number
  end

  # 方法その2
  numbers = [1, 2, 3, 4, 5]
  numbers.each { |number|
      puts number
  }

  # ハッシュの場合
  # ハッシュの要素（キーと値）を変数nameとscoreに1つずつ取り出しながら処理を実行する
  scores = {nakamura: 90, sato: 80, takahashi: 100}
  scores.each do |name, score|
      puts "#{name}m, #{score}"
  end

for
---

* **forは原則使わない**
* 慣習としてeachでもforでも書ける時は、eachを用いる。
* forは、どうしても使わなければいけない明確な理由が明言できる人以外は、使ってはいけない（The Ruby Style Guideより）

.. code-block:: ruby

  # 配列の要素を変数numberに1つずつ取り出しながら処理を実行する
  numbers = [1, 2, 3, 4, 5]
  for number in numbers do
      puts number
  end

times
-----

* 配列を使わず、単純にn回処理を繰り返したい時に使う。

.. code-block:: ruby

  # 繰り返し回数=5回
  5.times do
    puts 'Hello!'
  end

  # 繰り返し回数の番号をiに取り出しつつ処理を行う
  # 方法その1
  5.times do |i|
    puts "#{i}: Hello!"
  end

  # 方法その2
  5.times { |i|
    puts "#{i}: Hello!"
  }

while
-----

* 指定した条件が真である間、処理を繰り返す

.. code-block:: ruby

  i = 0

  while i < 10
    puts "#{i}:hello"
    i += 1 # i = i + 1
  end

upto
----

* nからmまで数値を1ずつ増やしながら処理を実行する場合に使用する

.. code-block:: ruby

  # 10～14まで値を増やしながら1つずつ出力する
  10.upto(14) { |n| puts n}

downto
------

* nからmまで数値を1ずつ減らしながら処理を実行する場合に使用する

.. code-block:: ruby

  # 14～10まで値を減らしながら1つずつ出力する
  14.downto(10) { |n| puts n}

step
----

* nからmまで数値をxずつ増やしながら処理を実行する場合に使用する

.. code-block:: ruby

  # 1～10まで2ずつ増やしながら値を出力する
  # 処理結果：1 3 5 7 9
  1.step(10, 2) {|n| puts n}

  # 10～1まで2ずつ減らしながら値を出力する
  # 処理結果：10 8 6 4 2
  10.step(1, -2) {|n| puts n}

loop, break
-----------

* あえて無限ループを作りたい時に利用する

.. code-block:: ruby

  j = 0
  loop do
    puts j
    j += 1
    break if j == 10
  end

next
----

.. code-block:: ruby

  numbers = [1, 2, 3, 4, 5]
  numbers.each do |n|
    # nが偶数の場合は次の要素の処理に進む（C言語のcontinueと同意）
    # nが奇数の場合は"even"の代わりに"odd"を使用
    next if n.even?
    puts n
  end

------
クラス
------

* インスタンス変数は"@～"と記載

.. code-block:: ruby

  class User

    # コンストラクタ
    def initialize(name)
      puts 'initialize!!'
      @name = name    # "@～"はインスタンス変数であり、クラス内であればどこでも使える
    end

    def hello
      puts "Hello! I am #{@name}."
    end
  end

  # インスタンス作成
  emma = User.new('Emma')
  emma.hello

--------
アクセサ
--------

.. code-block:: ruby

  # 自分でget/setアクセサを書く場合
  class User
    def initialize(name)
      @name = name
    end

    # getアクセサ
    def name
      @name
    end

    # setアクセサ
    def name=(value)
      @name = value
    end

  end

.. code-block:: ruby

  # 自動でget/setアクセサを書く場合
  class User

    # get/setアクセサを自動生成
    attr_accessor :name

    def initialize(name)
      @name = name
    end

  end

.. code-block:: ruby

  # getアクセサのみ自動生成する場合（リードオンリー）
  attr_reader :name

  # setアクセサのみ自動生成する場合（ライトオンリー）
  attr_writer :name

--------------------------
クラスメソッド、クラス変数
--------------------------

.. code-block:: ruby

  class User
    REGION = 'USA'

    # クラス変数（"@@"を付ける）
    @@count = 0

    def initialize(name)
      @name = name
      @@count += 1
    end

    def hello
      puts "I am #{@name}. #{@@count} instance(s)."
    end

    # クラスメソッド（"self."を付ける）
    def self.info
      puts "#{@@count} instance(s).Region: #{REGION}"
    end

  end

  emma = User.new('Emma')
  # クラスメソッドのコール方法
  User.info

  # 定数へのアクセス方法
  puts User::REGION

------------
クラスの継承
------------

.. code-block:: ruby

  # Userクラスを継承
  class AdminUser < User

    # 親クラスのメソッドのオーバライド
    def hello
      puts 'Admin!!'
    end
  end

--------------------
メソッドのアクセス権
--------------------

* public/protected/private の3種
* デフォルトはpublic

.. code-block:: ruby

  class User
    # 1段下げてメソッドを定義することで、全てのメソッドがprivateとなる
    private
      def hello
        puts "Hello! I am #{@name}."
      end

      def xxx
        # 処理
      end
  end

----------
モジュール
----------

* クラスメソッドや定数のみを持つクラス？
* 関連するメソッドや定数などをまとめてグループ化したいだけの時にモジュールは手軽に使えて便利

.. code-block:: ruby

  module Driver
    def self.run
      puts 'Run'
    end

    def self.stop
      puts 'Stop'
    end
  end

  Driver.run
  Driver.stop

----
例外
----

.. code-block:: ruby

  puts '---数値を入力してください---'
  i = gets.to_i

  begin
    # 例外が起きうる処理
    puts 10 / i
  rescue => ex
    # 例外が発生した場合の処理
    puts 'error!'
    puts ex.message
    puts ex.class
  ensure
    # 例外が発生しても、しなくても、最後に実行したい処理
    puts 'end'
  end

------------------
コーディングルール
------------------

* インデントは半角スペース **2字**
* 公式のコーディングルールは存在しない
* 「The Ruby Style Guide」が有名

  参考：Rubyのソースコード解析ツールRuboCopの作者と同じ

  * `英語 <https://github.com/rubocop-hq/ruby-style-guide>`__
  * `日本語 <https://github.com/fortissimo1997/ruby-style-guide/blob/japanese/README.ja.md>`__
  * `RuboCop <https://github.com/rubocop-hq/rubocop>`__

------
その他
------

* nil

  何も存在しないことを意味する値。nullと同意？

* インクリメント"++"やデクリメント"--"はrubyにはない。代わりに"+="と"-="を使う。
