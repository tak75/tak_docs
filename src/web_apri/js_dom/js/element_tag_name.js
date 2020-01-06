// タグ名がdivの要素を取得し、その内容（テキスト）をコンソールに出力する。
function showElements() {
  var elements = document.getElementsByTagName('div');
  for(var i=0; i<elements.length; i++){
    console.log(elements[i].innerText);
  }
}
