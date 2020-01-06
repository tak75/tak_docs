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
