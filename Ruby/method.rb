#!/usr/bin/ruby
puts "========================"
#带了 默认值，表示可以不传
def test(a1="Ruby", a2="Perl")
   puts "编程语言为 #{a1}"
   puts "编程语言为 #{a2}"
end
test "C", "C++"
test
test "Java"

puts "========================"
def test_return
   i = 100
   j = 200
   k = 300
return i, j, k
end
var = test_return
puts var
puts "========================"

# 可变参数
def sample(*test)
	puts "the number of parameters is #{test.length}"
	for i in 0...test.length
		puts "parameter: #{test[i]}"
	end
end
sample "Zara", "6", "F"
sample "Mac", "36", "M", "MCA"
puts "========================"

# 类方法
class Accounts
	def read
		puts "这个是实例方法 读"
	end

	def Accounts.write
		puts "这个是类方法 写"
	end

	alias anotherRead read #方法的别名
	undef read   #取消 方法的定义
end

Accounts.write
#Accounts.new.read  

Accounts.new.anotherRead
puts "========================"


# 块
def test
   puts "在 test 方法内"
   yield							#调用 你在块内
   puts "你又回到了 test 方法内"
   yield							#调用 你在块内
end
test {puts "你在块内"}
puts "========================"


def test2
   yield 5, 10
   puts "在 test 方法内"
   yield 100, 200
end
test2 {|i, j| puts "你在块 #{i} #{j} 内"}
puts "========================"

def test3(&block)
   block.call
end
test3 { puts "Hello World!"}
puts "========================"

BEGIN { 
  # BEGIN 代码块
  puts "BEGIN 代码块"
} 

END { 
  # END 代码块
  puts "END 代码块"
}
  # MAIN 代码块
puts "MAIN 代码块"
puts "========================"

# 模块 module
module Trig
   PI = 3.141592654
   def Trig.sin(x)
		return "Trig sin #{x}"
   end
   def Trig.cos(x)
   		return "Trig cos #{x}"

   end
end

module Moral
   VERY_BAD = 0
   BAD = 1
   def Moral.sin(badness)
   # ...
   		return "Moral sin #{badness}"

   end
end

y = Trig.sin(Trig::PI/4)
wrongdoing = Moral.sin(Moral::VERY_BAD)

puts y
puts wrongdoing
puts "========================"

module Week
   FIRST_DAY = "Sunday"
   def Week.weeks_in_month
      puts "You have four weeks in a month"
   end
   def Week.weeks_in_year
      puts "You have 52 weeks in a year"
   end
end


puts "========================"
# 多重继承或 mixin,  sample 包含 四个方法
module A
   def a1
   		puts "a1"
   end
   def a2
   		puts "a2"
   end
end
module B
   def b1
   		puts "b1"
   end
   def b2
   		puts "b2"
   end
end

class Sample
include A
include B
   def s1
   end
end

samp=Sample.new
samp.a1
samp.a2
samp.b1
samp.b2
samp.s1
puts "========================"
