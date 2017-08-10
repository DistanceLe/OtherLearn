#!/usr/bin/ruby
puts "====================="
names = Array.new(20)

#两个方法是 一个意思，都返回20
puts names.size
puts names.length
puts "====================="
names = Array.new(4, "mac")  # 给每个元素赋值
for i in names
	puts i 
end
puts "====================="

names = Array.new(6) { |i| i = i*2  }  # 每个元素 使用计算的结果来填充
for i in names
	puts i 
end
puts "====================="
names = Array.[](1, 2, 3, 4, 5)  # 另一种形式
for i in names
	puts i 
end
puts "====================="


names = Array[1, 2, 4, 5, 8]  #另一种形式
for i in names
	puts i 
end
puts "====================="

names = Array(0..6)   #另一种形式
puts "#{names}"
puts "====================="

puts names[3]
puts names.at(4)
puts "====================="







