# 誕生石から、誕生月を出力するプログラムをcaseで。
# ruby : 7月
# peridot : 8月
# sapphire : 9月
# それ以外 :　データが登録されていません

# if
# stone = 'sapphire'
# if stone == 'ruby'
#   puts '7月'
# elsif stone == 'peridot'
#   puts '8月'
# elsif stone == 'sapphire'
#   puts '9月'
# else
#   puts 'データが登録されていません'
# end

# case
stone = 'garnet'
case stone
when 'ruby'
  puts '7月'
when 'peridot'
  puts '8月'
when 'sapphire'
  puts '9月'
else 
  puts 'データが登録されていません'
end