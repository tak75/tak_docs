# 変数nの値が0でなければ
# ‘0ではありません’と出力するプログラムをunlessを使って記述してみましょう。

n = 0
if !n.zero?
  puts '0ではありません'
end

unless n.zero?
  puts '0ではありません'
end
