// ボタンをクリックしたらｍ、
// name属性が'result'の要素を取得し、その入力内容（テキスト）をコンソールに出力する。
function showElements() {
  var elements = document.getElementsByName('result');
  console.log(elements[0].value);
}
