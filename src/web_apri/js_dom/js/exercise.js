// 「ノードを追加」のレクチャーで学習したコードを改修、
// ユーザーがテキストボックスに文字列を入力後
// ユーザーがボタンを押すと
// リストの最後の項目として文字列が追加されるプログラムを書いてみましょう。

// 補足
// テキストボックスの要素を取得するには、getElementByIDを利用できる。

function append() {
  // テキストボックスの要素を取得
  var textBox = document.getElementById('textBox');
  // li要素を生成
  var li = document.createElement('li');
  // テキストノードを生成
  var text = document.createTextNode(textBox.value);
  // liタグの要素に、テキストノード textを追加
  li.appendChild(text);
  // idがlistsのulタグに、liを追加。具体的には<li>追加文字列</li>が、追加される。
  var listsElement = document.getElementById("lists");
  listsElement.appendChild(li);
}
