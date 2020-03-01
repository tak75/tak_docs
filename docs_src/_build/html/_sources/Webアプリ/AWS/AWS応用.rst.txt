=======
AWS応用
=======

【S3/CloudFront】画像を配信する
===============================

----
用語
----

.. glossary::

  S3

    * 安価で耐久性の高いAWSのクラウドストレージサービス
    * 特徴

      * 1GB約3円/月
      * ほぼ100%の高い耐久性
      * 容量無制限。1ファイル最大5TBまで
      * バケットやオブジェクトに対してアクセス制限を設定できる

    * 重要概念

      * バケット

        * オブジェクトの保存場所。名前はグローバルでユニークな必要あり

      * オブジェクト

        * データ本体。S3に格納されるファイルで、各々にURLが付与される
        * バケット内オブジェクト数は無制限

      * キー

        * オブジェクトの格納URLパス

    * 利用シーン

      * 静的コンテンツの配信

        * img画像をS3から配信

      * バッチ連携用のファイル置き場

        * S3にファイルを置いて、バッチでそのファイルを参照して処理する

      * ログなどの出力先

        * 定期的にS3にログを送る

      * 静的ウェブホスティング

        * 静的なウェブサイトをS3から公開

  スケールアウト

    サーバの台数を増やすこと

  CloudFront

    AWSにおける :term:`CDN` のサービス

  CDN

    * Content Delivery Network
    * 高速にコンテンツを配信するサービス
    * オリジンサーバ（元となる画像を配信するサーバ。今回の場合はS3）上にあるコンテンツを、
      世界中100箇所以上にあるエッジロケーションにコピーし、そこから配信を行う
    * 高速：ユーザから最も近いエッジサーバから画像を配信する
    * 効率的：エッジサーバでコンテンツのキャッシングを行うので、オリジンサーバに負荷をかけずに配信できる

  Certificate Manager

    証明書を発行・管理するためのAWSのサービス

  SSLサーバ証明書

    * Webサーバの持ち主が実在することを示す電子証明書
    * ブラウザとWebサーバ間で暗号化通信（https）をする時に必要

----
説明
----

インフラ設計における重要な観点
------------------------------

* 可用性：サービスを継続的に利用できるか（一番重要）
* 性能・拡張性：システムの性能が十分で、将来的においても拡張しやすいか
* 運用・保守性：運用と保守がしやすいか
* セキュリティ：情報が安全に守られているか
* 移行性：現行システムを他のシステムに移行しやすくなっているか

画像保存場所をWebサーバではなくS3にする理由
-------------------------------------------

* Webサーバのストレージが画像で一杯になるのを防ぐ
* HTMLへのアクセスと画像へのアクセスを分けることで負荷分散する
* サーバの台数を増やしやすくする（画像の保存場所を分離することで、:term:`スケールアウト` しやすくする）
* コンテンツ配信サービス（ :term:`CloudFront` ）から配信することで、画像配信を高速化できる

----
手順
----

* AWS側の準備

  * S3のバケット作成

    * AWS -> S3 -> バケット -> 「バケットを作成する」ボタンを押す

      * バケット名：グローバルでユニークな名称（例：aws-and-infra-wp-XXX）
      * リージョン：アジアパシフィック（東京）
      * 既存のバケットから設定をコピー：空

    * 「次へ」ボタンを押す

      * バージョニング：チェックなし
      * サーバアクセスのログ記録：チェックなし（本番環境ではチェックした方がよい）
      * Tags：空
      * オブジェクトレベルのログ記録：チェックなし
      * デフォルト暗号化：チェックなし
      * CloudWatchリクエストメトリクス：チェックなし

    * 「次へ」ボタンを押す

      * パブリックアクセスをすべてブロック：チェックなし
        （バケットとオブジェクトを外部公開したくない場合はチェックするが、今回は画像配信なのでチェックなし）
      * システムのアクセス許可の管理：アクセス権限を付与する

    * 「次へ」ボタンを押す
    * 「バケットを作成」ボタンを押す

  * S3の権限を持ったIAMユーザを作成

    * AWS -> IAM -> ユーザー -> 「ユーザーを追加」ボタンを押す

      * ユーザ名：任意（例：aws-and-infra-wpadmin）
      * アクセスの種類：「プログラムによるアクセス」にチェック
        （WordPressからS3にアクセスするため）

    * 「次のステップ」ボタンを押す

      * 「既存のポリシーを直接アタッチ」をクリック
      * ポリシーのフィルタに「S3」を入力
      * 「AmazonS3FullAccess」にチェックを入れる

    * 「次のステップ」ボタンを押す

      * タグの追加：空

    * 「次のステップ」ボタンを押す
    * 「ユーザーの作成」ボタンを押す
    * 「.csvのダウンロード」ボタンを押し、ファイルを保存する（失くさないこと）
    * 「閉じる」ボタンを押す

