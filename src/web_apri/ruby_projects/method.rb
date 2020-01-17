# Hello World
def hello_world
  puts 'Hello World!'
end

# hello_world

def add(a, b)
  a + b
end

# puts add(10, 1)

# 例題
# 動物の種類によって、鳴き声を返すメソッドcryを作成
# 引数にcatが渡されたら戻り値'ニャー'
# それ以外だったら  戻り値'???'とする。

def cry(animal)
  if animal == 'cat'
    'ニャー'
  else
    '???'
  end
end

puts cry('cat')
puts cry('dog')