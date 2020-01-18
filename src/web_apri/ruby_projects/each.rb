# each
# 配列の要素を変数numberに1つずつ取り出しながら処理を実行する
numbers = [1, 2, 3, 4, 5]

# 方法その1
numbers.each do |number|
    puts number
end

# 方法その2
numbers.each { |number|
    puts number
}

colors = ['red', 'green', 'blue']
colors.each do |color|
    puts color
end

# ハッシュの場合
scores = {nakamura: 90, sato: 80, takahashi: 100}
scores.each do |name, score|
    puts "#{name}m, #{score}"
end

#for
for number in numbers do
    puts number
end

for color in colors do
    puts color
end
