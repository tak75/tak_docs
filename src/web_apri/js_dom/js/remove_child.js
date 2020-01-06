// リストとボタンを設置
// ボタンをクリックすると、リストの子要素が最後のものから削除される
function remove(){
  var parentElement = document.getElementById('lists');
  var elements = parentElement.getElementsByTagName('li');
  var removeIndex = elements.length - 1;
  parentElement.removeChild(elements[removeIndex]);
}
