#!/usr/bin/ruby
puts "Hello World!";
puts "你好，世界！";


#这个是 注释
#这样就是多行注释了

=begin
这个里面也都是注释
哦
这种块注释会对解释器隐藏
=end
print <<EOF

	这个是一种创建多行字符串
	多行哦
EOF

print <<"EOF"
	一样的哦，也是多行的字符串
	多行哦

EOF

print <<`EOC`
	echo 执行命令
	echo 这个就不是字符串了，是执行命令哦
EOC

print <<"foo", <<"bar"

	哈哈哈，这个是第一个foo哦
foo
	我是第二个哦，bar

bar

END{
	puts "这个就是最后执行喽"
}


BEGIN{
	puts "这个一定会在程序最开始的时候执行"
}