#!/usr/bin/ruby

x = 2 
if x>2
	puts "x > 2"
elsif x <= 2 and x != 0
	puts "x = 1 或者 x = 2"
else
	puts "x <= 0"
end

$debug 
puts "debug" if $debug   # code if 条件， 为true就执行code
puts "======================"


# unless  和 if相反的意思
unless  x > 2
	puts "x 小于等于 2"
else 
	puts "x 大于2"
end
puts "======================"
# code unless 条件， 为false就执行code


#case  when  then end
$age = 5
case $age
when 0..2
	puts "婴儿"
when 3..6
	puts "小孩"
when 7..12
	puts "骚年"
else
	puts "老年"
	
end
puts "======================"


# while
$i = 0 
$num = 5
while $i < $num do
	puts "在while里面 i = #{$i}"
	$i += 1
end
puts "======================"
$i = 0 
begin
	puts "在while里面 i= #{$i}"
	$i += 1
end while $i < $num
puts "======================"


# until
$i = 0 
until $i > $num do 
	puts "在until里面 i= #{$i}"
	$i += 1
end
puts "======================"
$i = 0 
begin
   puts"在until里面 i= #{$i}"
   $i +=1;
end until $i > $num
puts "======================"

for i in 0..5
	puts "for里面的i= #{i}"
end
puts "======================"

(0..5).each do |i|
	puts "each do 里面的i= #{$i}"
end
puts "======================"

#  break, next（下一次循环）,  redo (该次循环再走一次)， retryt(从头开始重新循环)





















