====
HTML
====

エディタ
========

* Visual Studio Code

  * htmlのタグやjavascriptのメソッドなどについて、デフォルトで入力補助がある。
  * 「HTML Preview」
    
    * 本拡張機能を入れるとリアルタイムプレビューできるようになる。
    * リアルタイムプレビューの方法は、「Ctrl + K → V」（ https://rui-log.com/vscode-html-cording/ ）

* Atom

  * htmlのタグについてはデフォルトで入力補助があるが、javascriptについてはない。Visual Studio Codeの方がよさそう。

文法チェック
============

* W3C（https://validator.w3.org/）

  以下の方法にて文法チェックできる。

  * 公開中のURL入力
  * ファイルアップロード
  * コピー　＆　ペースト
 
メタデータ
===========

* description

  ページのコンテンツに関する簡潔で正確な概要を書くことで検索エンジンにひっかかるようにする。【重要！】::

    <meta name="description" content="CSS Cafeの公式Webサイトです。商品情報、店舗紹介、アクセス、会社情報など。">

* keywords

  ページのコンテンツに関連する単語をカンマ区切りで書く::

    <meta name="keywords" content="CSS Cafe, カフェ，コーヒー">

その他
======

* ダミー画像を入れる方法（無償のサイトを利用する）::

    // html
    <img src="https://via.placeholder.com/940x350" alt="CSS Cafe">