* WordPressの設定

  * プラグインのインストール

    * WordPressの管理画面にログイン
    * プラグイン -> 「新規追加」ボタンを押す
    * 検索ボックスに「WP Offload Media」を入力し、WP Offload Mediaを今すぐインストール
    * 「有効化」ボタンを押す

  * 必要なライブラリをEC2にインストール

    * EC2にSSH接続し、インストール

      .. code-block:: console

        $ sudo yum install -y php-xml
        $ sudo yum install -y php-gd

    * インストールしたライブラリを読み込ますためにサーバを再起動させる

      .. code-block:: console

        $ sudo systemctl restart httpd.service

  * プラグインの設定

    * WordPressの管理画面をリロード
    * 設定 -> Offload Media をクリックし、以下をコピーする::

        define( 'AS3CF_SETTINGS', serialize( array(
            'provider' => 'aws',
            'access-key-id' => '********************',
            'secret-access-key' => '**************************************',
        ) ) );

    * EC2へのSSH接続画面にて、

      .. code-block:: console

        $ cd /var/www/html/

        $ ls
        index.php        wp-blog-header.php    wp-cron.php        wp-mail.php
        license.txt      wp-comments-post.php  wp-includes        wp-settings.php
        readme.html      wp-config.php         wp-links-opml.php  wp-signup.php
        wp-activate.php  wp-config-sample.php  wp-load.php        wp-trackback.php
        wp-admin         wp-content            wp-login.php       xmlrpc.php

        $ vim wp-config.php
        // 開いたファイルの最後の方のdefine(～);の最後に、上記でコピーした内容を貼り付ける
        // '**・・'の箇所は、S3の権限を持ったIAMユーザ作成時に保存したcsvファイルを開き、
        // Access key ID と Secret access key をコピーし貼り付ける

      .. note::

        | vim の操作について
        | 「i」：挿入モード
        | 「escキー」：通常モードに復帰
        | 「ZZ」：上書き保存し終了
        | 「:q!」：保存せずに終了

    * Offload Media の画面に戻り、画面をリロード

      * 「Enter bucket name」をクリックし、事前に作成したバケットを選択する
      * 「Save Selected Bucket」ボタンを押す

    * 設定確認画面にて

      * 最後の「Remove File From Server」をONに設定。
        これで、画像がサーバに保存されずにS3にのみ保存される
      * 「Save Changes」ボタンを押す

* 画像がS3に保存されることを確認

  * WordPressで画像を投稿する

    * WordPress管理画面 -> 投稿 -> 投稿一覧 -> Hello world!（何でもよい） -> 編集　をクリック
    * 「画像の追加」ボタンを押し、画像をアップロードする
    * 「更新」ボタンを押し、「投稿を表示」をクリック
    * アップロードした画像を右クリックし、メニューから「新しいタブで画像を開く」を選択
    * 画像のURLがs3～となっていればOK

  * S3のバケットを確認する

    * AWS -> S3 -> バケット -> aws-and-infra-wp-XXX（事前作成のバケット） をクリック
    * wp-content -> uploads -> ・・・に画像が保管されていることを確認

* CloudFrontから配信する

  * ディストリビューションの作成
    （ディストリビューションとは、CloudFrontの配信ルールのこと）

    * AWS -> CloudFront -> 「Create Distribution」ボタンを押す
    * Web -> 「Get Started」ボタンを押す

      * Origin Domain Name：オリジンサーバのS3名（例：aws-and-infra-wp-xxx.s3.amazonaws.com）
      * Origin Path：空欄（オリジンサーバの特定ディレクトリを指定する場合に使用）
      * Origin ID：デフォルト（例：S3-aws-and-infra-wp-xxx）
      * Restrict Bucket Access：No
        （画像にアクセスする際に、S3のURLではなくCloudFrontからのみアクセスしたい場合にYesを選択）
      * Origin Custom HeadersHeader Name：空欄
      * Default Cache Behavior Settings：全てデフォルトでOK
      * Distribution Settings：全てデフォルトでOK
        （Price Classが「Use All Edge Locations」となっていることのみ確認しておく）
      * 「Create Distribution」ボタンを押す

  * ここまでの設定では、WordPressの画像にアクセスするとCloudFrontのドメインのURLとなる。
    それでも特に問題はないが、画像のURLはそのWebページのドメインと同じであることが推奨されている。
    以降では、画像URLを独自ドメインのURLとするための設定を行う

