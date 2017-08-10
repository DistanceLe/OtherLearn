#!/usr/bin/ruby
puts "============================"

hsh = colors = { "red" => 0xf00, "green" => 0x0f0, "blue" => 0x00f }
colors.each do |key, value|
    print key, " is ", value, "\n"
end

hsh.each do |key, value|
    print key, " is ", value, "\n"
end
puts "============================"


puts 'escape using "\\"';  #输出 escape using "\"
puts 'That\'s right'; 	   #输出 That's right
puts "Multiplication Value :#{2*3*2}"; #输出 12    #{ expr }

name = "Ruby"
puts name
puts "#{name + ", ok"}"
puts "============================"


array = ["fred", 10, 2.13, "this is a string", "last element"]
array.each do |i|
	puts i
end


(10...16).each do |n|
	print n, ' '
end

puts
puts "============================"
desc1 = %Q{Ruby 的字符串可以使用 '' 和 ""。}
desc2 = %q|Ruby 的字符串可以使用 '' 和 ""。|

puts desc1
puts desc2
puts "============================"



#创建 带有默认值的 哈希
months = Hash.new("month")
puts "#{months[0]}"
puts "#{months[112]}"

months = Hash.new "months other"
puts "#{months[0]}"
puts "#{months[421]}"
puts "============================"

puts "#{colors.keys}"













