class User
  def initialize(name)
    @name = name
  end
  
  def hello
    puts "Hello! I am #{@name}."
  end
  
end

# nakamura = User.new('Nakamura')
# nakamura.hello

class AdminUser < User
  def hello_admin
    puts "Hello! I am #{@name} form AdminUser."
  end
  
  def hello
    puts 'Admin!!'
  end
end

sato = AdminUser.new('Sato')
sato.hello
# sato.hello_admin