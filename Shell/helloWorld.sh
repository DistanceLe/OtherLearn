

#-bash: ./helloWorld.sh: Permission denied解决方法：  chmod u+x *.sh
#!/bin/sh
echo "hello world!"
name="xiaoMing"
echo $name

for skill in words Ads Coffe Action Java; do
	#statements
	echo "this is $skill script"
done

#遍历出 文件夹里面的文件
for file in `ls /Users/renjinkui/Desktop/Shell`; do
	echo "fileName= $file"
done

myUrl="http://www.baidu.com"
readonly myUrl

myUrl="http://xxx.com" #./helloWorld.sh: line 21: myUrl: readonly variable

your_name="qinjx"
greeting="hello, "$your_name" !"
greeting_1="hello, ${your_name}!"
echo $greeting $greeting_1
 
echo ${greeting:1:3} #输出ell  提取子串

#expr: syntax error  
string="runoob is a great company"
echo `expr index "$string" is`  # 输出 8

echo `expr index "$greeting" h`

echo "输出参数(文件名): $0"
echo "输出参数（第一个）: $1"
echo "参数个数：$#"
echo "所以参数作为字符串显示: $*"
echo "脚本运行的当前进程号：$$"
echo "后台运行的最后一个进程号：$!"
echo "shell 当前选项：$-"
echo "最后命令的退出状态：$?" #0表示没有错误，其他任何值表明有错误。

echo "-- \$* 演示 ---"
for i in "$*"; do
    echo $i
done

echo "-- \$@ 演示 ---"
for i in "$@"; do
    echo $i
done


val=`expr 2 + 2 `
echo "两数相加用expr，和为：$val"

a=10
b=20
val=`expr $a \* $b`  #乘法
val=`expr $a % $b`   #取余
if [ $a != $b ] 
then
	echo "equal"
	#statements
fi

echo "It is a test" > myfile  #将结果输出到 myfile文件
echo `date`					  #输出时间


printf "%d %s\n" 1 "abc"
# 单引号与双引号效果一样 
printf '%d %s\n' 1 "abc" 
# 没有引号也可以输出
printf %s abcdef
# 格式只指定了一个参数，但多出的参数仍然会按照该格式输出，format-string 被重用
printf %s abc def
printf "%s\n" abc def
printf "%s %s %s\n" a b c d e f g h i j

# 如果没有 arguments，那么 %s 用NULL代替，%d 用 0 代替
printf "%s and %d \n" 






