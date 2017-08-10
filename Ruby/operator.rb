#!/usr/bin/ruby

# ** 表示指数运算
a = 2
b = 10
puts a**b   #输出 1024
puts "========================"

# <=>  联合比较运算符   相等返回0， 大于返回1， 小于返回-1
puts a<=>b   #输出 -1
puts "========================"

# ===   
puts (1...10)===5  #输出true
puts (1...10)===1  #输出true
puts (1...10)===10  #输出false
puts (1...10)===11  #输出false
puts "========================"


# .equl?   值和类型都相等
puts 1.eql?(1.0)   #false
puts 1 == 1.0      #true
puts "========================"

# equal?  对象相同id, copy出来的副本只能是 ==


# 并行赋值：
a, b, c = 10, 20, 30
puts "#{a} #{b} #{c}"
a, b = b, c
puts "#{a} #{b} #{c}"
puts "========================"

# and 和 && ， or 和 || ， ! 和 not   这三对是一样的意思

# ..   1..10
(1..10).each do |n|
	print n, ' '
end
puts
# ...  1...10
(1...10).each do |n|
	print n, ' '
end
puts
puts "========================"

#  defined?  是否已定义
foo = 42
puts defined? foo   #输出 local-variable
puts defined? $_    #输出 global-variable
puts defined? bar	# 空
puts defined? puts  #输出  method
puts defined? super #是否存在可被 super 用户调用的方法 super

puts "========================"


#  ::  模块
module Foo
	MR_Count = 3
	::MR_Count = 1
end

puts MR_Count       #输出 1
puts Foo::MR_Count  #输出 3
puts "========================"


CONST = ' out there'
class Inside_one
   CONST = proc {' in there'}
   def where_is_my_CONST
      ::CONST + ' inside one'
   end
end
class Inside_two
   CONST = ' inside two'
   def where_is_my_CONST
      CONST
   end
end

puts Inside_one.new.where_is_my_CONST     #out there inside one
puts Inside_two.new.where_is_my_CONST	  #inside two
puts Object::CONST + Inside_two::CONST    #out there inside two
puts Inside_two::CONST + CONST            #inside two out there
puts Inside_one::CONST  				  #  #<Proc:0x007ff7d58aab68@./operator.rb:74>
puts Inside_one::CONST.call + Inside_two::CONST  # in there inside two
puts "========================"






























