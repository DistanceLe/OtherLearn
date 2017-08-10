#!/usr/bin/ruby

=begin
self: 当前方法的接收器对象。
true: 代表 true 的值。
false: 代表 false 的值。
nil: 代表 undefined 的值。
__FILE__: 当前源文件的名称。
__LINE__: 当前行在源文件中的编号。
=end

#$ 表示全局变量
$globalName = "xiaoming"

#常量 以大写字母开头
Var1 = 100

class Customer

	@@no_of_customers = 0			#@@ 表示类变量, 对象共享属性的值
	
	def initialize(id, name, addr)  #@ 表示 实例变量
		@cust_id = id
		@cust_name = name
		@cust_addr = addr
		
	end

	def display_details()
      puts "Customer id #@cust_id"
      puts "Customer name #@cust_name"
      puts "Customer address #@cust_addr"
      puts "GlobalName: #{$globalName}"			#使用全局变量
      puts "GlobalName: #$globalName"			#都可以
    end
    def total_no_of_customers()
       @@no_of_customers += 1
       puts "Total number of customers: #@@no_of_customers"
    end
end

cust1 = Customer.new("3", "john", "wisdom Apartments")
cust2 = Customer.new("8", "poul", "new empire road")


cust2.display_details
cust2.total_no_of_customers

cust1.total_no_of_customers