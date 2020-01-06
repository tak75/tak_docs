window.onload = function() {
  var e = document.getElementById('button');
  e.addEventListener('click', function(){
    console.log('イベント発生！');
  }, false);
}
