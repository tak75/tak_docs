==========
JavaScript
==========

関数の種類
==========

* function命令

  .. code-block:: JavaScript

    function getRectangle(height, width) {
      return height * width;
    }

    console.log(getRectangle(3, 5));

* 関数リテラル

  .. code-block:: JavaScript

    var getRectangle = function(height, width) {
    return height * width;

* Functionコンストラクタ

  .. code-block:: JavaScript

    var getRectangle = new Function('height', 'width', 'return height * width');
    console.log(getRectangle(3, 5));

DOM操作
=======

-----------------
getElementById()
-----------------

* 概要

  指定したidを持つ要素を1つ取得する

* 使用例

  .. code-block:: JavaScript

    var result = document.getElementById('result');
    var nowDate = new Date();
    result.innerText = nowDate.toLocaleString();

* 指定したidを持つ要素がなければ null を返す。

----------------------
getElementsByTagName()
----------------------

* 概要

  指定したタグ名を持つ要素を取得する

* 使用例

  .. code-block:: JavaScript

    // タグ名がdivの要素を取得し、その内容（テキスト）をコンソールに出力する。
    var elements = document.getElementsByTagName('div');
    for(var i=0; i<elements.length; i++){
        console.log(elements[i].innerText);
    }

* 戻り値は、HTMLCollection（配列と似た構造のデータ）。
* 指定したタグ名を持つ要素がない場合は、空のHTMLCollection([])を返す。（null ではない）

-------------------
getElementsByName()
-------------------

* 概要

  * 指定したname属性を持つ要素を取得する。
  * ラジオボタン、チェックボックスなどname属性が等しい要素群の取得に利用。

* 使用例

  .. code-block:: JavaScript

    // name属性が'result'の要素を取得し、その入力内容（テキスト）をコンソールに出力する。
    var elements = document.getElementsByName('result');
    console.log(elements[0].value);

* 戻り値は、HTMLCollection（配列と似た構造のデータ）。
* 指定したname属性が存在しない場合は、空のHTMLCollection([])を返す。（null ではない）

------------------------
getElementsByClassName()
------------------------

* 概要

  指定したclass属性を持つ要素を取得する。

* 使用例

  .. code-block:: JavaScript

    // ボタンをクリックしたら、class名が'foo'の要素を取得し、
    // その内容（テキスト）をコンソールに出力する。
    var elements = document.getElementsByClassName('foo');
    for(var i=0; i<elements.length; i++){
        console.log(elements[i].innerText);
    }

* 戻り値は、HTMLCollection（配列と似た構造のデータ）。
* 指定したclass属性が存在しない場合は、空のHTMLCollection([])を返す。（null ではない）

---------------
createElement()
---------------

* 概要

  要素を作成する。

* ノードを作成するだけのため、別途階層に追加する処理が必要。

----------------
createTextNode()
----------------

* 概要

  テキストノードを作成する。

* ノードを作成するだけのため、別途階層に追加する処理が必要。

-------------
appendChild()
-------------

* 概要

  指定された要素を現在の要素の最後の子要素として追加。

* 使用例

  .. code-block:: JavaScript

    // 空のリスト、ボタンを配置
    // ボタンをクリックすると、リストの項目が追加される。
    // 追加される文字列は”追加文字列”とする。
    function append() {
        // li要素を生成
        var li = document.createElement('li');
        // テキストノードを生成
        var text = document.createTextNode('追加文字列');
        // liタグの要素に、テキストノード textを追加
        li.appendChild(text);
        // idがlistsのulタグに、liを追加。具体的には<li>追加文字列</li>が、追加される。
        var listsElement = document.getElementById("lists");
        listsElement.appendChild(li);
    }

* 戻り値は、追加した子ノード

--------------
replaceChild()
--------------

* 概要

  指定した子ノードを置き換える

* 使用例

  .. code-block:: JavaScript

    // リストとボタンを配置
    // ボタンをクリックしたら、リストの子要素を置換する処理
    function replace() {
        // 空のli要素を作成
        var newList = document.createElement('li');
        // 生成したノードにid属性"newList"を付与
        newList.setAttribute('id', 'newList');
        // テキストノードを生成
        var newText = document.createTextNode('新しい要素です');
        // 生成したノードを、空のli要素の子ノードとして追加
        newList.appendChild(newText);
        // 置換前の変数oldListの参照を変数oldListに代入。
        // (参照とは、オブジェクトへのリンクのことを言う)
        // https://developer.mozilla.org/ja/docs/Glossary/Object_reference
        var oldList = document.getElementById('oldList');
        // 親ノードulの参照を変数parentNodeに代入
        var parentNode = oldList.parentNode;
        // 既存ノードoldListを、新規に作成したli要素newListと置換
        parentNode.replaceChild(newList, oldList);
    }

* newChildと、oldChildを入れ換える動作。（appendChild()と、removeChild()を同時に行う）

-------------
removeChild()
-------------

* 概要

  指定した子ノードを取り除く

* 使用例

  .. code-block:: JavaScript

    // リストとボタンを設置
    // ボタンをクリックすると、リストの子要素が最後のものから削除される
    function remove(){
        var parentElement = document.getElementById('lists');
        var elements = parentElement.getElementsByTagName('li');
        var removeIndex = elements.length - 1;
        parentElement.removeChild(elements[removeIndex]);
    }

* 戻り値は、取り除いたノードoldChildであり、これは再利用できる

イベントとイベントハンドラ
==========================

----------------------------
開始タグの中で関連付ける方法
----------------------------

* 1つの要素や1つのイベントに対して、1つのイベントハンドラしか設定できない。
* 本来レイアウトを定義すべきHTMLの中に、javascriptのコードを混在させており、可読性が落ちる。
* 使用例

  .. code-block:: html

    <!htmlコード>
    <input type="button" value="クリックしてください" onclick="clicked()">

  .. code-block:: JavaScript

    // javascriptコード
    function clicked() {
      console.log('イベント発生');
    }

--------------------------
プロパティで関連付ける方法
--------------------------

* 1つの要素や1つのイベントに対して、1つのイベントハンドラしか設定できない。
* 使用例

  .. code-block:: JavaScript

    var e = document.getElementById('button');
    e.onclick = function() {
      console.log('イベント発生');
    };

----------------
addEventListener
----------------

* 1つの要素や1つのイベントに対して、複数のイベントハンドラを設定できる。（この方法で実装すべし！）
* 使用例

  .. code-block:: JavaScript

    window.onload = function() {
      var e = document.getElementById('button');
      e.addEventListener('click', function(){
        console.log('イベント発生！');
      }, false);
    }
