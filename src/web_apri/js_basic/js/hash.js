// 連想配列とは
// 各要素を文字列キーでアクセス可能な配列

// 例題
// 変数 userを用意
// 下記の連想配列を作成
// name : 山田花子
// gender : 女性
// birth : 1990/01/01
// それぞれの値をキーを指定して取り出して、コンソールに表示。
var user = {name:'山田花子', gender:'女性', birth:'1990/01/01'};
console.log(user.name);
console.log(user.gender);
console.log(user.birth);

// 補足：範囲外指定
console.log(user.hoge);