* 独自ドメインから配信する

  * :term:`Certificate Manager` で :term:`SSLサーバ証明書` の発行

    * 作成されたディストリビューションのIDをクリックし、「Edit」ボタンを押す
    * Alternate Domain Names(CNAMEs)：独自ドメインの先頭にサブドメインを付ける（例：staic.xxx.work）
    * 「Request or Import a Certificate with ACM」ボタンを押す

      * ドメイン名：\*.独自ドメイン名（例：\*.xxx.work）
      * 「この証明書に別の名前を追加」ボタンを押す
      * 入力可能となったテキストボックス（追加の名前）に独自ドメイン名を記入（例：xxx.work）
        （追加の名前に独自ドメイン名を記載しないと、サブドメインに対する証明書しか発行されず、
        独自ドメイン本体に対しては証明書が発行されないこととなる）
      * 「次へ」ボタンを押す
      * 検証方法の選択：「DNS の検証」を選択
      * 「次へ」ボタンを押す
      * 「確認」ボタンを押す
      * 「確定とリクエスト」ボタンを押す
      * ドメイン左の▼をクリックし、表示された「Route53でのレコード作成」ボタンを押す

        * 「作成」ボタンを押す

      * もう一方のドメインについては不要（放置していたら「Route53でのレコード作成」ボタンが不活性化）
      * 「続行」ボタンを押す
      * 状況が「検証保留中」から「発行済み」に変わるまで待機する

  * CloudFrontのディストリビューションに独自ドメインを登録

    * CloudFrontのディストリビューション画面をリロードする
    * 作成されたディストリビューションのIDをクリックし、「Edit」ボタンを押す
    * Alternate Domain Names(CNAMEs)：独自ドメインの先頭にサブドメインを付ける（例：staic.xxx.work）
    * SSL Certificate：「Custom SSL Certificate」を選択し、「\*.xxx.work」を選ぶ
    * 「Yes, Edit」ボタンを押す

  * Route53で独自ドメインとCloudFrontドメインのCNAMEレコード（CNAMEは別名の意）を作成する

    * AWS -> Route53 -> ホストゾーン -> xxx.work をクリック
    * 「レコードセットの作成」ボタンを押す

      * 名前：static（上で設定した名称）
      * タイプ：CNAME
      * 値：xxxxx.cloudfront.net（CloudFront での Domain Name をコピペで入力）
      * 「作成」ボタンを押す

  * Offload Media で独自ドメインを登録する

    * WordPress管理画面にログイン -> 設定 -> Offload Media Lite をクリック

      * Custom Domain (CNAME)：ONにして、「static.xxx.work」を入力
      * 「Save Changes」ボタンを押す

----
補足
----

* S3のバケットに複数の画像が保管されるのを停止する

  * WordPressのデフォルト設定では、1枚の画像をアップロードすると、勝手に複数サイズの画像が自動生成される。
    これを停止するためには以下を設定する
  * WordPress管理画面 -> 設定 -> メディア で、全ての数値を0にして更新
  * http://xxx/wp-admin/options.php で「medium_large_size_w」を0にして更新
  * 参考：https://tabi-z.com/wordpress-autoresize-stop

【ELB】Webレイヤを冗長化する
============================

----
用語
----

.. glossary::

  ELB



----
説明
----

* 稼働率を高くするための基本的な考え方

  * 障害発生間隔を長くする
  * 平均復旧時間を短くする

* 稼働率を高くするための手法

  * 冗長化。これにより単一障害点（SPOF：Single Point Of Failure）をなくす

----
手順
----



----
補足
----

【】
============================

----
用語
----

.. glossary::


----
手順
----

----
補足
----

【】
============================

----
用語
----

.. glossary::


----
手順
----

----
補足
----

【】
============================

----
用語
----

.. glossary::


----
手順
----

----
補足
----

