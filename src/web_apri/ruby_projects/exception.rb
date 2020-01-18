puts '---数値を入力してください---'
i = gets.to_i

begin
  # 例外が起きうる処理
  puts 10 / i
rescue => ex
  # 例外が発生した場合の処理
  puts 'error!'
  puts ex.message
  puts ex.class
ensure
  # 例外が発生しても、しなくても、最後に実行したい処理
  puts 'end'
end