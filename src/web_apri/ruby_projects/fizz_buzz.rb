# FizzBuzz
# 3で割り切れる数値を引数に渡すと、'Fizz'を返す
# 5で割り切れる数値を引数に渡すと、'Buzz'を返す
# 15で割り切れる数値を引数に渡すと、'FizzBuzz'を返す
# それ以外の数値は、その数値を文字列に変えて返す。

# 補足
# メソッド名はfizz_buzzとする。
# 引数名はnとする
# 引数nは1以上の整数が入る
# puts fizz_buzz(1)のようにして、メソッドを呼び出し,
# 動作が正しいか確認してみましょう。
# 数字は1〜15の範囲で確認してみる。

def fizz_buzz(n)
  if n % 15 == 0
    'FizzBuzz'
  elsif n % 3 == 0
    'Fizz'
  elsif n % 5 == 0
    'Buzz'
  else
    n.to_s
  end
  
end

puts fizz_buzz(1)
puts fizz_buzz(2)
puts fizz_buzz(3)
puts fizz_buzz(4)
puts fizz_buzz(5)
puts fizz_buzz(6)
puts fizz_buzz(7)
puts fizz_buzz(8)
puts fizz_buzz(9)
puts fizz_buzz(10)
puts fizz_buzz(11)
puts fizz_buzz(12)
puts fizz_buzz(13)
puts fizz_buzz(14)
puts fizz_buzz(15)