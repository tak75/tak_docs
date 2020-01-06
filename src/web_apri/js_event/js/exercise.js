// 演習：イベント
// テキストボックスに文字列を入力して、
// ボタンを押したら、文字列をリストに追加していくプログラムの開発
// イベントの登録には、addEventListenerを利用する

// note : DOMContentLoaded : HTMLドキュメントの読み込みと解析が完了した時に発生
  document.addEventListener('DOMContentLoaded',function(){
    // idがbuttonの要素がクリックされたときに、関数appendElement()を呼び出す処理を
    // addEventListenerを使って実装する。
    var e = document.getElementById('button');
    e.addEventListener('click', function(){
      appendElement();
    }, false);

  }, false);

  // テキストボックスに入力された文字列を、
  // リストに追加する関数。
  function appendElement() {
    // テキストボックスの要素を取得
    var result = document.getElementById('result');
    // liタグの要素を生成
    var li = document.createElement('li');
    // テキストノードを生成
    var text = document.createTextNode(result.value);
    // liタグの要素に、テキストノード text を追加。
    li.appendChild(text);
    // idがlistのulタグに、liを追加。具体的には<li>追加文字列</li>が、追加される
    lists.appendChild(li);
  }
