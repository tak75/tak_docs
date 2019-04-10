=========
GitBucket
=========

インストール
=============

1. Java JDK（既にインストールされていると思われるが念のため）::
    
    $ sudo apt-get install oracle-java8-jdk

2. GitBucket

  まず、最新版のバージョンを確認する。現時点では4.31.1だった（2019.4.4）::

    https://github.com/gitbucket/gitbucket/releases

  インストール先のディレクトリを作成してダウンロードする。
  ここでは/opt/gitbucketに置くことにした。
  インストールと言ってもダウンロードしたら終わり。::

    $ sudo mkdir /opt/gitbucket
    $ cd /opt/gitbucket
    $ sudo wget -O gitbucket.war https://github.com/gitbucket/gitbucket/releases/download/4.31.1/gitbucket.war

自動起動を設定
===============

rc.localファイルを開き、::

    $ sudo vim /etc/rc.local

exit 0 の直前に実行コマンドを追加する::

    fi
    java -jar /opt/gitbucket/gitbucket.war&         # この行のみを追記する
    exit 0

-gitbucket.homeオプションを指定しない場合は、デフォルトのデータ保存先は~/.gitbucketになる。

参考
====

* `raspberrypi3にgitbucketをインストール <https://inamuu.com/raspberrypi3%E3%81%ABgitbucket%E3%82%92%E3%82%A4%E3%83%B3%E3%82%B9%E3%83%88%E3%83%BC%E3%83%AB/>`__
