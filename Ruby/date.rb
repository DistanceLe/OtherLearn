#!/usr/bin/ruby

time1 = Time.new
puts "当前时间:" + time1.inspect

#Time.now 
time2 = Time.now
puts "当前时间:" + time2.inspect

puts time2.year
puts time2.month
puts time2.day
puts time2.wday
puts time2.yday
puts time2.hour
puts time2.min
puts time2.sec
puts time2.usec
puts time2.zone
puts "====================================="

puts time2.to_a