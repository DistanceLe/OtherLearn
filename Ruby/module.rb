#!/usr/bin/ruby
$LOAD_PATH << '.'

#我们使用 $LOAD_PATH << '.' 让 Ruby 知道必须在当前目录中搜索被引用的文件。
#如果您不想使用 $LOAD_PATH，那么您可以使用 require_relative 来从一个相对目录引用文件
puts "========================"
require 'method.rb'

y = Trig.sin(Trig::PI/4)
wrongdoing = Moral.sin(Moral::VERY_BAD)

puts y
puts wrongdoing
puts "========================"
class Decade
include Week                       #在类中引用模块
   no_of_yrs=10
   def no_of_months
      puts Week::FIRST_DAY
      number=10*12
      puts number
   end
end

d1=Decade.new
puts Week::FIRST_DAY
Week.weeks_in_month
Week.weeks_in_year
d1.no_of_months