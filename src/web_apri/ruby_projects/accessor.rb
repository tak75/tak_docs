class User
  
  # attr_accessor :name
  # attr_reader :name
  attr_writer :name
  
  def initialize(name)
    @name = name
  end
  
  # def name
  #   @name
  # end
  
  # def name=(value)
  #   @name = value
  # end
  
end

emma = User.new('Emma')
# emma.@name #NG
# puts emma.name
emma.name = 'Emily'
# puts emma.name

# アクセサメソッド